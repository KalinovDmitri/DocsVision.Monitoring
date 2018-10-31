using System;

namespace DocsVision.Monitoring.DataModel
{
	/// <summary>
	/// Статусы сотрудника
	/// </summary>
	public enum StaffEmployeeStatus : int
	{
		/// <summary>
		/// Активен
		/// </summary>
		Active = 0,
		/// <summary>
		/// Болен
		/// </summary>
		Sick = 1,
		/// <summary>
		/// В отпуске
		/// </summary>
		Vacation = 2,
		/// <summary>
		/// В командировке
		/// </summary>
		BusinessTrip = 3,
		/// <summary>
		/// Отсутствует
		/// </summary>
		Absent = 4,
		/// <summary>
		/// Уволен
		/// </summary>
		Discharged = 5,
		/// <summary>
		/// Переведён
		/// </summary>
		Transfered = 6,
		/// <summary>
		/// Уволен без возможности восстановления
		/// </summary>
		DischargedNoRestoration = 7
	}
}