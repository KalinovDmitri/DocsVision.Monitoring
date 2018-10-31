using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public abstract class BaseCardSectionRowMapper<TSectionRow> : DocsVisionEntityMapper<TSectionRow> where TSectionRow : BaseCardSectionRow
	{
		protected readonly Guid _sectionTypeId;

		protected internal BaseCardSectionRowMapper(Guid sectionTypeId) : base()
		{
			if (sectionTypeId == Guid.Empty)
			{
				throw new ArgumentException($"Section type Id cannot be equal to '{Guid.Empty}'.", nameof(sectionTypeId));
			}

			_sectionTypeId = sectionTypeId;
		}

		protected override sealed string MakeTableName()
		{
			return string.Format("dvtable_{{{0}}}", _sectionTypeId);
		}

		protected override void MapPrimaryKey(EntityTypeBuilder<TSectionRow> entityBuilder)
		{
			entityBuilder.Property(x => x.RowID)
				.IsRequired()
				.HasDefaultValueSql(DocsVisionMappingConstants.NewSequentialID)
				.ValueGeneratedOnAdd();

			entityBuilder.HasKey(x => x.RowID)
				.ForSqlServerIsClustered(false);
		}

		protected override void MapEntity(EntityTypeBuilder<TSectionRow> entityBuilder)
		{
			entityBuilder.Property(x => x.SysRowTimestamp)
				.IsRowVersion();

			entityBuilder.Property(x => x.OwnServerID)
				.IsRequired();

			entityBuilder.Property(x => x.ChangeServerID);

			entityBuilder.Property(x => x.InstanceID)
				.IsRequired();

			entityBuilder.Property(x => x.ParentRowID)
				.IsRequired();

			entityBuilder.Property(x => x.ParentTreeRowID)
				.IsRequired();
		}
	}
}