using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MimeKit;
using MimeKit.Text;

using DocsVision.Monitoring.Options;

namespace DocsVision.Monitoring.Services.Tests
{
	[TestClass]
	public class MailKitEmailServiceTests
	{
		#region Test methods

		[TestMethod]
		[ExpectedException(typeof(MailKit.Security.AuthenticationException))]
		public async Task IsSmtpClientThrowsAuthenticationExceptionOnInvalidUsernameOrPassword()
		{
			var message = new MimeMessage
			{
				Subject = "§§§ Ooops! something went wrong! §§§",
				Body = new TextPart(TextFormat.Text)
			};
			
			message.To.Add(InternetAddress.Parse("kokoko@kudah.com"));

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
				UserName = "ololo",
				Password = "*****",
				Sender = "ololo@trololo.com"
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