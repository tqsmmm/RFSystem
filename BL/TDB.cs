using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace BL
{
    public class TDB
    {
        protected OleDbConnection conn;
        protected string connectionstring;
        private object m_lock;
        private ESQL_TYPE sqlType;
        protected OleDbTransaction trans;

        public TDB(string ConnStr)
        {
            sqlType = ESQL_TYPE.NonQuery;
            conn = null;
            m_lock = new object();
            connectionstring = ConnStr;
        }

        public TDB(string name, string password, string catalog, string serverip)
        {
            sqlType = ESQL_TYPE.NonQuery;
            conn = null;
            m_lock = new object();
            connectionstring = "Provider=SQLOLEDB.1;User ID=" + name + ";Password=" + password + ";Initial Catalog=" + catalog + ";Data Source=" + serverip + ";Persist Security Info=False;Auto Translate=True;Packet Size=4096;";
        }

        public void BeginTrans()
        {
            try
            {
                if (conn == null)
                {
                    conn = new OleDbConnection(connectionstring);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                trans = conn.BeginTransaction();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void CheckException(OleDbException e)
        {
            new TLogError(e).SaveExceptionInfo();

            if (TLogError.GetDBErrorType(e) == -20)
            {
                try
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                catch (Exception exception)
                {
                    new TLogError(exception).SaveExceptionInfo();
                }
            }
        }

        public void Commit()
        {
            try
            {
                trans.Commit();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public object Excute(string asSqlText)
        {
            OleDbCommand aoCmd = conn.CreateCommand();
            aoCmd.CommandType = CommandType.Text;
            aoCmd.CommandText = asSqlText;

            switch (sqlType)
            {
                case ESQL_TYPE.NonQuery:
                    ExcuteNonQuery(aoCmd);
                    break;

                case ESQL_TYPE.Reader:
                    return ExcuteReader(aoCmd);

                case ESQL_TYPE.Scalar:
                    return ExcuteScalar(aoCmd);

                case ESQL_TYPE.DataSet:
                    return ExcuteDataSet(aoCmd);
            }

            return null;
        }

        public void Excute(string asSqlText, OleDbParameter[] arParams, int commandType)
        {
            if (conn == null)
            {
                conn = new OleDbConnection(connectionstring);
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            OleDbCommand command = conn.CreateCommand();
            command.Parameters.Clear();
            command.Transaction = trans;

            if (arParams != null)
            {
                foreach (OleDbParameter parameter in arParams)
                {
                    command.Parameters.Add(parameter);
                }
            }

            switch (commandType)
            {
                case 0:
                    command.CommandType = CommandType.Text;
                    break;

                case 1:
                    command.CommandType = CommandType.StoredProcedure;
                    break;

                case 2:
                    command.CommandType = CommandType.TableDirect;
                    break;
            }

            command.CommandText = asSqlText;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private DataSet ExcuteDataSet(OleDbCommand aoCmd)
        {
            return null;
        }

        public int ExcuteInsertCommand(ArrayList arrList)
        {
            if (conn == null)
            {
                conn = new OleDbConnection(connectionstring);
            }

            trans = null;

            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                trans = conn.BeginTransaction();

                for (int i = 0; i < arrList.Count; i++)
                {
                    DictionaryEntry entry = (DictionaryEntry)arrList[i];
                    adapter.InsertCommand = (OleDbCommand)entry.Key;
                    adapter.InsertCommand.Connection = conn;
                    adapter.InsertCommand.Transaction = trans;
                    entry = (DictionaryEntry)arrList[i];

                    if (entry.Value == null)
                    {
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        entry = (DictionaryEntry)arrList[i];
                        adapter.Update((DataTable)entry.Value);
                    }
                }

                trans.Commit();

                return 0;
            }
            catch (OleDbException exception)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }

                CheckException(exception);
                string des = "";
                new TLogError(exception, des).SaveExceptionInfo();

                return -1;
            }
        }

        private void ExcuteNonQuery(OleDbCommand aoCmd)
        {
            try
            {
                if (aoCmd.Connection.State != ConnectionState.Open)
                {
                    aoCmd.Connection.Open();                   
                }

                aoCmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private OleDbDataReader ExcuteReader(OleDbCommand aoCmd)
        {
            OleDbDataReader reader;

            try
            {
                if (aoCmd.Connection.State != ConnectionState.Open)
                {
                    aoCmd.Connection.Open();
                }

                reader = aoCmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return reader;
        }

        private object ExcuteScalar(OleDbCommand aoCmd)
        {
            object obj2;

            try
            {
                obj2 = aoCmd.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return obj2;
        }

        public int ExecProcedure(string proc, string param)
        {
            string sQL = proc + " " + param;
            return ExecSQL(sQL);
        }

        public int ExecSQL(string SQL)
        {
            if (conn == null)
            {
                conn = new OleDbConnection(connectionstring);
            }

            try
            {
                OleDbCommand command = new OleDbCommand(SQL, conn);
                command.CommandTimeout = 30;

                if (command.Connection.State.ToString().Equals("Closed"))
                {
                    command.Connection.Open();
                }

                command.Transaction = trans;
                return command.ExecuteNonQuery();
            }
            catch (OleDbException exception)
            {
                CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenDataSet(string SQL, out DataSet ds)
        {
            ds = new DataSet();

            if (conn == null)
            {
                conn = new OleDbConnection(connectionstring);
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OleDbCommand command = new OleDbCommand(SQL, conn);
                command.CommandTimeout = 30;
                command.Transaction = trans;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                return 0;
            }
            catch (OleDbException exception)
            {
                CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenDataSet(string SQL, out DataTable dt)
        {
            dt = new DataTable();

            if (conn == null)
            {
                conn = new OleDbConnection(connectionstring);
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OleDbCommand command = new OleDbCommand(SQL, conn);
                command.CommandTimeout = 30;
                command.Transaction = trans;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                return 0;
            }
            catch (OleDbException exception)
            {
                CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenProcedure(string proc, string param, out DataSet ds)
        {
            string sQL = proc + " " + param;
            return OpenDataSet(sQL, out ds);
        }

        public int OpenProcedure(string proc, string param, out DataTable dt)
        {
            string sQL = proc + " " + param;
            return OpenDataSet(sQL, out dt);
        }

        public void RollBack()
        {
            try
            {
                trans.Rollback();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public ESQL_TYPE SqlType
        {
            get
            {
                return sqlType;
            }
            set
            {
                sqlType = value;
            }
        }

        public enum ESQL_TYPE
        {
            NonQuery,
            Reader,
            Scalar,
            DataSet
        }
    }
}
