﻿using System;

namespace DocsVision.Monitoring.DataModel
{
	public class StatesState : BaseCardSectionRow
	{
		public string DefaultName { get; set; }

		public bool? Dynamic { get; set; }

		public Guid? BuiltInState { get; set; }

		public Guid? DefaultNameUID { get; set; }
	}
}