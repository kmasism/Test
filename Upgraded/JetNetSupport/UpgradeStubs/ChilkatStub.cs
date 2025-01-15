using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilkat_v9_5_0
{
	public class ChilkatFtp2
	{
		public string hostname;
		public string username;
		public string password;
		public int port;

		public string DebugLogFilePath { get; set; }
		public int VerboseLogging { get; set; }
		public int KeepSessionLog { get; set; }
		public int IdleTimeoutMs { get; set; }
		public int Passive { get; set; }
		public object LastErrorText { get; set; }

		public int ChangeRemoteDir(string strFTPDir)
		{
			throw new NotImplementedException();
		}

		public int Connect()
		{
			throw new NotImplementedException();
		}

		public int DeleteRemoteFile(string v)
		{
			throw new NotImplementedException();
		}

		public void Disconnect()
		{
			throw new NotImplementedException();
		}

		public int GetFile(string strFTPFileName, string v)
		{
			throw new NotImplementedException();
		}

		public int GetSizeByName(string strFTPFileName)
		{
			throw new NotImplementedException();
		}

		public int PutFile(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public int UnlockComponent(string gstrChilkatUnlockCode)
		{
			throw new NotImplementedException();
		}
	}
	public class ChilkatMailMan
	{
		public string DebugLogFilePath { get; set; }
		public int VerboseLogging { get; set; }

		public dynamic ConnectTimeout { get; set; }
		public dynamic SmtpHost { get; set; }
		public dynamic SmtpPort { get; set; }
		public dynamic SmtpUsername { get; set; }
		public dynamic SmtpPassword { get; set; }
		public int SmtpSsl { get; set; }
		public string SslProtocol { get; set; }
		public int StartTls { get; set; }
		public int PreferIpv6 { get; set; }
		public int RequireSslCertVerify { get; set; }
		public object LastErrorText { get; set; }

		public void CloseSmtpConnection()
		{
			throw new NotImplementedException();
		}

		public int SendEmail(ChilkatEmail eMail2)
		{
			throw new NotImplementedException();
		}

		public int UnlockComponent(string gstrChilkatUnlockCode)
		{
			throw new NotImplementedException();
		}
	}
	public class ChilkatEmail
	{
		public string fromName;
		public string subject;

		public string FromAddress { get; set; }

		public void AddBcc(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public void AddCC(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public void AddFileAttachment(string strAttachment)
		{
			throw new NotImplementedException();
		}

		public void AddTo(string v1, string v2)
		{
			throw new NotImplementedException();
		}

		public void SetHtmlBody(string strBody)
		{
			throw new NotImplementedException();
		}

		public void SetTextBody(string strBody, string v)
		{
			throw new NotImplementedException();
		}
	}

	public class ChilkatZip
	{
		public string DebugLogFilePath { get; set; }
		public int VerboseLogging { get; set; }
		public object LastErrorText { get; set; }
		public int PasswordProtect { get; set; }
		public int NumEntries { get; set; }

		public int AppendFiles(string v1, int v2)
		{
			throw new NotImplementedException();
		}

		public void CloseZip()
		{
			throw new NotImplementedException();
		}

		public int NewZip(string strZipFileName)
		{
			throw new NotImplementedException();
		}

		public int OpenZip(string strZipFileName)
		{
			throw new NotImplementedException();
		}

		public void SetPassword(string strZipPassword)
		{
			throw new NotImplementedException();
		}

		public int UnlockComponent(string gstrChilkatUnlockCode)
		{
			throw new NotImplementedException();
		}

		public int Unzip(string strUnZipToPath)
		{
			throw new NotImplementedException();
		}

		public int WriteZip()
		{
			throw new NotImplementedException();
		}
	}

	public class ChilkatHttp
	{
		public string DebugLogFilePath { get; set; }
		public int VerboseLogging { get; set; }
		public object LastErrorText { get; set; }

		public int Download(string strURL, string strLocalFileName)
		{
			throw new NotImplementedException();
		}

		public int UnlockComponent(string gstrChilkatUnlockCode)
		{
			throw new NotImplementedException();
		}
	}
}
