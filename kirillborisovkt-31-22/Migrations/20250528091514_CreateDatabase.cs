using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kirillborisovkt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "university");

            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                schema: "university",
                columns: table => new
                {
                    AcademicDegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_degree_id", x => x.AcademicDegreeId);
                },
                comment: "Ученые степени преподавателей");

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "university",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_position_id", x => x.PositionId);
                },
                comment: "Должности преподавателей");

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "university",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_id", x => x.SubjectId);
                },
                comment: "Дисциплины университета");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "university",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    HeadTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_department_id", x => x.DepartmentId);
                },
                comment: "Кафедры университета");

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "university",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AcademicDegreeId = table.Column<int>(type: "int", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teacher_id", x => x.TeacherId);
                    table.ForeignKey(
                        name: "fk_teacher_degree",
                        column: x => x.AcademicDegreeId,
                        principalSchema: "university",
                        principalTable: "AcademicDegrees",
                        principalColumn: "AcademicDegreeId");
                    table.ForeignKey(
                        name: "fk_teacher_department",
                        column: x => x.DepartmentId,
                        principalSchema: "university",
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_position",
                        column: x => x.PositionId,
                        principalSchema: "university",
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Преподаватели университета");

            migrationBuilder.CreateTable(
                name: "Workloads",
                schema: "university",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    WorkloadId = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workload_composite_id", x => new { x.TeacherId, x.SubjectId });
                    table.ForeignKey(
                        name: "fk_workload_subject",
                        column: x => x.SubjectId,
                        principalSchema: "university",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workload_teacher",
                        column: x => x.TeacherId,
                        principalSchema: "university",
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Учебная нагрузка");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadTeacherId",
                schema: "university",
                table: "Departments",
                column: "HeadTeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teacher_fullname",
                schema: "university",
                table: "Teachers",
                columns: new[] { "last_name", "first_name" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AcademicDegreeId",
                schema: "university",
                table: "Teachers",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentId",
                schema: "university",
                table: "Teachers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PositionId",
                schema: "university",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Workloads_SubjectId",
                schema: "university",
                table: "Workloads",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "fk_department_head_teacher",
                schema: "university",
                table: "Departments",
                column: "HeadTeacherId",
                principalSchema: "university",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_department_head_teacher",
                schema: "university",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Workloads",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "university");

            migrationBuilder.DropTable(
                name: "AcademicDegrees",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "university");
        }
    }
}
