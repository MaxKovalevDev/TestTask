using Newtonsoft.Json;

namespace Terrasoft.Configuration
{
	/// <summary>
	/// DTO для парсинга log файла
	/// </summary>
	internal class LogFileDTO
	{
		[JsonProperty("date-time")]
		public string? DateTime { get; set; }

		[JsonProperty("client-ip")]
		public string? ClientIp { get; set; }

		[JsonProperty("client-hostname")]
		public string? ClientHostname { get; set; }

		[JsonProperty("server-ip")]
		public string? ServerIp { get; set; }

		[JsonProperty("server-hostname")]
		public string? ServerHostname { get; set; }

		[JsonProperty("source-context")]
		public string? SourceContext { get; set; }

		[JsonProperty("connector-id")]
		public string? ConnectorId { get; set; }

		[JsonProperty("event-id")]
		public string? EventId { get; set; }

		[JsonProperty("internal-message-id")]
		public string? InternalMessageId { get; set; }

		[JsonProperty("message-id")]
		public string? MessageId { get; set; }

		[JsonProperty("network-message-id")]
		public string? NetworkMessageId { get; set; }

		[JsonProperty("recipient-address")]
		public string? RecipientAddress { get; set; }

		[JsonProperty("recipient-status")]
		public string? RecipientStatus { get; set; }

		[JsonProperty("total-bytes")]
		public string? TotalBytes { get; set; }

		[JsonProperty("recipient-count")]
		public string? RecipientCount { get; set; }

		[JsonProperty("related-recipient-address")]
		public string? RelatedRecipientAddress { get; set; }

		[JsonProperty("reference")]
		public string? Reference { get; set; }

		[JsonProperty("message-subject")]
		public string? MessageSubject { get; set; }

		[JsonProperty("sender-address")]
		public string? SenderAddress { get; set; }

		[JsonProperty("return-path")]
		public string? ReturnPath { get; set; }

		[JsonProperty("message-info")]
		public string? MessageInfo { get; set; }

		[JsonProperty("directionality")]
		public string? Directionality { get; set; }

		[JsonProperty("tenant-id")]
		public string? TenantId { get; set; }

		[JsonProperty("original-client-ip")]
		public string? OriginalClientIp { get; set; }

		[JsonProperty("original-server-ip")]
		public string? OriginalServerIp { get; set; }

		[JsonProperty("custom-data")]
		public string? CustomData { get; set; }

		[JsonProperty("log-id")]
		public string? LogId { get; set; }
	}
}
