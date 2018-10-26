using System;

namespace DocsVision.Monitoring.DataModel
{
	/// <summary>
	/// Статус в период неактивности
	/// </summary>
	public enum StaffEmployeeInactiveStatus : int
	{
		/// <summary>
		/// Болен
		/// </summary>
		Sick = 0,
		/// <summary>
		/// В отпуске
		/// </summary>
		Vacation = 1,
		/// <summary>
		/// В командировке
		/// </summary>
		BusinessTrip = 2,
		/// <summary>
		/// Отсутствует
		/// </summary>
		Absent = 3
	}
}