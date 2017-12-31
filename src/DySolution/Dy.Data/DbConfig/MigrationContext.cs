using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Dy.Data.DbConfig
{
    /// <summary>
    /// 迁移表
    /// </summary>
    public class MigrationContext : HistoryContext
    {
        public MigrationContext(DbConnection dbConnection, string defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable(tableName: "SysMigHistory");
        }
    }
}
