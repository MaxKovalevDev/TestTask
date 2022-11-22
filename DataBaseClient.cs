using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrasoft.Confuguration;
using Terrasoft.Core;
using Terrasoft.Core.DB;

namespace Terrasoft.Configuration
{
	internal class DataBaseClient
	{
		private UserConnection UserConnection;

		public DataBaseClient(UserConnection userConnection)
		{
			this.UserConnection = userConnection;
		}

		/// <summary>
		/// Получает Id записи справочника "ID сообщения" по колонке "MessageId"
		/// </summary>
		/// <param name="messageId"> Id сообщения </param>
		public Guid GetMessageId(string messageId)
		{
			Select select = new Select(UserConnection)
				.Column("Id")
				.From("MessageId")
				.Where("MessageId").IsEqual(Column.Parameter(messageId)) as Select;

			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Создает обращение на основании метаданных email письма
		/// </summary>
		/// <param name="item"> Метаданные </param>
		internal void CreateCase(LogFileDTO item)
		{
			Case entity = new Case(UserConnection);
			message.SetDefColumnValues();
			entity.Recipient = item.RecipientAddress;
			entity.Subject = item.MessageSubject;
			entity.Sender = item.SenderAddress;
			entity.OriginId = ServerConstants.CaseOrigin.LoadedEmail;
			entity.Save();
		}

		/// <summary>
		/// Создает запись в справочнике "ID сообщения" на основании метаданных email письма
		/// </summary>
		/// <param name="messageId"> Id сообщения </param>
		internal void CreateMessageId(Guid messageId)
		{
			MessageId message = new MessageId(UserConnection);
			message.SetDefColumnValues();
			message.MessageId = messageId;
			message.Save();
		}
	}
}
