using System; 
using System.IO; 
using System.Text; 
using System.Security.Cryptography; 

namespace SapService
{
	
		/// <summary> 
		/// DESEncryptor ��ժҪ˵���� 
		/// </summary> 
		public class RFdesOperator
		{
			#region ˽�г�Ա

			/// <summary> 
			/// �����ַ��� 
			/// </summary> 
			private string inputString = null;
			/// <summary> 
			/// ����ַ��� 
			/// </summary> 
			private string outString = null;
			/// <summary> 
			/// ������Կ 
			/// </summary> 
			private string encryptKey = null;
			/// <summary> 
			/// ������Կ 
			/// </summary> 
			private string decryptKey = "12345678";
			/// <summary> 
			/// ��ʾ��Ϣ 
			/// </summary> 
			private string noteMessage = null;

			#endregion

			#region ��������

			/// <summary> 
			/// ������Կ 
			/// </summary> 
			public string EncryptKey
			{
				get { return encryptKey; }
				set { encryptKey = value; }
			}

			/// <summary> 
			/// ������Կ 
			/// </summary> 
			public string DecryptKey
			{
				get { return decryptKey; }
				set { decryptKey = value; }
			}

			/// <summary> 
			/// �����ַ��� 
			/// </summary> 
			public string InputString
			{
				get { return inputString; }
				set { inputString = value; }
			}

			/// <summary> 
			/// ����ַ��� 
			/// </summary> 
			public string OutString
			{
				get { return outString; }
				set { outString = value; }
			}

			/// <summary> 
			/// ������Ϣ 
			/// </summary> 
			public string NoteMessage
			{
				get { return noteMessage; }
				set { noteMessage = value; }
			}

			#endregion

			#region ���캯��

			public RFdesOperator()
			{
				// 
				// TODO: �ڴ˴���ӹ��캯���߼� 
				// 
			}

			#endregion

			#region DES�����ַ���

			/// <summary> 
			/// �����ַ��� 
			/// ע��:��Կ����Ϊ8λ 
			/// </summary> 
			/// <param name="strText">�ַ���</param> 
			/// <param name="encryptKey">��Կ</param> 
			public void DesEncrypt()
			{
				byte[] byKey = null;
				byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
				try
				{
					byKey = System.Text.Encoding.UTF8.GetBytes(this.encryptKey.Substring(0, 8));
					DESCryptoServiceProvider des = new DESCryptoServiceProvider();
					byte[] inputByteArray = Encoding.UTF8.GetBytes(this.inputString);
					MemoryStream ms = new MemoryStream();
					CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
					cs.Write(inputByteArray, 0, inputByteArray.Length);
					cs.FlushFinalBlock();
					this.outString = Convert.ToBase64String(ms.ToArray());
				}
				catch (System.Exception error)
				{
					this.noteMessage = error.Message;
				}
			}

			#endregion

			#region DES�����ַ���

			/// <summary> 
			/// �����ַ��� 
			/// </summary> 
			/// <param name="this.inputString">�����ܵ��ַ���</param> 
			/// <param name="decryptKey">��Կ</param>
			public void DesDecrypt()
			{
				byte[] byKey = null;
				byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
				byte[] inputByteArray = new Byte[this.inputString.Length];
				try
				{
					byKey = System.Text.Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
					DESCryptoServiceProvider des = new DESCryptoServiceProvider();
					inputByteArray = Convert.FromBase64String(this.inputString);
					MemoryStream ms = new MemoryStream();
					CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
					cs.Write(inputByteArray, 0, inputByteArray.Length);
					cs.FlushFinalBlock();
					System.Text.Encoding encoding = new System.Text.UTF8Encoding();
					this.outString = encoding.GetString(ms.ToArray());
				}
				catch (System.Exception error)
				{
					this.noteMessage = error.Message;
				}
			}

			#endregion

			#region MD5

			/// <summary> 
			/// MD5����
			/// </summary> 
			/// <param name="strText">��Ҫ���ܵ���Ϣ</param> 
			/// <returns>MD5���ܵ�����</returns> 
			public void MD5Encrypt()
			{
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.inputString));
				this.outString = System.Text.Encoding.UTF8.GetString(result);
			}

			public static string getMd5Hash(string input)
			{
				// Create a new instance of the MD5CryptoServiceProvider object.
				MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

				// Convert the input string to a byte array and compute the hash.
				byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

				// Create a new Stringbuilder to collect the bytes
				// and create a string.
				StringBuilder sBuilder = new StringBuilder();

				// Loop through each byte of the hashed data 
				// and format each one as a hexadecimal string.
				for (int i = 0; i < data.Length; i++)
				{
					sBuilder.Append(data[i].ToString("x2"));
				}

				// Return the hexadecimal string.
				return sBuilder.ToString();
			}


			#endregion
		}
	}

