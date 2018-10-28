using System;
using System.Collections.Generic;

using DocsVision.Monitoring.DataModel.Mapping;

namespace DocsVision.Monitoring.DataModel.Framework
{
	internal static class DocsVisionDbSchema
	{
		public static IEnumerable<IEntityMapper> GetMappers()
		{
			yield return new UserMapper();
			yield return new SessionMapper();
			yield return new SecurityInfoMapper();
			yield return new CardTypeMapper();
			yield return new BaseCardMapper();
			yield return new BaseCardDatesMapper();
			yield return new StaffUnitMapper();
			yield return new StaffEmployeeMapper();
			yield return new StaffPositionMapper();
			yield return new KindsCardKindMapper();
			yield return new StatesStateMapper();
			yield return new StatesStateNameMapper();
			yield return new FolderMapper();
			yield return new ShortcutMapper();
			yield return new DocumentMapper();
			yield return new DocumentMainInfoMapper();
			yield return new DocumentSystemInfoMapper();
			yield break;
		}
	}
}