using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OrigamiEdu.Migrations
{
    public partial class db48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kabupatenKotaDumps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    kabupatenKota = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kabupatenKotaDumps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "kategoriSekolahs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    namaKategori = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriSekolahs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "kategoriUniversitas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    katgUniv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriUniversitas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "provinsiDumps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    provinsi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinsiDumps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provinsis",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    provinsi = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sekolahDumps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    sekolah = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sekolahDumps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "universitasDumps",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    universitas = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universitasDumps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KabupatenKotas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    kabupatenKota = table.Column<string>(type: "Varchar(50)", nullable: false),
                    fkProvinsiID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KabupatenKotas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KabupatenKotas_Provinsis_fkProvinsiID",
                        column: x => x.fkProvinsiID,
                        principalTable: "Provinsis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "universitas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    universitas = table.Column<string>(type: "text", nullable: false),
                    fkProvinsiID = table.Column<Guid>(type: "uuid", nullable: true),
                    fkKategoriUniversitasID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universitas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_universitas_kategoriUniversitas_fkKategoriUniversitasID",
                        column: x => x.fkKategoriUniversitasID,
                        principalTable: "kategoriUniversitas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_universitas_Provinsis_fkProvinsiID",
                        column: x => x.fkProvinsiID,
                        principalTable: "Provinsis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sekolahs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    sekolah = table.Column<string>(type: "text", nullable: false),
                    fkKabupatenKotaID = table.Column<Guid>(type: "uuid", nullable: true),
                    fkKategoriSekolahID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sekolahs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sekolahs_KabupatenKotas_fkKabupatenKotaID",
                        column: x => x.fkKabupatenKotaID,
                        principalTable: "KabupatenKotas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sekolahs_kategoriSekolahs_fkKategoriSekolahID",
                        column: x => x.fkKategoriSekolahID,
                        principalTable: "kategoriSekolahs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statistikUnivs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    fkUnivID = table.Column<Guid>(type: "uuid", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false),
                    peminat = table.Column<double>(type: "double precision", nullable: false),
                    kuota = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistikUnivs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_statistikUnivs_universitas_fkUnivID",
                        column: x => x.fkUnivID,
                        principalTable: "universitas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    isBanned = table.Column<bool>(type: "boolean", nullable: false),
                    bannedUntil = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    joinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: true),
                    fkSekolahID = table.Column<Guid>(type: "uuid", nullable: true),
                    jurusanSekolah = table.Column<string>(type: "text", nullable: true),
                    tryOutTokens = table.Column<double>(type: "double precision", nullable: false),
                    isSetupInProgress = table.Column<bool>(type: "boolean", nullable: false),
                    setupType = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Sekolahs_fkSekolahID",
                        column: x => x.fkSekolahID,
                        principalTable: "Sekolahs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adminNotifications",
                columns: table => new
                {
                    adminId = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isSeen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_adminNotifications_AspNetUsers_adminId",
                        column: x => x.adminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kelas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    nama = table.Column<string>(type: "varchar(60)", nullable: false),
                    fkCreatorId = table.Column<string>(type: "text", nullable: true),
                    userGuide = table.Column<string>(type: "text", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isArchived = table.Column<bool>(type: "boolean", nullable: false),
                    isPrivate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kelas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kelas_AspNetUsers_fkCreatorId",
                        column: x => x.fkCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    userId = table.Column<string>(type: "text", nullable: true),
                    unameInvolved = table.Column<string[]>(type: "text[]", nullable: true),
                    info = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isSeen = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_notifications_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classParticipants",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    fkKelasID = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    accountId = table.Column<string>(type: "text", nullable: true),
                    isBannedToPost = table.Column<bool>(type: "boolean", nullable: false),
                    bannedUntil = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isCreator = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classParticipants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_classParticipants_AspNetUsers_accountId",
                        column: x => x.accountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classParticipants_kelas_fkKelasID",
                        column: x => x.fkKelasID,
                        principalTable: "kelas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dumpedUserFromClasses",
                columns: table => new
                {
                    accountId = table.Column<string>(type: "text", nullable: true),
                    fkkelasID = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true),
                    banUntil = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_dumpedUserFromClasses_AspNetUsers_accountId",
                        column: x => x.accountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dumpedUserFromClasses_kelas_fkkelasID",
                        column: x => x.fkkelasID,
                        principalTable: "kelas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adminNotifications_adminId",
                table: "adminNotifications",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_fkSekolahID",
                table: "AspNetUsers",
                column: "fkSekolahID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_classParticipants_accountId",
                table: "classParticipants",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_classParticipants_fkKelasID",
                table: "classParticipants",
                column: "fkKelasID");

            migrationBuilder.CreateIndex(
                name: "IX_dumpedUserFromClasses_accountId",
                table: "dumpedUserFromClasses",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_dumpedUserFromClasses_fkkelasID",
                table: "dumpedUserFromClasses",
                column: "fkkelasID");

            migrationBuilder.CreateIndex(
                name: "IX_KabupatenKotas_fkProvinsiID",
                table: "KabupatenKotas",
                column: "fkProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_kelas_fkCreatorId",
                table: "kelas",
                column: "fkCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_userId",
                table: "notifications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Sekolahs_fkKabupatenKotaID",
                table: "Sekolahs",
                column: "fkKabupatenKotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sekolahs_fkKategoriSekolahID",
                table: "Sekolahs",
                column: "fkKategoriSekolahID");

            migrationBuilder.CreateIndex(
                name: "IX_statistikUnivs_fkUnivID",
                table: "statistikUnivs",
                column: "fkUnivID");

            migrationBuilder.CreateIndex(
                name: "IX_universitas_fkKategoriUniversitasID",
                table: "universitas",
                column: "fkKategoriUniversitasID");

            migrationBuilder.CreateIndex(
                name: "IX_universitas_fkProvinsiID",
                table: "universitas",
                column: "fkProvinsiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminNotifications");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "classParticipants");

            migrationBuilder.DropTable(
                name: "dumpedUserFromClasses");

            migrationBuilder.DropTable(
                name: "kabupatenKotaDumps");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "provinsiDumps");

            migrationBuilder.DropTable(
                name: "sekolahDumps");

            migrationBuilder.DropTable(
                name: "statistikUnivs");

            migrationBuilder.DropTable(
                name: "universitasDumps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "kelas");

            migrationBuilder.DropTable(
                name: "universitas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "kategoriUniversitas");

            migrationBuilder.DropTable(
                name: "Sekolahs");

            migrationBuilder.DropTable(
                name: "KabupatenKotas");

            migrationBuilder.DropTable(
                name: "kategoriSekolahs");

            migrationBuilder.DropTable(
                name: "Provinsis");
        }
    }
}
