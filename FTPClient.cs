using Common.Logging;
using Dadata.Model;
using MassTransit;
using Nest;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace Terrasoft.Confuguration
{
	/// <summary>
	/// Клиент для подключения к SFTP
	/// </summary>
	internal class FTPClient
	{
		private readonly ILog Logger;

		private FTPCredentials Credentials;

		public FTPClient(FTPCredentials credentials)
		{
			Credentials = credentials;
			Logger = LogManager.GetLogger($"FTPIntegrationLogger");
		}

		/// <summary>
		/// Скачивает файл
		/// </summary>
		/// <param name="stream"> поток для записи файла </param>
		/// <param name="fileName"> Название файла </param>
		public Stream Download(Stream stream, string fileName)
		{
			try
			{
				FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create($"ftp://{Credentials.Url}{fileName}");
				ftpRequest.Credentials = new NetworkCredential(Credentials.Login, Credentials.Password);
				ftpRequest.EnableSsl = true;
				ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
				FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
				stream = ftpResponse.GetResponseStream();
				ftpResponse.Close();
				return stream;
			}
			catch (Exception ex)
			{
				Logger.Error(ex);
				throw;
			}
		}
	}
}
