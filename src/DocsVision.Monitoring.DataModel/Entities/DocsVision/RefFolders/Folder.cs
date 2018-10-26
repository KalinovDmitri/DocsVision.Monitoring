using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class Folder : BaseCardSectionRow
	{
		public Guid? SDID { get; set; }

		public string Name { get; set; }

		public FolderType? Type { get; set; }

		public FolderDefaultStyle? DefaultStyle { get; set; }

		public Guid? PropCardUID { get; set; }

		public string Url { get; set; }

		public int? AllowedStyles { get; set; }

		public bool? Deleted { get; set; }

		public Guid? IconRef { get; set; }

		public FolderRestrictions? Restrictions { get; set; }

		public Guid? DefaultViewID { get; set; }

		public Guid? RefID { get; set; }

		public bool? ViewCyclingEnabled { get; set; }

		public int? ViewCycleCount { get; set; }

		public FolderFlags? Flags { get; set; }

		public Guid? DefaultTemplateID { get; set; }

		public int? RefreshTimeout { get; set; }

		public Guid? ExtTypeID { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreatedBy { get; set; }

		public Guid? NameUID { get; set; }

		public virtual SecurityInfo Security { get; set; }

		public virtual Folder ParentFolder { get; set; }

		public virtual ICollection<Shortcut> Shortcuts { get; set; }
	}
}