using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace DL
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
            this.sqlType = ESQL_TYPE.NonQuery;
            this.conn = null;
            this.m_lock = new object();
            this.connectionstring = ConnStr;
        }

        public TDB(string name, string password, string catalog, string serverip)
        {
            this.sqlType = ESQL_TYPE.NonQuery;
            this.conn = null;
            this.m_lock = new object();
            this.connectionstring = "Provider=SQLOLEDB.1;User ID=" + name + ";Password=" + password + ";Initial Catalog=" + catalog + ";Data Source=" + serverip + ";Persist Security Info=False;Auto Translate=True;Packet Size=4096;";
        }

        public void BeginTrans()
        {
            try
            {
                if (this.conn == null)
                {
                    this.conn = new OleDbConnection(this.connectionstring);
                }
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                this.trans = this.conn.BeginTransaction();
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
                    if (this.conn != null)
                    {
                        this.conn.Close();
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
                this.trans.Commit();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (this.conn != null)
                {
                    this.conn.Close();
                }
            }
        }

        public object Excute(string asSqlText)
        {
            OleDbCommand aoCmd = this.conn.CreateCommand();
            aoCmd.CommandType = CommandType.Text;
            aoCmd.CommandText = asSqlText;
            switch (this.sqlType)
            {
                case ESQL_TYPE.NonQuery:
                    this.ExcuteNonQuery(aoCmd);
                    break;

                case ESQL_TYPE.Reader:
                    return this.ExcuteReader(aoCmd);

                case ESQL_TYPE.Scalar:
                    return this.ExcuteScalar(aoCmd);

                case ESQL_TYPE.DataSet:
                    return this.ExcuteDataSet(aoCmd);
            }
            return null;
        }

        public void Excute(string asSqlText, OleDbParameter[] arParams, int commandType)
        {
            if (this.conn == null)
            {
                this.conn = new OleDbConnection(this.connectionstring);
            }

            if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }

            OleDbCommand command = this.conn.CreateCommand();
            command.Parameters.Clear();
            command.Transaction = this.trans;

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
            if (this.conn == null)
            {
                this.conn = new OleDbConnection(this.connectionstring);
            }

            this.trans = null;

            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();

                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }

                this.trans = this.conn.BeginTransaction();

                for (int i = 0; i < arrList.Count; i++)
                {
                    DictionaryEntry entry = (DictionaryEntry)arrList[i];
                    adapter.InsertCommand = (OleDbCommand)entry.Key;
                    adapter.InsertCommand.Connection = this.conn;
                    adapter.InsertCommand.Transaction = this.trans;
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

                this.trans.Commit();

                return 0;
            }
            catch (OleDbException exception)
            {
                if (this.trans != null)
                {
                    this.trans.Rollback();
                }

                this.CheckException(exception);
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
            return this.ExecSQL(sQL);
        }

        public int ExecSQL(string SQL)
        {
            if (this.conn == null)
            {
                this.conn = new OleDbConnection(this.connectionstring);
            }
            try
            {
                OleDbCommand command = new OleDbCommand(SQL, this.conn);
                command.CommandTimeout = 30;
                if (command.Connection.State.ToString().Equals("Closed"))
                {
                    command.Connection.Open();
                }
                command.Transaction = this.trans;
                return command.ExecuteNonQuery();
            }
            catch (OleDbException exception)
            {
                this.CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenDataSet(string SQL, out DataSet ds)
        {
            ds = new DataSet();
            if (this.conn == null)
            {
                this.conn = new OleDbConnection(this.connectionstring);
            }
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                OleDbCommand command = new OleDbCommand(SQL, this.conn);
                command.CommandTimeout = 30;
                command.Transaction = this.trans;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                return 0;
            }
            catch (OleDbException exception)
            {
                this.CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenDataSet(string SQL, out DataTable dt)
        {
            dt = new DataTable();
            if (this.conn == null)
            {
                this.conn = new OleDbConnection(this.connectionstring);
            }
            try
            {
                if (this.conn.State == ConnectionState.Closed)
                {
                    this.conn.Open();
                }
                OleDbCommand command = new OleDbCommand(SQL, this.conn);
                command.CommandTimeout = 30;
                command.Transaction = this.trans;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                return 0;
            }
            catch (OleDbException exception)
            {
                this.CheckException(exception);
                new TLogError(exception, SQL).SaveExceptionInfo();
                return -1;
            }
        }

        public int OpenProcedure(string proc, string param, out DataSet ds)
        {
            string sQL = proc + " " + param;
            return this.OpenDataSet(sQL, out ds);
        }

        public int OpenProcedure(string proc, string param, out DataTable dt)
        {
            string sQL = proc + " " + param;
            return this.OpenDataSet(sQL, out dt);
        }

        public void RollBack()
        {
            try
            {
                this.trans.Rollback();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (this.conn != null)
                {
                    this.conn.Close();
                }
            }
        }

        public ESQL_TYPE SqlType
        {
            get
            {
                return this.sqlType;
            }
            set
            {
                this.sqlType = value;
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
