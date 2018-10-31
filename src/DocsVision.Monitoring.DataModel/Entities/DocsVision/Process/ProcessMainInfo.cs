using System;
using System.Collections.Generic;

namespace DocsVision.Monitoring.DataModel
{
	public class ProcessMainInfo : BaseCardSectionRow
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public ProcessState? State { get; set; }

		public bool? HasLayout { get; set; }

		public DateTime? DateBegin { get; set; }

		public DateTime? DateEnd { get; set; }

		public Guid? InitialDoc { get; set; }

		public bool? SubProcess { get; set; }

		public Guid? ParentProcess { get; set; }

		public bool? Async { get; set; }

		public Guid? Calendar { get; set; }

		public ProcessTemplateState? TemplateState { get; set; }

		public string AuthorCreated { get; set; }

		public string AuthorModified { get; set; }

		public DateTime? DateCreated { get; set; }

		public DateTime? DateModified { get; set; }

		public string Version { get; set; }

		public Guid? Folder { get; set; }

		public string InstanceName { get; set; }

		public int? LocaleID { get; set; }

		public bool? Prepared { get; set; }

		public string InstanceAuthor { get; set; }

		public Guid? InitialDocumentVariableID { get; set; }

		public ProcessPriority? CurrentPriority { get; set; }

		public ProcessPriority? Priority { get; set; }

		public DateTime? LastRunDate { get; set; }

		public int? NextRunDate { get; set; }

		public int? SynchronousSubprocess { get; set; }

		public bool? ReadyToRun { get; set; }

		public int? BuildNumber { get; set; }

		public ProcessLoggingLevel? LoggingLevel { get; set; }

		public int? LogLimit { get; set; }

		public ProcessAfterFinishBehavior? AfterFinishBehavior { get; set; }

		public Guid? Responsible { get; set; }

		public int? RefreshPeriod { get; set; }

		public Guid? TemplateProcess { get; set; }

		public ProcessClearLogStrategy? ClearLogStrategy { get; set; }

		public int? ClearLogDaysCount { get; set; }

		public DateTime? NextLogClearTime { get; set; }

		public int? FunctionsCount { get; set; }

		public bool? Singleton { get; set; }

		public bool? EncryptScripts { get; set; }

		public string Info { get; set; }

		public string Hash { get; set; }

		public ProcessExecutionMode? ExecutionMode { get; set; }

		public int? DateBeginMsecs { get; set; }

		public bool? SimpleMode { get; set; }

		public virtual Process Parent { get; set; }

		public virtual Process Template { get; set; }

		public virtual ICollection<ProcessDocType> DocTypes { get; set; }
	}
}