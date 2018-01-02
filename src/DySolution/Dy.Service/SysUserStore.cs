using Dy.Data;
using Dy.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dy.Service
{
    /// <summary>
    /// 用户存储器
    /// </summary>
    public class SysUserStore : UserStore<SysUser, SysRole, DyDbContext, string, SysUserClaim, SysUserRole, SysUserLogin, SysUserToken, SysRoleClaim>
    {
        public SysUserStore(DyDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<SysUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Users.Include(u => u.UserDepts)
                .Include(u => u.UserRoles)
                .Include(u => u.UserClaims)
                .Include(u => u.UserLogins)
                .Include(u => u.UserDepts)
                .Include(u => u.UserTokens)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
