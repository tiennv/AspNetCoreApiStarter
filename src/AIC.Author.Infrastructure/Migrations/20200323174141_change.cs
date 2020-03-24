using Microsoft.EntityFrameworkCore.Migrations;

namespace AIC.Author.Infrastructure.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MP_RoleClaims_MP_Roles_RoleId",
                table: "MP_RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MP_UserClaims_MP_Users_UserId",
                table: "MP_UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_MP_UserLogins_MP_Users_UserId",
                table: "MP_UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_MP_UserRoles_MP_Roles_RoleId",
                table: "MP_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MP_UserRoles_MP_Users_UserId",
                table: "MP_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MP_UserTokens_MP_Users_UserId",
                table: "MP_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_UserTokens",
                table: "MP_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_Users",
                table: "MP_Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_UserRoles",
                table: "MP_UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_UserLogins",
                table: "MP_UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_UserClaims",
                table: "MP_UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_Roles",
                table: "MP_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MP_RoleClaims",
                table: "MP_RoleClaims");

            migrationBuilder.RenameTable(
                name: "MP_UserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "MP_Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "MP_UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "MP_UserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "MP_UserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "MP_Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "MP_RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_MP_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_MP_UserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MP_UserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MP_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "MP_UserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "MP_Users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "MP_UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "MP_UserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "MP_UserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "MP_Roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "MP_RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "MP_UserRoles",
                newName: "IX_MP_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "MP_UserLogins",
                newName: "IX_MP_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "MP_UserClaims",
                newName: "IX_MP_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "MP_RoleClaims",
                newName: "IX_MP_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_UserTokens",
                table: "MP_UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_Users",
                table: "MP_Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_UserRoles",
                table: "MP_UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_UserLogins",
                table: "MP_UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_UserClaims",
                table: "MP_UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_Roles",
                table: "MP_Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MP_RoleClaims",
                table: "MP_RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MP_RoleClaims_MP_Roles_RoleId",
                table: "MP_RoleClaims",
                column: "RoleId",
                principalTable: "MP_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MP_UserClaims_MP_Users_UserId",
                table: "MP_UserClaims",
                column: "UserId",
                principalTable: "MP_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MP_UserLogins_MP_Users_UserId",
                table: "MP_UserLogins",
                column: "UserId",
                principalTable: "MP_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MP_UserRoles_MP_Roles_RoleId",
                table: "MP_UserRoles",
                column: "RoleId",
                principalTable: "MP_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MP_UserRoles_MP_Users_UserId",
                table: "MP_UserRoles",
                column: "UserId",
                principalTable: "MP_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MP_UserTokens_MP_Users_UserId",
                table: "MP_UserTokens",
                column: "UserId",
                principalTable: "MP_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
