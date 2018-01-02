using Dy.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dy.Service
{
    /// <summary>
    /// 用户管理器
    /// </summary>
    public class SysUserManager : AspNetUserManager<SysUser>
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="store"></param>
        /// <param name="optionsAccessor"></param>
        /// <param name="passwordHasher"></param>
        /// <param name="userValidators"></param>
        /// <param name="passwordValidators"></param>
        /// <param name="keyNormalizer"></param>
        /// <param name="errors"></param>
        /// <param name="services"></param>
        /// <param name="logger"></param>
        public SysUserManager(IUserStore<SysUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<SysUser> passwordHasher,
            IEnumerable<IUserValidator<SysUser>> userValidators,
            IEnumerable<IPasswordValidator<SysUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<SysUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
                 keyNormalizer,
                 errors, services, logger)
        { }

    }
}
