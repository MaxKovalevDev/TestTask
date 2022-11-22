
namespace Terrasoft.Confuguration
{
	/// <summary>
	/// Константы
	/// </summary>
	internal static class ServerConstants
	{

		/// <summary>
		/// Источник обращения
		/// </summary>
		public static class CaseOrigin
		{
			/// <summary> Подгруженный email </summary>
			public static readonly Guid LoadedEmail = new Guid("7f9e1f1e-f46b-1410-3492-0050ba5d6c38");
		}

		/// <summary>
		/// Системные настройки
		/// </summary>
		public static class SysSettings
		{
			/// <summary> Логин SFTP сервера </summary>
			public static readonly string SFTPLogin = "SFTPLogin";
			/// <summary> Пароль SFTP сервера </summary>
			public static readonly string SFTPPassword = "SFTPPassword";
			/// <summary> URL SFTP сервера </summary>
			public static readonly string SFTPUrl = "SFTPUrl";

		}
	}
}
