using System;

namespace DocsVision.Monitoring.DataModel
{
	public class LockInfo : DocsVisionEntity
	{
		public Guid ResourceID { get; set; }

		public Guid LockOwnerID { get; set; }

		public bool LockType { get; set; }

		public LockedObjectType ResourceType { get; set; }

		public Guid? SessionID { get; set; }

		public Guid? SectionTypeID { get; set; }

		public Guid? InstanceID { get; set; }

		public virtual User Owner { get; set; }

		public virtual Session OwnerSession { get; set; }
	}
}