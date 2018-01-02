using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dy.Data.Initialize
{
    /// <summary>
    /// 数据库自动迁移升级
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// 自动升级
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static void InitializeAsync(DyDbContext context)
        {
            //获取未应用的Migrations，不必要，MigrateAsync方法会自动处理
            //var migrations = await context.Database.GetPendingMigrationsAsync();
            //根据Migrations修改/创建数据库
            context.Database.MigrateAsync();
        }
    }
}
