using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDietPlanTotalsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_DietPlans_DietPlanId",
                table: "Meals");

            migrationBuilder.AlterColumn<double>(
                name: "TotalProtein",
                table: "Meals",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "TotalFat",
                table: "Meals",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCarbohydrate",
                table: "Meals",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCalories",
                table: "Meals",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "DietPlanId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCalories",
                table: "DietPlans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCarbohydrate",
                table: "DietPlans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalFat",
                table: "DietPlans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalProtein",
                table: "DietPlans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "DietPlans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_UserId",
                table: "DietPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlans_Users_UserId",
                table: "DietPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_DietPlans_DietPlanId",
                table: "Meals",
                column: "DietPlanId",
                principalTable: "DietPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlans_Users_UserId",
                table: "DietPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_DietPlans_DietPlanId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_DietPlans_UserId",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "TotalCalories",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "TotalCarbohydrate",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "TotalFat",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "TotalProtein",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DietPlans");

            migrationBuilder.AlterColumn<double>(
                name: "TotalProtein",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalFat",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalCarbohydrate",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalCalories",
                table: "Meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DietPlanId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_DietPlans_DietPlanId",
                table: "Meals",
                column: "DietPlanId",
                principalTable: "DietPlans",
                principalColumn: "Id");
        }
    }
}
