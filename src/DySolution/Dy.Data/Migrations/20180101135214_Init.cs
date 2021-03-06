﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Dy.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysDept",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    DeptCode = table.Column<string>(maxLength: 50, nullable: true),
                    DeptLevel = table.Column<int>(nullable: true),
                    DeptName = table.Column<string>(maxLength: 50, nullable: false),
                    DeptType = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SortId = table.Column<int>(nullable: true),
                    Tel = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysDept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysDictionary",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    DicKey = table.Column<string>(maxLength: 200, nullable: false),
                    DicLevel = table.Column<int>(nullable: true),
                    DicType = table.Column<string>(maxLength: 200, nullable: false),
                    DicValue = table.Column<string>(maxLength: 200, nullable: true),
                    DisName = table.Column<string>(maxLength: 200, nullable: true),
                    IsEnabed = table.Column<bool>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: true),
                    ParentId = table.Column<string>(maxLength: 30, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SortId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysDictionary", x => x.Id);
                    table.UniqueConstraint("AK_SysDictionary_DicType_DicKey", x => new { x.DicType, x.DicKey });
                });

            migrationBuilder.CreateTable(
                name: "SysLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    DeptId = table.Column<string>(maxLength: 36, nullable: false),
                    DeptName = table.Column<string>(maxLength: 50, nullable: true),
                    EmpName = table.Column<string>(maxLength: 50, nullable: true),
                    LogContent = table.Column<string>(maxLength: 4000, nullable: true),
                    LogIP = table.Column<string>(maxLength: 50, nullable: true),
                    LogType = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    Icon = table.Column<string>(maxLength: 100, nullable: true),
                    MenuCode = table.Column<string>(maxLength: 50, nullable: false),
                    MenuName = table.Column<string>(maxLength: 50, nullable: false),
                    MenuState = table.Column<bool>(nullable: false),
                    MenuType = table.Column<int>(nullable: false),
                    ParentId = table.Column<string>(maxLength: 36, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SortId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                    table.UniqueConstraint("AK_SysMenu_MenuCode", x => x.MenuCode);
                });

            migrationBuilder.CreateTable(
                name: "SysOperate",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    OptionCode = table.Column<string>(maxLength: 50, nullable: false),
                    OptionName = table.Column<string>(maxLength: 50, nullable: false),
                    SortId = table.Column<int>(nullable: true),
                    Style = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOperate", x => x.Id);
                    table.UniqueConstraint("AK_SysOperate_OptionCode", x => x.OptionCode);
                    table.UniqueConstraint("AK_SysOperate_OptionName", x => x.OptionName);
                });

            migrationBuilder.CreateTable(
                name: "SysRight",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    BizScope = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    ManagerScope = table.Column<string>(nullable: true),
                    MobileRight = table.Column<string>(nullable: true),
                    ModuleRight = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    IsSystem = table.Column<bool>(nullable: true),
                    MobileRight = table.Column<string>(nullable: true),
                    ModuleRight = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 50, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SortId = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                    table.UniqueConstraint("AK_SysRole_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 200, nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: true),
                    EmpBirth = table.Column<string>(maxLength: 10, nullable: true),
                    EmpName = table.Column<string>(maxLength: 50, nullable: true),
                    EmpNo = table.Column<string>(maxLength: 100, nullable: true),
                    EmpPinyin = table.Column<string>(maxLength: 50, nullable: true),
                    EmpSex = table.Column<string>(maxLength: 2, nullable: true),
                    IsSupper = table.Column<bool>(nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: true),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 36, nullable: true),
                    SortId = table.Column<int>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                    table.UniqueConstraint("AK_SysUser_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "SysLogDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 50, nullable: true),
                    LogId = table.Column<int>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 4000, nullable: true),
                    OperateType = table.Column<string>(maxLength: 50, nullable: true),
                    OriginalVal = table.Column<string>(maxLength: 4000, nullable: true),
                    TableName = table.Column<string>(maxLength: 56, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysLogDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysLogDetail_SysLog_LogId",
                        column: x => x.LogId,
                        principalTable: "SysLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(maxLength: 1000, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 1000, nullable: true),
                    RoleId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysRoleClaim_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(maxLength: 1000, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 1000, nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserClaim_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserDept",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    DeptId = table.Column<string>(maxLength: 36, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsMajor = table.Column<bool>(nullable: true),
                    JobState = table.Column<bool>(nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserDept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserDept_SysDept_DeptId",
                        column: x => x.DeptId,
                        principalTable: "SysDept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserDept_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(maxLength: 250, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 250, nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserLogin_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserRole",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    DeleteState = table.Column<int>(nullable: true),
                    IsMajor = table.Column<bool>(nullable: true),
                    RoleId = table.Column<string>(maxLength: 36, nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserRole_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(maxLength: 1000, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: false),
                    Value = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysUserToken_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysLogDetail_LogId",
                table: "SysLogDetail",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleClaim_RoleId",
                table: "SysRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserClaim_UserId",
                table: "SysUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserDept_DeptId",
                table: "SysUserDept",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserDept_UserId",
                table: "SysUserDept",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserLogin_UserId",
                table: "SysUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_RoleId",
                table: "SysUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRole_UserId",
                table: "SysUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserToken_UserId",
                table: "SysUserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysDictionary");

            migrationBuilder.DropTable(
                name: "SysLogDetail");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysOperate");

            migrationBuilder.DropTable(
                name: "SysRight");

            migrationBuilder.DropTable(
                name: "SysRoleClaim");

            migrationBuilder.DropTable(
                name: "SysUserClaim");

            migrationBuilder.DropTable(
                name: "SysUserDept");

            migrationBuilder.DropTable(
                name: "SysUserLogin");

            migrationBuilder.DropTable(
                name: "SysUserRole");

            migrationBuilder.DropTable(
                name: "SysUserToken");

            migrationBuilder.DropTable(
                name: "SysLog");

            migrationBuilder.DropTable(
                name: "SysDept");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysUser");
        }
    }
}
