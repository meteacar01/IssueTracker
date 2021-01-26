using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IssueTracker.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iteration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iteration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    WorkItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IterationId = table.Column<int>(type: "integer", nullable: false),
                    AssignedTo = table.Column<int>(type: "integer", nullable: false),
                    WorkItemStateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_Iteration_IterationId",
                        column: x => x.IterationId,
                        principalTable: "Iteration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItemState_WorkItemStateId",
                        column: x => x.WorkItemStateId,
                        principalTable: "WorkItemState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItemType_WorkItemTypeId",
                        column: x => x.WorkItemTypeId,
                        principalTable: "WorkItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkItemId = table.Column<int>(type: "integer", nullable: false),
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItemComments_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkItemComments_WorkItem_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Iteration",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Iteration 1" },
                    { 2, "Iteration 2" },
                    { 3, "Iteration 3" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 26, 18, 13, 38, 881, DateTimeKind.Local).AddTicks(4209), "meteacar01" },
                    { 2, new DateTime(2021, 1, 26, 18, 13, 38, 883, DateTimeKind.Local).AddTicks(2800), "duyguacar01" }
                });

            migrationBuilder.InsertData(
                table: "WorkItemState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "WorkItemType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bug" },
                    { 2, "Feature" },
                    { 3, "Task" },
                    { 4, "Epic" },
                    { 5, "Issue" },
                    { 6, "Test Case" },
                    { 7, "User Story" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_IterationId",
                table: "WorkItem",
                column: "IterationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_WorkItemStateId",
                table: "WorkItem",
                column: "WorkItemStateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_WorkItemTypeId",
                table: "WorkItem",
                column: "WorkItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_CommentId",
                table: "WorkItemComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComments_WorkItemId",
                table: "WorkItemComments",
                column: "WorkItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WorkItemComments");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "Iteration");

            migrationBuilder.DropTable(
                name: "WorkItemState");

            migrationBuilder.DropTable(
                name: "WorkItemType");
        }
    }
}
