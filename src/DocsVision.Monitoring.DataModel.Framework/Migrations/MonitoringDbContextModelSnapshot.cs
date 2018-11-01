﻿// <auto-generated />
using System;
using DocsVision.Monitoring.DataModel.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocsVision.Monitoring.DataModel.Framework.Migrations
{
    [DbContext(typeof(MonitoringDbContext))]
    partial class MonitoringDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.DocumentsWithoutShortcutsReportRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DocumentDescription")
                        .HasMaxLength(512)
                        .IsUnicode(true);

                    b.Property<Guid>("DocumentId");

                    b.Property<string>("DocumentKindName")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<string>("DocumentName")
                        .HasMaxLength(480)
                        .IsUnicode(true);

                    b.Property<long?>("LinkId");

                    b.Property<long>("ReportId");

                    b.Property<string>("TargetFolderName")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("documentswithoutshortcutsreportrows_pk_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("LinkId")
                        .HasName("documentswithoutshortcutsreportrow_idx_linkid")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("ReportId")
                        .HasName("documentswithoutshortcutsreportrow_idx_reportid")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("DocumentsWithoutShortcutsReportRows","dbo");
                });

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.EventLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<long?>("EventId");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false);

                    b.Property<string>("Message")
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("eventlogs_pk_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("EventLogs","dbo");
                });

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.KindFolderLink", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FolderFullName")
                        .HasMaxLength(2048)
                        .IsUnicode(true);

                    b.Property<Guid>("FolderID");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("KindFullName")
                        .HasMaxLength(2048)
                        .IsUnicode(true);

                    b.Property<Guid>("KindID");

                    b.Property<string>("KindName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id")
                        .HasName("kindfolderlinks_pk_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("KindFolderLinks","dbo");
                });

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .IsUnicode(true);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.HasKey("Id")
                        .HasName("reports_pk_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Reports","dbo");

                    b.HasDiscriminator<string>("Type").HasValue("Report");
                });

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.DocumentsWithoutShortcutsReport", b =>
                {
                    b.HasBaseType("DocsVision.Monitoring.DataModel.Report");


                    b.ToTable("Reports","dbo");

                    b.HasDiscriminator().HasValue("DocumentsWithoutShortcuts");
                });

            modelBuilder.Entity("DocsVision.Monitoring.DataModel.DocumentsWithoutShortcutsReportRow", b =>
                {
                    b.HasOne("DocsVision.Monitoring.DataModel.KindFolderLink", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .HasConstraintName("documentswithoutshortcutsreportrow_fk_linkid")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DocsVision.Monitoring.DataModel.Report", "ParentReport")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .HasConstraintName("documentswithoutshortcutsreportrow_fk_reportid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
