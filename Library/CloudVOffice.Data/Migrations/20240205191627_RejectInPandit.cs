using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudVOffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class RejectInPandit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Reject",
                table: "PanditRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5238));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(5244));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 405, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 405, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 0, 46, 26, 404, DateTimeKind.Local).AddTicks(2666));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reject",
                table: "PanditRegistrations");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "ApplicationId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "RoleAndApplicationWisePermissions",
                keyColumn: "RoleAndApplicationWisePermissionId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 756, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "UserWiseViewMappers",
                keyColumn: "UserWiseViewMapperId",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 23, 45, 37, 757, DateTimeKind.Local).AddTicks(1293));
        }
    }
}
