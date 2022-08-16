using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrationManager.Migrations
{
    public partial class Added_celebrations_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "categoriesSeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "celebrationsSeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventTimesSeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "filesSeq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "workingTimesSeq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StartEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Celebrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventTimeId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Celebrations_EventTimes_EventTimeId",
                        column: x => x.EventTimeId,
                        principalTable: "EventTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelebrationsCategory",
                columns: table => new
                {
                    CelebrationId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrationsCategory", x => new { x.CategoryId, x.CelebrationId });
                    table.ForeignKey(
                        name: "FK_CelebrationsCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrationsCategory_Celebrations_CelebrationId",
                        column: x => x.CelebrationId,
                        principalTable: "Celebrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelebrationsWorkingTime",
                columns: table => new
                {
                    CelebrationId = table.Column<int>(type: "int", nullable: false),
                    WorkingTimeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebrationsWorkingTime", x => new { x.WorkingTimeId, x.CelebrationId });
                    table.ForeignKey(
                        name: "FK_CelebrationsWorkingTime_Celebrations_CelebrationId",
                        column: x => x.CelebrationId,
                        principalTable: "Celebrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelebrationsWorkingTime_WorkingTimes_WorkingTimeId",
                        column: x => x.WorkingTimeId,
                        principalTable: "WorkingTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CelebrationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Celebrations_CelebrationId",
                        column: x => x.CelebrationId,
                        principalTable: "Celebrations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celebrations_EventTimeId",
                table: "Celebrations",
                column: "EventTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrationsCategory_CelebrationId",
                table: "CelebrationsCategory",
                column: "CelebrationId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebrationsWorkingTime_CelebrationId",
                table: "CelebrationsWorkingTime",
                column: "CelebrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CelebrationId",
                table: "Files",
                column: "CelebrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelebrationsCategory");

            migrationBuilder.DropTable(
                name: "CelebrationsWorkingTime");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "WorkingTimes");

            migrationBuilder.DropTable(
                name: "Celebrations");

            migrationBuilder.DropTable(
                name: "EventTimes");

            migrationBuilder.DropSequence(
                name: "categoriesSeq");

            migrationBuilder.DropSequence(
                name: "celebrationsSeq");

            migrationBuilder.DropSequence(
                name: "eventTimesSeq");

            migrationBuilder.DropSequence(
                name: "filesSeq");

            migrationBuilder.DropSequence(
                name: "workingTimesSeq");
        }
    }
}
