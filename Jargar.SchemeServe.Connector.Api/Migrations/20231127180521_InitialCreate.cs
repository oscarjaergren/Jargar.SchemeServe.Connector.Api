using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jargar.SchemeServe.Connector.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<string>(type: "TEXT", nullable: false),
                    LocationIds = table.Column<string>(type: "TEXT", nullable: false),
                    OrganisationType = table.Column<string>(type: "TEXT", nullable: false),
                    OwnershipType = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BrandId = table.Column<string>(type: "TEXT", nullable: false),
                    BrandName = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompaniesHouseNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CharityNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    PostalAddressLine1 = table.Column<string>(type: "TEXT", nullable: false),
                    PostalAddressLine2 = table.Column<string>(type: "TEXT", nullable: false),
                    PostalAddressTownCity = table.Column<string>(type: "TEXT", nullable: false),
                    PostalAddressCounty = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Uprn = table.Column<string>(type: "TEXT", nullable: false),
                    OnspdLatitude = table.Column<double>(type: "REAL", nullable: false),
                    OnspdLongitude = table.Column<double>(type: "REAL", nullable: false),
                    MainPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    InspectionDirectorate = table.Column<string>(type: "TEXT", nullable: false),
                    Constituency = table.Column<string>(type: "TEXT", nullable: false),
                    LocalAuthority = table.Column<string>(type: "TEXT", nullable: false),
                    CacheExpiration = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "LastInspections",
                columns: table => new
                {
                    ProviderId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastInspections", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_LastInspections_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastInspections");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
