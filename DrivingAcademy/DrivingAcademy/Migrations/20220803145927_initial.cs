using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingAcademy.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableLicences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableLicences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameModule = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<short>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Identification = table.Column<string>(type: "TEXT", nullable: false),
                    TypeLicenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableStudents_TableLicences_TypeLicenceId",
                        column: x => x.TypeLicenceId,
                        principalTable: "TableLicences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameLesson = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableLessons_TableModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "TableModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableDetails",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDetails", x => new { x.StudentId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_TableDetails_TableLessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "TableLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableDetails_TableStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "TableStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 1, "A1" });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 2, "A2" });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 3, "B1" });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 4, "B2" });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 5, "C1" });

            migrationBuilder.InsertData(
                table: "TableLicences",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { 6, "C2" });

            migrationBuilder.InsertData(
                table: "TableModules",
                columns: new[] { "Id", "NameModule" },
                values: new object[] { 1, "Adaptación" });

            migrationBuilder.InsertData(
                table: "TableModules",
                columns: new[] { "Id", "NameModule" },
                values: new object[] { 2, "Ética" });

            migrationBuilder.InsertData(
                table: "TableModules",
                columns: new[] { "Id", "NameModule" },
                values: new object[] { 3, "Marco Legal" });

            migrationBuilder.InsertData(
                table: "TableLessons",
                columns: new[] { "Id", "ModuleId", "NameLesson" },
                values: new object[] { 1, 1, "adaptación 1" });

            migrationBuilder.InsertData(
                table: "TableLessons",
                columns: new[] { "Id", "ModuleId", "NameLesson" },
                values: new object[] { 2, 1, "adaptación 2" });

            migrationBuilder.InsertData(
                table: "TableLessons",
                columns: new[] { "Id", "ModuleId", "NameLesson" },
                values: new object[] { 3, 2, "Ética 1" });

            migrationBuilder.InsertData(
                table: "TableLessons",
                columns: new[] { "Id", "ModuleId", "NameLesson" },
                values: new object[] { 4, 2, "Ética 2" });

            migrationBuilder.InsertData(
                table: "TableStudents",
                columns: new[] { "Id", "Age", "Identification", "Name", "TypeLicenceId" },
                values: new object[] { 1, (short)23, "1030692100", "Diego Molina", 1 });

            migrationBuilder.InsertData(
                table: "TableStudents",
                columns: new[] { "Id", "Age", "Identification", "Name", "TypeLicenceId" },
                values: new object[] { 2, (short)25, "1039139838", "Laura Molina", 2 });

            migrationBuilder.InsertData(
                table: "TableDetails",
                columns: new[] { "LessonId", "StudentId", "Active" },
                values: new object[] { 1, 1, true });

            migrationBuilder.InsertData(
                table: "TableDetails",
                columns: new[] { "LessonId", "StudentId", "Active" },
                values: new object[] { 3, 1, true });

            migrationBuilder.InsertData(
                table: "TableDetails",
                columns: new[] { "LessonId", "StudentId", "Active" },
                values: new object[] { 2, 2, true });

            migrationBuilder.InsertData(
                table: "TableDetails",
                columns: new[] { "LessonId", "StudentId", "Active" },
                values: new object[] { 4, 2, true });

            migrationBuilder.CreateIndex(
                name: "IX_TableDetails_LessonId",
                table: "TableDetails",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TableLessons_ModuleId",
                table: "TableLessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TableStudents_Identification",
                table: "TableStudents",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableStudents_TypeLicenceId",
                table: "TableStudents",
                column: "TypeLicenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableDetails");

            migrationBuilder.DropTable(
                name: "TableLessons");

            migrationBuilder.DropTable(
                name: "TableStudents");

            migrationBuilder.DropTable(
                name: "TableModules");

            migrationBuilder.DropTable(
                name: "TableLicences");
        }
    }
}
