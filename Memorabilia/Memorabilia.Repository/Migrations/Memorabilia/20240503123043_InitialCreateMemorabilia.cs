using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Memorabilia.Repository.Migrations.Memorabilia
{
    /// <inheritdoc />
    public partial class InitialCreateMemorabilia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acquisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcquiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcquiredWithAutograph = table.Column<bool>(type: "bit", nullable: true),
                    AcquisitionTypeId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    PurchaseTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingleLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvidence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningItemTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrivateSigningItemGroupId = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningItemTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportLeagueLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelTypeId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportLeagueLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripeSubscriptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionCanceled = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllStar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    SportLeagueLevelId = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllStar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllStar_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CareerRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareerRecord_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeRetiredNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeRetiredNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeRetiredNumber_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeRetiredNumber_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BallotNumber = table.Column<int>(type: "int", nullable: true),
                    InductionYear = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SportLeagueLevelId = table.Column<int>(type: "int", nullable: false),
                    VotePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallOfFame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HallOfFame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternationalHallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InductionYear = table.Column<int>(type: "int", nullable: true),
                    InternationalHallOfFameTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalHallOfFame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternationalHallOfFame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leader_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAccomplishment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomplishmentTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAccomplishment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAccomplishment_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonAward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwardTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAward_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonCollege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCollege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonCollege_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonNickname",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonNickname", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonNickname_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonOccupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationId = table.Column<int>(type: "int", nullable: false),
                    OccupationTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOccupation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonOccupation_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingleSeasonRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordTypeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleSeasonRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleSeasonRecord_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreeAgentSigningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAppearanceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportService_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughTheMail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SelfAddressedStampedEnvelopeTrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThroughTheMailFailureTypeId = table.Column<int>(type: "int", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughTheMail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughTheMail_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThroughTheMail_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPosition_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBaseball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseballTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBaseball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectBaseball_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCard_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectHallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SportLeagueLevelId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectHallOfFame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectHallOfFame_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectHelmet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelmetFinishId = table.Column<int>(type: "int", nullable: true),
                    HelmetTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectHelmet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectHelmet_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    MultiSignedItem = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItem_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeam_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorldSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorldSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectWorldSeries_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollegeHallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeHallOfFame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollegeHallOfFame_College_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "College",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeHallOfFame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollegeHallOfFame_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSport_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FoundYear = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportLeagueLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Franchise_SportLeagueLevel_SportLeagueLevelId",
                        column: x => x.SportLeagueLevelId,
                        principalTable: "SportLeagueLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumTopicUserBookmark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumTopicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopicUserBookmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumTopicUserBookmark_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memorabilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Denominator = table.Column<int>(type: "int", nullable: true),
                    ForTrade = table.Column<bool>(type: "bit", nullable: false),
                    Framed = table.Column<bool>(type: "bit", nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numerator = table.Column<int>(type: "int", nullable: true),
                    PrivacyTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memorabilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memorabilia_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoterImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfAddressedStampedEnvelopeAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SigningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionDeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigning_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningCustomItemGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningCustomItemGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningCustomItemGroup_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromoterProvidedItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    PromoterId = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoterProvidedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoterProvidedItem_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoterProvidedItem_User_PromoterId",
                        column: x => x.PromoterId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposeTrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountTradeCreatorToReceive = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    AmountTradeCreatorToSend = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProposeTradeStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    TradeCreatorUserId = table.Column<int>(type: "int", nullable: false),
                    TradePartnerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposeTrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposeTrade_User_TradeCreatorUserId",
                        column: x => x.TradeCreatorUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposeTrade_User_TradePartnerUserId",
                        column: x => x.TradePartnerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureIdentification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureIdentification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureIdentification_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureReview_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignatureReview_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDashboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DashboardItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDashboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDashboard_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    PaymentHandle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentOptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaymentOption_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MicrosoftEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    UseDarkTheme = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    XHandle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSettings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Handle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialMedia_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Draft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FranchiseId = table.Column<int>(type: "int", nullable: false),
                    Overall = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Pick = table.Column<int>(type: "int", nullable: true),
                    Round = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draft_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Draft_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FranchiseHallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FranchiseId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchiseHallOfFame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FranchiseHallOfFame_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FranchiseHallOfFame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetiredNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FranchiseId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PlayerNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetiredNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetiredNumber_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RetiredNumber_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcquisitionId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Denominator = table.Column<int>(type: "int", nullable: true),
                    EstimatedValue = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    FullName = table.Column<bool>(type: "bit", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numerator = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    WritingInstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autograph", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autograph_Acquisition_AcquisitionId",
                        column: x => x.AcquisitionId,
                        principalTable: "Acquisition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Autograph_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autograph_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionMemorabilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMemorabilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionMemorabilia_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionMemorabilia_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaAcquisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcquisitionId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaAcquisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaAcquisition_Acquisition_AcquisitionId",
                        column: x => x.AcquisitionId,
                        principalTable: "Acquisition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MemorabiliaAcquisition_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBammer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BammerTypeId = table.Column<int>(type: "int", nullable: true),
                    InPackage = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBammer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBammer_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBaseball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anniversary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseballTypeId = table.Column<int>(type: "int", nullable: false),
                    LeaguePresidentId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBaseball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBaseball_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBasketball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketballTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBasketball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBasketball_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatTypeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBat_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBobblehead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasBox = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBobblehead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBobblehead_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardCover = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBook_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaBrand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaBrand_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custom = table.Column<bool>(type: "bit", nullable: false),
                    Licensed = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    OrientationId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaCard_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaCereal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CerealTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaCereal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaCereal_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaCommissioner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionerId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaCommissioner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaCommissioner_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaFigure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FigureSpecialtyTypeId = table.Column<int>(type: "int", nullable: true),
                    FigureTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaFigure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaFigure_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaFirstDayCover",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaFirstDayCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaFirstDayCover_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaFootball",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaFootball", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaFootball_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaForSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowBestOffer = table.Column<bool>(type: "bit", nullable: false),
                    BuyNowPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    MinimumOfferPrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaForSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaForSale_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GameStyleTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaGame_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaGlove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GloveTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaGlove", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaGlove_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaHelmet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelmetFinishId = table.Column<int>(type: "int", nullable: true),
                    HelmetQualityTypeId = table.Column<int>(type: "int", nullable: true),
                    HelmetTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Throwback = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaHelmet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaHelmet_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTypeId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaImage_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaJersey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JerseyQualityTypeId = table.Column<int>(type: "int", nullable: false),
                    JerseyStyleTypeId = table.Column<int>(type: "int", nullable: false),
                    JerseyTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaJersey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaJersey_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaJerseyNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaJerseyNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaJerseyNumber_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaLevelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelTypeId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaLevelType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaLevelType_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaMagazine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Framed = table.Column<bool>(type: "bit", nullable: false),
                    Matted = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    OrientationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaMagazine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaMagazine_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaPerson_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorabiliaPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matted = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    OrientationId = table.Column<int>(type: "int", nullable: false),
                    PhotoTypeId = table.Column<int>(type: "int", nullable: true),
                    Stretched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaPicture_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaSize_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaSport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaSport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaSport_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorabiliaSport_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaTransactionSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaTransactionId = table.Column<int>(type: "int", nullable: false),
                    SaleAmount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaTransactionSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTransactionSale_MemorabiliaTransaction_MemorabiliaTransactionId",
                        column: x => x.MemorabiliaTransactionId,
                        principalTable: "MemorabiliaTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTransactionSale_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaTransactionTrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashIncludedAmount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    CashIncludedTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    MemorabiliaTransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionTradeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaTransactionTrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTransactionTrade_MemorabiliaTransaction_MemorabiliaTransactionId",
                        column: x => x.MemorabiliaTransactionId,
                        principalTable: "MemorabiliaTransaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTransactionTrade_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    BuyerUserId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferStatusTypeId = table.Column<int>(type: "int", nullable: false),
                    SellerUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_User_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offer_User_SellerUserId",
                        column: x => x.SellerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningAuthenticationCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthenticationCompanyId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrivateSigningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningAuthenticationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningAuthenticationCompany_PrivateSigning_PrivateSigningId",
                        column: x => x.PrivateSigningId,
                        principalTable: "PrivateSigning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowInscriptions = table.Column<bool>(type: "bit", nullable: false),
                    InscriptionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PrivateSigningId = table.Column<int>(type: "int", nullable: false),
                    PromoterImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpotsAvailable = table.Column<int>(type: "int", nullable: true),
                    SpotsConfirmed = table.Column<int>(type: "int", nullable: true),
                    SpotsReserved = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPerson_PrivateSigning_PrivateSigningId",
                        column: x => x.PrivateSigningId,
                        principalTable: "PrivateSigning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningCustomItemTypeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    PrivateSigningCustomItemGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningCustomItemTypeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningCustomItemTypeGroup_PrivateSigningCustomItemGroup_PrivateSigningCustomItemGroupId",
                        column: x => x.PrivateSigningCustomItemGroupId,
                        principalTable: "PrivateSigningCustomItemGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningCustomItemTypeGroupDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrivateSigningCustomItemGroupId = table.Column<int>(type: "int", nullable: true),
                    PrivateSigningCustomItemTypeGroupId = table.Column<int>(type: "int", nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningCustomItemTypeGroupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningCustomItemTypeGroupDetail_PrivateSigningCustomItemGroup_PrivateSigningCustomItemGroupId",
                        column: x => x.PrivateSigningCustomItemGroupId,
                        principalTable: "PrivateSigningCustomItemGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningPromoterProvidedItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivateSigningId = table.Column<int>(type: "int", nullable: false),
                    PromoterProvidedItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningPromoterProvidedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPromoterProvidedItem_PrivateSigning_PrivateSigningId",
                        column: x => x.PrivateSigningId,
                        principalTable: "PrivateSigning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPromoterProvidedItem_PromoterProvidedItem_PromoterProvidedItemId",
                        column: x => x.PromoterProvidedItemId,
                        principalTable: "PromoterProvidedItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposeTradeMemorabilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    ProposeTradeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposeTradeMemorabilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposeTradeMemorabilia_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposeTradeMemorabilia_ProposeTrade_ProposeTradeId",
                        column: x => x.ProposeTradeId,
                        principalTable: "ProposeTrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposeTradeMemorabilia_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureIdentificationImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureIdentificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureIdentificationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureIdentificationImage_SignatureIdentification_SignatureIdentificationId",
                        column: x => x.SignatureIdentificationId,
                        principalTable: "SignatureIdentification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureIdentificationPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SignatureIdentificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureIdentificationPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureIdentificationPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignatureIdentificationPerson_SignatureIdentification_SignatureIdentificationId",
                        column: x => x.SignatureIdentificationId,
                        principalTable: "SignatureIdentification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignatureIdentificationPerson_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureReviewImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureReviewImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureReviewImage_SignatureReview_SignatureReviewId",
                        column: x => x.SignatureReviewId,
                        principalTable: "SignatureReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignatureReviewUserResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureReviewId = table.Column<int>(type: "int", nullable: false),
                    SignatureReviewResultTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureReviewUserResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignatureReviewUserResult_SignatureReview_SignatureReviewId",
                        column: x => x.SignatureReviewId,
                        principalTable: "SignatureReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SignatureReviewUserResult_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Champion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionTypeId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champion_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemorabiliaTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorabiliaTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTeam_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemorabiliaTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TeamRoleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonTeam_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMemorabiliaTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatedCost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: true),
                    PriorityTypeId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectStatusTypeId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Upgrade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMemorabiliaTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectMemorabiliaTeam_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectMemorabiliaTeam_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMemorabiliaTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamConference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    ConferenceId = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamConference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamConference_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamDivision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDivision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamDivision_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamLeague",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginYear = table.Column<int>(type: "int", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLeague", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLeague_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutographAuthentication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthenticationCompanyId = table.Column<int>(type: "int", nullable: false),
                    AutographId = table.Column<int>(type: "int", nullable: false),
                    HasCertificationCard = table.Column<bool>(type: "bit", nullable: true),
                    HasHologram = table.Column<bool>(type: "bit", nullable: true),
                    HasLetter = table.Column<bool>(type: "bit", nullable: true),
                    Verification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Witnessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutographAuthentication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutographAuthentication_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutographImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTypeId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutographImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutographImage_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutographSpot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: false),
                    SpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutographSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutographSpot_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: false),
                    InscriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscriptionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscription_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personalization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personalization_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: true),
                    EstimatedCost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    ItemTypeId = table.Column<int>(type: "int", nullable: true),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PriorityTypeId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectStatusTypeId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Upgrade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPerson_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPerson_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThroughTheMailMemorabilia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutographId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    IsExtraReceived = table.Column<bool>(type: "bit", nullable: false),
                    MemorabiliaId = table.Column<int>(type: "int", nullable: false),
                    ThroughTheMailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThroughTheMailMemorabilia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThroughTheMailMemorabilia_Autograph_AutographId",
                        column: x => x.AutographId,
                        principalTable: "Autograph",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThroughTheMailMemorabilia_Memorabilia_MemorabiliaId",
                        column: x => x.MemorabiliaId,
                        principalTable: "Memorabilia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThroughTheMailMemorabilia_ThroughTheMail_ThroughTheMailId",
                        column: x => x.ThroughTheMailId,
                        principalTable: "ThroughTheMail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningPersonExcludeItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateSigningPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningPersonExcludeItemType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPersonExcludeItemType_PrivateSigningPerson_PrivateSigningPersonId",
                        column: x => x.PrivateSigningPersonId,
                        principalTable: "PrivateSigningPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSigningPersonDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateSigningCustomItemTypeGroupDetailId = table.Column<int>(type: "int", nullable: true),
                    PrivateSigningItemTypeGroupId = table.Column<int>(type: "int", nullable: true),
                    PrivateSigningPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSigningPersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSigningPersonDetail_PrivateSigningCustomItemTypeGroupDetail_PrivateSigningCustomItemTypeGroupDetailId",
                        column: x => x.PrivateSigningCustomItemTypeGroupDetailId,
                        principalTable: "PrivateSigningCustomItemTypeGroupDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateSigningPersonDetail_PrivateSigningItemTypeGroup_PrivateSigningItemTypeGroupId",
                        column: x => x.PrivateSigningItemTypeGroupId,
                        principalTable: "PrivateSigningItemTypeGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrivateSigningPersonDetail_PrivateSigningPerson_PrivateSigningPersonId",
                        column: x => x.PrivateSigningPersonId,
                        principalTable: "PrivateSigningPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllStar_PersonId",
                table: "AllStar",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Autograph_AcquisitionId",
                table: "Autograph",
                column: "AcquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Autograph_MemorabiliaId",
                table: "Autograph",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Autograph_PersonId",
                table: "Autograph",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AutographAuthentication_AutographId",
                table: "AutographAuthentication",
                column: "AutographId");

            migrationBuilder.CreateIndex(
                name: "IX_AutographImage_AutographId",
                table: "AutographImage",
                column: "AutographId");

            migrationBuilder.CreateIndex(
                name: "IX_AutographSpot_AutographId",
                table: "AutographSpot",
                column: "AutographId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CareerRecord_PersonId",
                table: "CareerRecord",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Champion_TeamId",
                table: "Champion",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMemorabilia_CollectionId",
                table: "CollectionMemorabilia",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMemorabilia_MemorabiliaId",
                table: "CollectionMemorabilia",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeHallOfFame_CollegeId",
                table: "CollegeHallOfFame",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeHallOfFame_PersonId",
                table: "CollegeHallOfFame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeHallOfFame_SportId",
                table: "CollegeHallOfFame",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeRetiredNumber_CollegeId",
                table: "CollegeRetiredNumber",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeRetiredNumber_PersonId",
                table: "CollegeRetiredNumber",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Draft_FranchiseId",
                table: "Draft",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Draft_PersonId",
                table: "Draft",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopicUserBookmark_UserId",
                table: "ForumTopicUserBookmark",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Franchise_SportLeagueLevelId",
                table: "Franchise",
                column: "SportLeagueLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseHallOfFame_FranchiseId",
                table: "FranchiseHallOfFame",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseHallOfFame_PersonId",
                table: "FranchiseHallOfFame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HallOfFame_PersonId",
                table: "HallOfFame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_AutographId",
                table: "Inscription",
                column: "AutographId");

            migrationBuilder.CreateIndex(
                name: "IX_InternationalHallOfFame_PersonId",
                table: "InternationalHallOfFame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Leader_PersonId",
                table: "Leader",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Memorabilia_UserId",
                table: "Memorabilia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaAcquisition_AcquisitionId",
                table: "MemorabiliaAcquisition",
                column: "AcquisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaAcquisition_MemorabiliaId",
                table: "MemorabiliaAcquisition",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBammer_MemorabiliaId",
                table: "MemorabiliaBammer",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBaseball_MemorabiliaId",
                table: "MemorabiliaBaseball",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBasketball_MemorabiliaId",
                table: "MemorabiliaBasketball",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBat_MemorabiliaId",
                table: "MemorabiliaBat",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBobblehead_MemorabiliaId",
                table: "MemorabiliaBobblehead",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBook_MemorabiliaId",
                table: "MemorabiliaBook",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaBrand_MemorabiliaId",
                table: "MemorabiliaBrand",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaCard_MemorabiliaId",
                table: "MemorabiliaCard",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaCereal_MemorabiliaId",
                table: "MemorabiliaCereal",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaCommissioner_MemorabiliaId",
                table: "MemorabiliaCommissioner",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaFigure_MemorabiliaId",
                table: "MemorabiliaFigure",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaFirstDayCover_MemorabiliaId",
                table: "MemorabiliaFirstDayCover",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaFootball_MemorabiliaId",
                table: "MemorabiliaFootball",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaForSale_MemorabiliaId",
                table: "MemorabiliaForSale",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaGame_MemorabiliaId",
                table: "MemorabiliaGame",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaGlove_MemorabiliaId",
                table: "MemorabiliaGlove",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaHelmet_MemorabiliaId",
                table: "MemorabiliaHelmet",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaImage_MemorabiliaId",
                table: "MemorabiliaImage",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaJersey_MemorabiliaId",
                table: "MemorabiliaJersey",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaJerseyNumber_MemorabiliaId",
                table: "MemorabiliaJerseyNumber",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaLevelType_MemorabiliaId",
                table: "MemorabiliaLevelType",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaMagazine_MemorabiliaId",
                table: "MemorabiliaMagazine",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaPerson_MemorabiliaId",
                table: "MemorabiliaPerson",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaPerson_PersonId",
                table: "MemorabiliaPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaPicture_MemorabiliaId",
                table: "MemorabiliaPicture",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaSize_MemorabiliaId",
                table: "MemorabiliaSize",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaSport_MemorabiliaId",
                table: "MemorabiliaSport",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaSport_SportId",
                table: "MemorabiliaSport",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTeam_MemorabiliaId",
                table: "MemorabiliaTeam",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTeam_TeamId",
                table: "MemorabiliaTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTransactionSale_MemorabiliaId",
                table: "MemorabiliaTransactionSale",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTransactionSale_MemorabiliaTransactionId",
                table: "MemorabiliaTransactionSale",
                column: "MemorabiliaTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTransactionTrade_MemorabiliaId",
                table: "MemorabiliaTransactionTrade",
                column: "MemorabiliaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemorabiliaTransactionTrade_MemorabiliaTransactionId",
                table: "MemorabiliaTransactionTrade",
                column: "MemorabiliaTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_BuyerUserId",
                table: "Offer",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_MemorabiliaId",
                table: "Offer",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SellerUserId",
                table: "Offer",
                column: "SellerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAccomplishment_PersonId",
                table: "PersonAccomplishment",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personalization_AutographId",
                table: "Personalization",
                column: "AutographId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonAward_PersonId",
                table: "PersonAward",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCollege_PersonId",
                table: "PersonCollege",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonNickname_PersonId",
                table: "PersonNickname",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOccupation_PersonId",
                table: "PersonOccupation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPosition_PersonId",
                table: "PersonPosition",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPosition_PositionId",
                table: "PersonPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSport_PersonId",
                table: "PersonSport",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSport_SportId",
                table: "PersonSport",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeam_PersonId",
                table: "PersonTeam",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeam_TeamId",
                table: "PersonTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigning_CreatedUserId",
                table: "PrivateSigning",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningAuthenticationCompany_PrivateSigningId",
                table: "PrivateSigningAuthenticationCompany",
                column: "PrivateSigningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningCustomItemGroup_CreatedByUserId",
                table: "PrivateSigningCustomItemGroup",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningCustomItemTypeGroup_PrivateSigningCustomItemGroupId",
                table: "PrivateSigningCustomItemTypeGroup",
                column: "PrivateSigningCustomItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningCustomItemTypeGroupDetail_PrivateSigningCustomItemGroupId",
                table: "PrivateSigningCustomItemTypeGroupDetail",
                column: "PrivateSigningCustomItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPerson_PersonId",
                table: "PrivateSigningPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPerson_PrivateSigningId",
                table: "PrivateSigningPerson",
                column: "PrivateSigningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPersonDetail_PrivateSigningCustomItemTypeGroupDetailId",
                table: "PrivateSigningPersonDetail",
                column: "PrivateSigningCustomItemTypeGroupDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPersonDetail_PrivateSigningItemTypeGroupId",
                table: "PrivateSigningPersonDetail",
                column: "PrivateSigningItemTypeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPersonDetail_PrivateSigningPersonId",
                table: "PrivateSigningPersonDetail",
                column: "PrivateSigningPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPersonExcludeItemType_PrivateSigningPersonId",
                table: "PrivateSigningPersonExcludeItemType",
                column: "PrivateSigningPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPromoterProvidedItem_PrivateSigningId",
                table: "PrivateSigningPromoterProvidedItem",
                column: "PrivateSigningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSigningPromoterProvidedItem_PromoterProvidedItemId",
                table: "PrivateSigningPromoterProvidedItem",
                column: "PromoterProvidedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBaseball_ProjectId",
                table: "ProjectBaseball",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCard_ProjectId",
                table: "ProjectCard",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectHallOfFame_ProjectId",
                table: "ProjectHallOfFame",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectHelmet_ProjectId",
                table: "ProjectHelmet",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItem_ProjectId",
                table: "ProjectItem",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemorabiliaTeam_MemorabiliaId",
                table: "ProjectMemorabiliaTeam",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemorabiliaTeam_ProjectId",
                table: "ProjectMemorabiliaTeam",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMemorabiliaTeam_TeamId",
                table: "ProjectMemorabiliaTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_AutographId",
                table: "ProjectPerson",
                column: "AutographId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_PersonId",
                table: "ProjectPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectId",
                table: "ProjectPerson",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeam_ProjectId",
                table: "ProjectTeam",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorldSeries_ProjectId",
                table: "ProjectWorldSeries",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromoterProvidedItem_ItemTypeId",
                table: "PromoterProvidedItem",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoterProvidedItem_PromoterId",
                table: "PromoterProvidedItem",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposeTrade_TradeCreatorUserId",
                table: "ProposeTrade",
                column: "TradeCreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposeTrade_TradePartnerUserId",
                table: "ProposeTrade",
                column: "TradePartnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposeTradeMemorabilia_MemorabiliaId",
                table: "ProposeTradeMemorabilia",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposeTradeMemorabilia_ProposeTradeId",
                table: "ProposeTradeMemorabilia",
                column: "ProposeTradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposeTradeMemorabilia_UserId",
                table: "ProposeTradeMemorabilia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RetiredNumber_FranchiseId",
                table: "RetiredNumber",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_RetiredNumber_PersonId",
                table: "RetiredNumber",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureIdentification_CreatedUserId",
                table: "SignatureIdentification",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureIdentificationImage_SignatureIdentificationId",
                table: "SignatureIdentificationImage",
                column: "SignatureIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureIdentificationPerson_CreatedUserId",
                table: "SignatureIdentificationPerson",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureIdentificationPerson_PersonId",
                table: "SignatureIdentificationPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureIdentificationPerson_SignatureIdentificationId",
                table: "SignatureIdentificationPerson",
                column: "SignatureIdentificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureReview_CreatedUserId",
                table: "SignatureReview",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureReview_PersonId",
                table: "SignatureReview",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureReviewImage_SignatureReviewId",
                table: "SignatureReviewImage",
                column: "SignatureReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureReviewUserResult_CreatedUserId",
                table: "SignatureReviewUserResult",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureReviewUserResult_SignatureReviewId",
                table: "SignatureReviewUserResult",
                column: "SignatureReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleSeasonRecord_PersonId",
                table: "SingleSeasonRecord",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SportService_PersonId",
                table: "SportService",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_FranchiseId",
                table: "Team",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamConference_TeamId",
                table: "TeamConference",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamDivision_TeamId",
                table: "TeamDivision",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLeague_TeamId",
                table: "TeamLeague",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughTheMail_AddressId",
                table: "ThroughTheMail",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughTheMail_PersonId",
                table: "ThroughTheMail",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughTheMailMemorabilia_AutographId",
                table: "ThroughTheMailMemorabilia",
                column: "AutographId",
                unique: true,
                filter: "[AutographId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughTheMailMemorabilia_MemorabiliaId",
                table: "ThroughTheMailMemorabilia",
                column: "MemorabiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_ThroughTheMailMemorabilia_ThroughTheMailId",
                table: "ThroughTheMailMemorabilia",
                column: "ThroughTheMailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDashboard_UserId",
                table: "UserDashboard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentOption_UserId",
                table: "UserPaymentOption",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_ShippingAddressId",
                table: "UserSettings",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMedia_UserId",
                table: "UserSocialMedia",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllStar");

            migrationBuilder.DropTable(
                name: "AutographAuthentication");

            migrationBuilder.DropTable(
                name: "AutographImage");

            migrationBuilder.DropTable(
                name: "AutographSpot");

            migrationBuilder.DropTable(
                name: "CareerRecord");

            migrationBuilder.DropTable(
                name: "Champion");

            migrationBuilder.DropTable(
                name: "CollectionMemorabilia");

            migrationBuilder.DropTable(
                name: "CollegeHallOfFame");

            migrationBuilder.DropTable(
                name: "CollegeRetiredNumber");

            migrationBuilder.DropTable(
                name: "Draft");

            migrationBuilder.DropTable(
                name: "ForumTopicUserBookmark");

            migrationBuilder.DropTable(
                name: "FranchiseHallOfFame");

            migrationBuilder.DropTable(
                name: "HallOfFame");

            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "InternationalHallOfFame");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "MemorabiliaAcquisition");

            migrationBuilder.DropTable(
                name: "MemorabiliaBammer");

            migrationBuilder.DropTable(
                name: "MemorabiliaBaseball");

            migrationBuilder.DropTable(
                name: "MemorabiliaBasketball");

            migrationBuilder.DropTable(
                name: "MemorabiliaBat");

            migrationBuilder.DropTable(
                name: "MemorabiliaBobblehead");

            migrationBuilder.DropTable(
                name: "MemorabiliaBook");

            migrationBuilder.DropTable(
                name: "MemorabiliaBrand");

            migrationBuilder.DropTable(
                name: "MemorabiliaCard");

            migrationBuilder.DropTable(
                name: "MemorabiliaCereal");

            migrationBuilder.DropTable(
                name: "MemorabiliaCommissioner");

            migrationBuilder.DropTable(
                name: "MemorabiliaFigure");

            migrationBuilder.DropTable(
                name: "MemorabiliaFirstDayCover");

            migrationBuilder.DropTable(
                name: "MemorabiliaFootball");

            migrationBuilder.DropTable(
                name: "MemorabiliaForSale");

            migrationBuilder.DropTable(
                name: "MemorabiliaGame");

            migrationBuilder.DropTable(
                name: "MemorabiliaGlove");

            migrationBuilder.DropTable(
                name: "MemorabiliaHelmet");

            migrationBuilder.DropTable(
                name: "MemorabiliaImage");

            migrationBuilder.DropTable(
                name: "MemorabiliaJersey");

            migrationBuilder.DropTable(
                name: "MemorabiliaJerseyNumber");

            migrationBuilder.DropTable(
                name: "MemorabiliaLevelType");

            migrationBuilder.DropTable(
                name: "MemorabiliaMagazine");

            migrationBuilder.DropTable(
                name: "MemorabiliaPerson");

            migrationBuilder.DropTable(
                name: "MemorabiliaPicture");

            migrationBuilder.DropTable(
                name: "MemorabiliaSize");

            migrationBuilder.DropTable(
                name: "MemorabiliaSport");

            migrationBuilder.DropTable(
                name: "MemorabiliaTeam");

            migrationBuilder.DropTable(
                name: "MemorabiliaTransactionSale");

            migrationBuilder.DropTable(
                name: "MemorabiliaTransactionTrade");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "PersonAccomplishment");

            migrationBuilder.DropTable(
                name: "Personalization");

            migrationBuilder.DropTable(
                name: "PersonAward");

            migrationBuilder.DropTable(
                name: "PersonCollege");

            migrationBuilder.DropTable(
                name: "PersonNickname");

            migrationBuilder.DropTable(
                name: "PersonOccupation");

            migrationBuilder.DropTable(
                name: "PersonPosition");

            migrationBuilder.DropTable(
                name: "PersonSport");

            migrationBuilder.DropTable(
                name: "PersonTeam");

            migrationBuilder.DropTable(
                name: "PrivateSigningAuthenticationCompany");

            migrationBuilder.DropTable(
                name: "PrivateSigningCustomItemTypeGroup");

            migrationBuilder.DropTable(
                name: "PrivateSigningPersonDetail");

            migrationBuilder.DropTable(
                name: "PrivateSigningPersonExcludeItemType");

            migrationBuilder.DropTable(
                name: "PrivateSigningPromoterProvidedItem");

            migrationBuilder.DropTable(
                name: "ProjectBaseball");

            migrationBuilder.DropTable(
                name: "ProjectCard");

            migrationBuilder.DropTable(
                name: "ProjectHallOfFame");

            migrationBuilder.DropTable(
                name: "ProjectHelmet");

            migrationBuilder.DropTable(
                name: "ProjectItem");

            migrationBuilder.DropTable(
                name: "ProjectMemorabiliaTeam");

            migrationBuilder.DropTable(
                name: "ProjectPerson");

            migrationBuilder.DropTable(
                name: "ProjectTeam");

            migrationBuilder.DropTable(
                name: "ProjectWorldSeries");

            migrationBuilder.DropTable(
                name: "ProposeTradeMemorabilia");

            migrationBuilder.DropTable(
                name: "RetiredNumber");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SignatureIdentificationImage");

            migrationBuilder.DropTable(
                name: "SignatureIdentificationPerson");

            migrationBuilder.DropTable(
                name: "SignatureReviewImage");

            migrationBuilder.DropTable(
                name: "SignatureReviewUserResult");

            migrationBuilder.DropTable(
                name: "SingleSeasonRecord");

            migrationBuilder.DropTable(
                name: "SportService");

            migrationBuilder.DropTable(
                name: "TeamConference");

            migrationBuilder.DropTable(
                name: "TeamDivision");

            migrationBuilder.DropTable(
                name: "TeamLeague");

            migrationBuilder.DropTable(
                name: "ThroughTheMailMemorabilia");

            migrationBuilder.DropTable(
                name: "UserDashboard");

            migrationBuilder.DropTable(
                name: "UserPaymentOption");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserSocialMedia");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "MemorabiliaTransaction");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "PrivateSigningCustomItemTypeGroupDetail");

            migrationBuilder.DropTable(
                name: "PrivateSigningItemTypeGroup");

            migrationBuilder.DropTable(
                name: "PrivateSigningPerson");

            migrationBuilder.DropTable(
                name: "PromoterProvidedItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProposeTrade");

            migrationBuilder.DropTable(
                name: "SignatureIdentification");

            migrationBuilder.DropTable(
                name: "SignatureReview");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Autograph");

            migrationBuilder.DropTable(
                name: "ThroughTheMail");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "PrivateSigningCustomItemGroup");

            migrationBuilder.DropTable(
                name: "PrivateSigning");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "Acquisition");

            migrationBuilder.DropTable(
                name: "Memorabilia");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "SportLeagueLevel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
