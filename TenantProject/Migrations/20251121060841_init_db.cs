using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TenantProject.Migrations
{
    /// <inheritdoc />
    public partial class init_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspnetroles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_booth_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    booth_num = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_booth_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_space_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_sm = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_space_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_type",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroleclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserlogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    providerkey = table.Column<string>(type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "FK_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserroles",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                columns: table => new
                {
                    userid = table.Column<string>(type: "text", nullable: false),
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "FK_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_name = table.Column<string>(type: "text", nullable: false),
                    tenant_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_phone = table.Column<string>(type: "text", nullable: false),
                    tenant_address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.id);
                    table.ForeignKey(
                        name: "FK_tenant_tenant_booth_detail_tenant_type_id",
                        column: x => x.tenant_type_id,
                        principalTable: "tenant_booth_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenant_tenant_space_detail_tenant_type_id",
                        column: x => x.tenant_type_id,
                        principalTable: "tenant_space_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tenant_tenant_type_tenant_type_id",
                        column: x => x.tenant_type_id,
                        principalTable: "tenant_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tenant_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("3b0b302a-72e9-4eae-856f-a6737756cb5b"), "Food Truck" },
                    { new Guid("8c815abe-4b51-4f86-80de-bff5cb6d5baa"), "Booth" },
                    { new Guid("cd285a19-b09d-4900-8ac8-154a95e9f69f"), "Space Only" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_aspnetroleclaims_roleid",
                table: "aspnetroleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "aspnetroles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserclaims_userid",
                table: "aspnetuserclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserlogins_userid",
                table: "aspnetuserlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuserroles_roleid",
                table: "aspnetuserroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "aspnetusers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "aspnetusers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenant_tenant_type_id",
                table: "tenant",
                column: "tenant_type_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnetroleclaims");

            migrationBuilder.DropTable(
                name: "aspnetuserclaims");

            migrationBuilder.DropTable(
                name: "aspnetuserlogins");

            migrationBuilder.DropTable(
                name: "aspnetuserroles");

            migrationBuilder.DropTable(
                name: "aspnetusertokens");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "aspnetroles");

            migrationBuilder.DropTable(
                name: "aspnetusers");

            migrationBuilder.DropTable(
                name: "tenant_booth_detail");

            migrationBuilder.DropTable(
                name: "tenant_space_detail");

            migrationBuilder.DropTable(
                name: "tenant_type");
        }
    }
}
