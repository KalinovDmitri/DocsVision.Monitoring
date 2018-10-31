using System;
using System.ComponentModel.DataAnnotations;

namespace DocsVision.Monitoring.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Это поле является обязательным")]
		[Display(Name = "Имя пользователя")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Это поле является обязательным")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
	}
}