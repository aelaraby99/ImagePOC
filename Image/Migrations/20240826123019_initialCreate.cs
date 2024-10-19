using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Image.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Images" ,
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)" , nullable: false)
                        .Annotation("Oracle:Identity" , "START WITH 1 INCREMENT BY 1") ,
                    MyImage = table.Column<byte []>(type: "BLOB" , nullable: false)
                } ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images" , x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
