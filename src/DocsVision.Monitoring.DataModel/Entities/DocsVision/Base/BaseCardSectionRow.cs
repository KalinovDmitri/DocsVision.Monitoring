﻿using System;

namespace DocsVision.Monitoring.DataModel
{
	public abstract class BaseCardSectionRow : BaseEntity<Guid>
	{
		public byte[] SysRowTimestamp { get; set; }

		public Guid OwnServerID { get; set; }

		public Guid? ChangeServerID { get; set; }

		public Guid InstanceID { get; set; }

		public Guid ParentRowID { get; set; }

		public Guid ParentTreeRowID { get; set; }
	}
}