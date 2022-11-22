using Terrasoft.Core;

namespace Terrasoft.Confuguration
{
	/// <summary>
	/// Данные для подключения к SFTP
	/// </summary>
	internal class FTPCredentials
	{
		private UserConnection UserConnection;

		private string login = string.Empty;

		private string password = string.Empty;

		private string url = string.Empty;

		public FTPCredentials(UserConnection userConnection)
		{
			this.UserConnection = userConnection;
		}

		/// <summary>
		/// Хост
		/// </summary>
		public string Url
		{
			get
			{
				if (string.IsNullOrEmpty(this.url))
				{
					this.url = Core.Configuration.SysSettings.GetValue(UserConnection, ServerConstants.SysSettings.FTPSUrl, String.Empty);
				}
				return url;
			}
		}

		/// <summary>
		/// Логин
		/// </summary>
		public string Login
		{
			get
			{
				if(string.IsNullOrEmpty(this.login))
				{
					this.login = Core.Configuration.SysSettings.GetValue(UserConnection, ServerConstants.SysSettings.FTPSLogin, String.Empty);
				}
				return login;
			}
		}

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password
		{
			get
			{
				if (string.IsNullOrEmpty(this.password))
				{
					this.password = Core.Configuration.SysSettings.GetValue(UserConnection, ServerConstants.SysSettings.FTPSPassword, String.Empty);
				}
				return password;
			}
		}
	}
}
