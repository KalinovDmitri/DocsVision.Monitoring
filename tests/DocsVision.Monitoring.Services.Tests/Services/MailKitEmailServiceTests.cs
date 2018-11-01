using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MimeKit;
using MailKit;
using MailKit.Net.Smtp;

using DocsVision.Monitoring.Options;

namespace DocsVision.Monitoring.Services.Tests
{
	[TestClass]
	public class MailKitEmailServiceTests
	{
		#region Test methods

		[TestMethod]
		public async Task IsEmailMessageSendingExecutesSuccessfully()
		{
			var bodyBuilder = new BodyBuilder
			{
				TextBody = "This is test message that sended using MailKit"
			};

			var message = new MimeMessage
			{
				Subject = "Test message",
				Body = bodyBuilder.ToMessageBody()
			};

			message.From.Add(InternetAddress.Parse("kadmvl@yandex.ru"));
			message.To.Add(InternetAddress.Parse("kadmvl@yandex.ru"));

			await _emailService.SendAsync(message);
		}
		#endregion

		#region Initialize / cleanup methods

		[TestInitialize]
		public void Initialize()
		{
			var options = new SmtpOptions
			{
				HostName = "smtp.yandex.ru",
				Port = 465,
				UserName = "kadmvl",
				Password = "*****"
			};

			var wrapper = new OptionsWrapper<SmtpOptions>(options);

			_emailService = new MailKitEmailService(wrapper);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_emailService = null;
		}
		#endregion

		#region Fields and properties

		private IEmailService _emailService;
		#endregion
	}
}