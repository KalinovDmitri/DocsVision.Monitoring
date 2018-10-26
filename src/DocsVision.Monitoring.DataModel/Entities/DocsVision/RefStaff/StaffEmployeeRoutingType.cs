using System;

namespace DocsVision.Monitoring.DataModel
{
	/// <summary>
	/// Типы маршрутизации
	/// </summary>
	public enum StaffEmployeeRoutingType : int
	{
		/// <summary>
		/// Не маршрутизировать
		/// </summary>
		NoRouting = 0,
		/// <summary>
		/// Письмо с вложениями
		/// </summary>
		DescriptionLetter = 1,
		/// <summary>
		/// Задача Outlook
		/// </summary>
		OutlookTask = 2,
		/// <summary>
		/// Ссылка на задание
		/// </summary>
		TaskLink = 3,
		/// <summary>
		/// Оффлайн задание
		/// </summary>
		OfflineTask = 4,
		/// <summary>
		/// Онлайн задание
		/// </summary>
		OnlineTask = 5,
		/// <summary>
		/// Зашифрованное оффлайн
		/// </summary>
		OfflineEncrypted = 6
	}
}