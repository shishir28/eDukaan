using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Monad.EDukaan.Service.Identity.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Monad.EDukaan.Service.Identity.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("00000000000000_CreateIdentitySchema")]
    public class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "ResourceType",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(maxLength: 255, nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),

               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ResourceType", x => x.Id);
               });

                migrationBuilder.CreateTable(
                name: "ApplicationResource",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(maxLength: 255, nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        ResourceTypeId = table.Column<int>(nullable: false),
                        CreatedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                        LastModifiedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                        LastModifiedBy = table.Column<int>(nullable: false)
                    },

                    constraints: table =>
                    {
                        table.PrimaryKey("PK_ApplicationResource", x => x.Id);
                        table.ForeignKey(
                                name: "ApplicationResource_ResourceType_ResourceTypeId",
                                column: x => x.ResourceTypeId,
                                principalTable: "ResourceType",
                                principalColumn: "Id");
                    });

                migrationBuilder.CreateTable(
                    name: "Activity",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Description = table.Column<string>(maxLength: 100, nullable: true),
                        Value = table.Column<string>(maxLength: 50, nullable: false),
                        ResourceTypeId = table.Column<int>(nullable: false),
                        CreatedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                        LastModifiedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                        LastModifiedBy = table.Column<int>(nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Activity", x => x.Id);
                        table.ForeignKey(
                           name: "Activity_ResourceType_ResourceTypeId",
                           column: x => x.ResourceTypeId,
                           principalTable: "ResourceType",
                           principalColumn: "Id");
                    });

                migrationBuilder.CreateTable(
                name: "ApplicationRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.Id);
                });

                migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Expiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

               migrationBuilder.CreateTable(
               name: "RoleRight",
               columns: table => new
               {
                   Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   ActivityId = table.Column<int>(nullable: false),
                   ApplicationResourceId = table.Column<int>(nullable: false),
                   CreatedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   LastModifiedDateUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                   LastModifiedBy = table.Column<int>(nullable: false),

               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_RoleRight", x => x.Id);
                   table.ForeignKey(
                          name: "RoleRight_ApplicationRole_ApplicationRoleId",
                          column: x => x.ApplicationRoleId,
                          principalTable: "ApplicationRole",
                          principalColumn: "Id");

                   table.ForeignKey(
                      name: "RoleRight_Activity_ActivityId",
                      column: x => x.ActivityId,
                      principalTable: "Activity",
                      principalColumn: "Id");

                   table.ForeignKey(
                       name: "RoleRight_ApplicationResource_ApplicationResourceId",
                       column: x => x.ApplicationResourceId,
                       principalTable: "ApplicationResource",
                       principalColumn: "Id");
               });


                migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                           name: "UserRole_ApplicationRole_ApplicationRoleId",
                           column: x => x.ApplicationRoleId,
                           principalTable: "ApplicationRole",
                           principalColumn: "Id");

                    table.ForeignKey(
                          name: "UserRole_ApplicationUser_ApplicationUserId",
                          column: x => x.ApplicationUserId,
                          principalTable: "ApplicationUser",
                          principalColumn: "Id");
                });

                migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                          name: "UserClaim_ApplicationUser_ApplicationUserId",
                          column: x => x.ApplicationUserId,
                          principalTable: "ApplicationUser",
                          principalColumn: "Id");
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "UserClaim");
            migrationBuilder.DropTable(name: "UserRole");
            migrationBuilder.DropTable(name: "RoleRight");
            migrationBuilder.DropTable(name: "ApplicationUser");
            migrationBuilder.DropTable(name: "ApplicationRole");
            migrationBuilder.DropTable(name: "Activity");
            migrationBuilder.DropTable(name: "ApplicationResource");
            migrationBuilder.DropTable(name: "ResourceType");

        }
    }
}
