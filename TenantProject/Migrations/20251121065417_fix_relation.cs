using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantProject.Migrations
{
    /// <inheritdoc />
    public partial class fix_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenant_tenant_booth_detail_tenant_type_id",
                table: "tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_tenant_space_detail_tenant_type_id",
                table: "tenant");

            migrationBuilder.DropIndex(
                name: "IX_tenant_tenant_type_id",
                table: "tenant");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_space_detail_tenant_id",
                table: "tenant_space_detail",
                column: "tenant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenant_booth_detail_tenant_id",
                table: "tenant_booth_detail",
                column: "tenant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenant_tenant_type_id",
                table: "tenant",
                column: "tenant_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_booth_detail_tenant_tenant_id",
                table: "tenant_booth_detail",
                column: "tenant_id",
                principalTable: "tenant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_space_detail_tenant_tenant_id",
                table: "tenant_space_detail",
                column: "tenant_id",
                principalTable: "tenant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenant_booth_detail_tenant_tenant_id",
                table: "tenant_booth_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_tenant_space_detail_tenant_tenant_id",
                table: "tenant_space_detail");

            migrationBuilder.DropIndex(
                name: "IX_tenant_space_detail_tenant_id",
                table: "tenant_space_detail");

            migrationBuilder.DropIndex(
                name: "IX_tenant_booth_detail_tenant_id",
                table: "tenant_booth_detail");

            migrationBuilder.DropIndex(
                name: "IX_tenant_tenant_type_id",
                table: "tenant");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_tenant_type_id",
                table: "tenant",
                column: "tenant_type_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_tenant_booth_detail_tenant_type_id",
                table: "tenant",
                column: "tenant_type_id",
                principalTable: "tenant_booth_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tenant_tenant_space_detail_tenant_type_id",
                table: "tenant",
                column: "tenant_type_id",
                principalTable: "tenant_space_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
