using System;

namespace DocsVision.Monitoring.DataModel
{
	public abstract class BaseEntity<TKey> where TKey : struct
	{
		public TKey Id { get; set; }
	}
}