using System;

namespace DocsVision.Monitoring.DataModel
{
	/// <summary>
	/// Тип версионирования
	/// </summary>
	public enum DocumentVersioningType : int
	{
		/// <summary>
		/// Не указан
		/// </summary>
		None = 0,
		/// <summary>
		/// Автоматический
		/// </summary>
		Auto = 1,
		/// <summary>
		/// Ручной
		/// </summary>
		Manual = 2,
		/// <summary>
		/// Требуется выбрать значение
		/// </summary>
		Select = 3
	}
}