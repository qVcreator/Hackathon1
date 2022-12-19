using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UwULearn.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseProgressId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseProgress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriotion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    CourseProgressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskEntity_CourseProgress_CourseProgressId",
                        column: x => x.CourseProgressId,
                        principalTable: "CourseProgress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TaskId",
                table: "Lesson",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseProgressId",
                table: "Course",
                column: "CourseProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgress_UserId",
                table: "CourseProgress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntity_CourseProgressId",
                table: "TaskEntity",
                column: "CourseProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseProgress_CourseProgressId",
                table: "Course",
                column: "CourseProgressId",
                principalTable: "CourseProgress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_TaskEntity_TaskId",
                table: "Lesson",
                column: "TaskId",
                principalTable: "TaskEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseProgress_CourseProgressId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_TaskEntity_TaskId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "TaskEntity");

            migrationBuilder.DropTable(
                name: "CourseProgress");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_TaskId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseProgressId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "CourseProgressId",
                table: "Course");
        }
    }
}
