﻿using System;

namespace DocsVision.Monitoring.DataModel
{
	public class BaseCardDates : DocsVisionEntity
	{
		public Guid InstanceID { get; set; }

		public byte[] Timestamp { get; set; }

		public DateTime? CreationDateTime { get; set; }

		public DateTime? ChangeDateTime { get; set; }
	}
}