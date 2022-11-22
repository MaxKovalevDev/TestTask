using Terrasoft.Core;
using Terrasoft.Confuguration;
using CsvHelper;
using System.Globalization;
using Common.Logging;

namespace Terrasoft.Configuration
{

	/// <summary>
	/// Управляющий класс, подразумевается вызов из бизнес-процесса с интервалом
	/// запуска каждые 30 минут.
	/// </summary>
	public class EmailParserService
	{

		private DataBaseClient DbClient;

		private UserConnection UserConnection;

		private readonly ILog Logger;

		public EmailParserService(UserConnection userConnection)
		{
			this.UserConnection = userConnection;
			DbClient = new DataBaseClient(UserConnection);
			Logger = LogManager.GetLogger($"FTPIntegrationLogger");
		}

		/// <summary>
		/// Управляющий метод. Последовательно выполняет операции для обновления данных в crm
		/// на основании данных из log файла
		/// </summary>
		public void UpdateEmailsDataFromFtps()
		{
			try
			{
				using (var stream = new MemoryStream())
				{
					DownloadFile(stream);
					List<LogFileDTO> records = ParseLogFile<LogFileDTO>(stream);
					ProcessEmailMessagesMetadata(records);
				}
			}
			catch (Exception ex)
			{
				Logger.Error(ex);
				throw;
			}
		}

		/// <summary>
		/// Создает обращение и запись в справочнике "ID Сообщения" при необходимости
		/// </summary>
		/// <param name="records"> Записи log файла </param>
		private void ProcessEmailMessagesMetadata(List<LogFileDTO> records)
		{
			foreach (var item in records)
			{
				try
				{
					Guid messageId = DbClient.GetMessageId(item.MessageId);
					if (messageId == Guid.Empty)
					{
						DbClient.CreateMessageId(messageId);
						DbClient.CreateCase(item);
					}
				}
				catch (Exception ex)
				{
					Logger.Error(ex);
				}
			}
		}

		/// <summary>
		/// Парсит log файл
		/// </summary>
		/// <param name="stream"> Файл </param>
		private List<T> ParseLogFile<T>(MemoryStream stream)
		{
			using (var reader = new StreamReader(stream))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				var records = csv.GetRecords<T>();
				return records.ToList();
			}
		}

		/// <summary>
		/// Скачивает log файл
		/// </summary>
		/// <param name="stream"> Файл </param>
		private void DownloadFile(Stream stream)
		{
			FTPClient client = new FTPClient(new FTPCredentials(UserConnection));
			client.Download(stream, "/Logs/log.log");
		}
	}
}