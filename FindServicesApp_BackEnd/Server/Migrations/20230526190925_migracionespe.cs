using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FindServicesApp_BackEnd.Server.Migrations
{
    /// <inheritdoc />
    public partial class migracionespe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria_Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_plan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_Planes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contrato = table.Column<string>(type: "longtext", maxLength: 2000000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pregunta_Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta_Seguridad", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProfesion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Categoria_Planes_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "Categoria_Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_roll = table.Column<int>(type: "int", nullable: false),
                    id_contrato = table.Column<int>(type: "int", nullable: true),
                    Contrato_aprobado = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    contrato_firmado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_categoria_planes = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Categoria_Planes_id_categoria_planes",
                        column: x => x.id_categoria_planes,
                        principalTable: "Categoria_Planes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Contratos_id_contrato",
                        column: x => x.id_contrato,
                        principalTable: "Contratos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Rolls_id_roll",
                        column: x => x.id_roll,
                        principalTable: "Rolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Datos_Generales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_profesion = table.Column<int>(type: "int", nullable: false),
                    ProfesionId = table.Column<int>(type: "int", nullable: true),
                    Identidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_nacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Genero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Opinion_Personal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    departamentosId = table.Column<int>(type: "int", nullable: true),
                    Celular = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Facebook = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instagram = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitud = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    longitud = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_Generales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datos_Generales_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datos_Generales_Profesion_ProfesionId",
                        column: x => x.ProfesionId,
                        principalTable: "Profesion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Datos_Generales_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datos_Generales_departamentos_departamentosId",
                        column: x => x.departamentosId,
                        principalTable: "departamentos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Datos_Generales_Final",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    foto_perfil = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    foto_identidad_trasera = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    foto_identidad_adelantera = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_Generales_Final", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datos_Generales_Final_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Educacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Centro_Estudio = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modalidad_Estudio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nivel_Estudio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hasta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educacion_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educacion_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educacion_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "firmas_usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firma = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmas_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_firmas_usuarios_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pregunta_Contestadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    respuesta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreguntaSeguridadId = table.Column<int>(type: "int", nullable: false),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta_Contestadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregunta_Contestadas_Pregunta_Seguridad_PreguntaSeguridadId",
                        column: x => x.PreguntaSeguridadId,
                        principalTable: "Pregunta_Seguridad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregunta_Contestadas_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Experiencia_Laboral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegistroUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Posicion_Laboral = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Compañia = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salario = table.Column<int>(type: "int", nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Desde = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hasta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DatoGeneralesFinalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia_Laboral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiencia_Laboral_Datos_Generales_Final_DatoGeneralesFinal~",
                        column: x => x.DatoGeneralesFinalId,
                        principalTable: "Datos_Generales_Final",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experiencia_Laboral_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiencia_Laboral_Users_RegistroUsuarioId",
                        column: x => x.RegistroUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiencia_Laboral_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categoria_Planes",
                columns: new[] { "Id", "CreatedAt", "UpdateAt", "nombre_plan", "precio" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3908), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3917), "Versión Free", 0 },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3919), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3920), "Versión Clásica (Versión de Pago)", 400 },
                    { 3, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3921), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3922), "Versión Oro (versión de Pago)", 1500 }
                });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "Id", "CreatedAt", "UpdateAt", "contrato", "status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2926), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2928), "prueba de contrato @nombre", "Inactivo" },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2949), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2951), "<span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >Nosotros: La Agencia de Empleo Privada\r\n                              denominada: INVERSIONES S &amp; R, CONSULAB,\r\n                              debidamente inscrita en el Registro de la\r\n                              Propiedad Mercantil con RTN: 16271993004345 y con\r\n                              Registro en la Secretaría de Trabajo y Seguridad\r\n                              Social bajo Licencia No:RAEP-CF-0004 de fecha 13\r\n                              de febrero del 2018 del domicilio de San Pedro\r\n                              Sula, Cortés para ejercer acciones de\r\n                              intermediación laboral y representada en este acto\r\n                              por Sandy Elizabeth Paredes Jiménez, a quien en lo\r\n                              sucesivo se le denominará: AGENCIA DE EMPLEO\r\n                              PRIVADA <em>(</em>AEP).<br />\r\n                              Y\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; asdas\r\n                                 asasd &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n                              hondureño, mayor de edad, con tarjeta de identidad\r\n                              No.\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                                 0401111343423\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n                              quien actúa en su&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >propia representación y que en el sucesivo se le\r\n                              denominará \"BUSCADOR DE EMPLEO\". Las partes libre\r\n                              y voluntariamente acuerdan la celebración de un\r\n                              contrato de prestación de servicios por Gestión\r\n                              Administrativa para la colocación en un puesto de\r\n                              trabajo, bajo los términos y condiciones\r\n                              siguientes:\r\n                              <strong\r\n                                 >CLAUSULA PRIMER<em>A</em>: OBJETO DE\r\n                                 L<em>A&nbsp;</em>CONTRATACIÓN</strong\r\n                              ></span\r\n                           ><strong\r\n                              ><span\r\n                                 style=\"\r\n                                    font-family: 'Calibri', sans-serif;\r\n                                    color: black;\r\n                                 \"\r\n                                 >.-</span\r\n                              ></strong\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >&nbsp;La prestación de servicio; consiste en la\r\n                              contracción de la \"Agencia de Empleo Privada”\r\n                              <em>(</em>AEP) denominada: INVERSIONES S&amp;R,\r\n                              CONSULAB por el \"Buscador de Empleo\" para la\r\n                              prestación de servicios especializados en\r\n                              intermediación laboral, con la finalidad de\r\n                              encontrar un puesto de trabajo, siendo la\r\n                              actividad de la Agencia de Empleo Privada\r\n                              <em>(</em>AEP) el reclutamiento, pre-selección y\r\n                              remisión de buscadores de empleo a un puesto de\r\n                              trabajo cierto, valido y licito, proporcionado por\r\n                              las empresas que requieren de personal. Quedando a\r\n                              criterio de la empresa la selección del recurso\r\n                              humano idóneo para ocupar la plaza disponible.\r\n                              <strong\r\n                                 >CLAUSULA SEGUNDA: OBLIGACIONES DE LA AGENCIA\r\n                                 DE EMPLEO PRIVADA (AEP). -</strong\r\n                              >\r\n                              La Agencia de Empleo Privada <em>(</em>AEP)\r\n                              “INVERSIONES S &amp; R, CONSULAB\": declara las\r\n                              siguientes obligaciones para con el \"Buscador de\r\n                              Empleo\": 1) No cobrar Membresía, anticipo,\r\n                              comisiones ni ningún costo administrativo al\r\n                              iniciar su proceso de intermediación laboral, es\r\n                              totalmente gratuito el registro o afiliación para\r\n                              el buscador de empleo. 2) Brindarle un trato\r\n                              amable, digno y respetuoso durante el proceso de\r\n                              intermediación laboral 3) Mantener un registro\r\n                              actualizado de buscadores de empleo y vacantes\r\n                              disponibles. 4) Promocionar su Hoja de Vida de\r\n                              acuerdo a la formación académica, experiencia,\r\n                              aptitudes y habilidades laborales según perfil\r\n                              profesional 5) Ofrecer orientación laboral. 6)\r\n                              Brindarle información preliminar sobre la empresa\r\n                              donde será remitido y el puesto requerido 7)\r\n                              Facilitarle la dirección exacta de la empresa\r\n                              donde será remitido, nombre de la persona\r\n                              contacto, hora y fecha de la entrevista. 8) Se\r\n                              obligan a guardar absoluta confidencialidad sobre\r\n                              la información y documentación proporcionada por\r\n                              el buscador de empleo. 9) Remitir a buscadores de\r\n                              empleo a empresas para entrevista de trabajo\r\n                              vinculado según perfil ocupacional. 10) Garantizar\r\n                              al buscador de empleo un procedimiento sin\r\n                              discriminación por razón de racial o étnico, sexo,\r\n                              edad, religión o convicciones, u opinión política,\r\n                              orientación sexual, afiliación sindical, condición\r\n                              social, y discapacidad, destacando condiciones de\r\n                              aptitud para desempeñar un puesto de trabajo. 11)\r\n                              Extender el correspondiente recibo de pago al\r\n                              buscador de empleo colocado.\r\n                              <strong\r\n                                 >CLAUSULA TERCERA: OBLIGACIONES DEL \"BUSCADOR\r\n                                 DE EMPLEO”. -</strong\r\n                              >\r\n                              El \"buscador de Empleo\" al contratar los servicios\r\n                              de la Agencia de Empleo Privada <em>(</em>AEP)\r\n                              Declara que se obliga a: 1) Proporcionar su\r\n                              historial laboral comprobable 2) Facilitar su hoja\r\n                              de vida, dirección domiciliaria, celular, teléfono\r\n                              fijo actualizados, 3) El Buscador de Empleo no\r\n                              podrá difundir por ningún medio los servicios del\r\n                              proceso intermediación laboral establecido por la\r\n                              AEP, sin la autorización expresa de ésta. 4)\r\n                              Presentarse a las charlas de orientación laboral o\r\n                              asesorías para el proceso de intermediación\r\n                              laboral. 4) Acudir de manera puntual a las\r\n                              entrevistas de trabajo programadas 5). -\r\n                              Movilizarse por sus propios medios a las empresas\r\n                              remitidos. 6) Llevar su hoja de vida impresa\r\n                              <em>yl</em>o en el formato solicitado a las\r\n                              empresas remitidas. 7) Informar a la Agencia de\r\n                              Empleo Privada (AEP) una vez contratado por la\r\n                              empresa a la que fue remitido. 8) Cumplir con los\r\n                              requisitos y directrices establecidas por la AEP\r\n                              para la colocación. 9) Reportarse con la Agencia\r\n                              de Empleo Privada <em>(</em>AEP), una vez\r\n                              contratado para dar seguimiento y cumplimiento a\r\n                              su pago por Gestión Administrativa. 10) Pagar a la\r\n                              Agencia de Empleo Privada <em>(</em>AEP) según lo\r\n                              establece el acuerdo No STSS-155-2017.\r\n\r\n                              <!--Inicio Cuarta CLAUSULA a tomar en cuenta a partir del 2021-12-15-->\r\n                              <strong\r\n                                 >CLAUSULA CUARTA: HONORARIOS Y FORMA DE\r\n                                 PAGO.</strong\r\n                              >\r\n                              La Agencia de Empleo Privada (AEP)'INVERSIONES S\r\n                              &amp; R, CONSULAB': una vez haya colocado a el\r\n                              'Buscador de Empleo' en un empleo de forma\r\n                              INDEFINIDO: Serán calculados en base al\r\n                              equivalente al 50% sobre el total de UN MES DE\r\n                              SALARIO COMPLETO, según ar el titulo 361 del\r\n                              Código del Trabajo de Honduras (incluyendo sueldos\r\n                              variables como ser: comisiones, bonos por metas o\r\n                              similares) (salario COMPLETO se entiende como\r\n                              salario de un mes calendario exacto).\r\n\r\n                              <!--Fin Cuarta CLAUSULA-->\r\n\r\n                              <br /><br />\r\n                              EL Buscador de Empleo se compromete legalmente a\r\n                              pagar a La Agencia de Empleo Privada\r\n                              <em>(</em>AEP) \"INVERSIONES S&amp;R, CONSULAB\" la\r\n                              cantidad de __________________ (Lps) equivalente\r\n                              al cincuenta por ciento (50%) de su salario\r\n                              mensual establecido, en concepto de pago por\r\n                              gestiones administrativas. Mismo que deberá pagar\r\n                              en dos (2)&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >cuotas quincenales o su equivalente según método\r\n                              de pago establecido en la empresa que se colocó,\r\n                              en el lugar que</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >&nbsp;ocupa la Agencia de Empleo privada\r\n                              <em>(</em>AEP) quien extenderá el respectivo\r\n                              recibo de pago, al el buscador de empleo. Cuando\r\n                              el Buscador de Empleo haya sido colocado en una\r\n                              empresa mediante la modalidad de un contrato de\r\n                              empleo temporal gestionado por La Agencia de\r\n                              Empleo Privada (AEP), estará en la obligación de\r\n                              realizar pago de honorarios, en concepto de\r\n                              Gestión Administrativa según la tabla\r\n                              siguiente:&nbsp;\r\n                              <strong\r\n                                 ><u>SOLO QUE LA PLAZA SEA TEMPORAL</u></strong\r\n                              >, para lo cual el Asesor le hará mención desde un\r\n                              inicio que le ofrezca la plaza:\r\n                           </span>\r\n                        </p>\r\n                        <div\r\n                           align=\"center\"\r\n                           style=\"\r\n                              margin-top: 0in;\r\n                              margin-right: 0in;\r\n                              margin-bottom: 8pt;\r\n                              margin-left: 0in;\r\n                              line-height: 107%;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                           \"\r\n                        >\r\n                           <table\r\n                              style=\"\r\n                                 width: 467.5pt;\r\n                                 border-collapse: collapse;\r\n                                 border: none;\r\n                              \"\r\n                           >\r\n                              <tbody>\r\n                                 <tr>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 226.55pt;\r\n                                          border: 1pt solid windowtext;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 1 mes 10% del salario\r\n                                             mensual</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 240.95pt;\r\n                                          border-top: 1pt solid windowtext;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-image: initial;\r\n                                          border-left: none;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 2 meses 20% del salario\r\n                                             mensual&nbsp;</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                 </tr>\r\n                                 <tr>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 226.55pt;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-left: 1pt solid windowtext;\r\n                                          border-image: initial;\r\n                                          border-top: none;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo&nbsp;</span\r\n                                          ><span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >de 3 meses 30% del salario\r\n                                             mensual&nbsp;</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 240.95pt;\r\n                                          border-top: none;\r\n                                          border-left: none;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 4 o más meses 50 % del\r\n                                             salario mensual</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                 </tr>\r\n                              </tbody>\r\n                           </table>\r\n                        </div>\r\n                        <p\r\n                           style=\"\r\n                              margin-right: 0in;\r\n                              margin-left: 0in;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                              margin-top: 0in;\r\n                              margin-bottom: 8pt;\r\n                              line-height: 150%;\r\n                              margin: 0in;\r\n                              text-align: justify;\r\n                           \"\r\n                        >\r\n                           <span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >Esto no incluye el tiempo de prueba (2 meses)\r\n                              quedando claro que si la persona fuere contratada\r\n                              de nuevo o se le asigne un puesto permanente se\r\n                              realizará el ajuste al cincuenta por ciento (50%)\r\n                              de una contratación permanente que cobra la\r\n                              Agencia de Empleo. Dicho&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >ajuste será aplicado únicamente; si está ha sido\r\n                              parte de la Gestión Administrativa realizada por\r\n                              la Agencia de Empleo privada a favor del buscador\r\n                              de empleo antes que se termine el contrato.\r\n                              <strong\r\n                                 >CLAUSULA QUINTA: EXCEPCIONES DE LA AGENCIA DE\r\n                                 EMPLEO PRIVADA <em>(</em>AEP):</strong\r\n                              >\r\n                              a) La AEP es únicamente un enlace entre el\r\n                              “Buscador de Empleo\" y el empleador, y el tiempo\r\n                              para la contratación inicial dependerá de lo que\r\n                              estipule el empleador. b) La AEP no será\r\n                              responsable del desempeño del candidato\r\n                              contratados por la empresa, ya que su labor es la\r\n                              vinculación entre el buscador de empleo y el\r\n                              empleador c) La AEP no hace recomendaciones de\r\n                              manera expresa al empleador referente a quién\r\n                              tiene que contratar o sobre las habilidades y\r\n                              competencias del buscador de empleo, ya que será\r\n                              el empleador quien deberá hacer su proceso de\r\n                              filtración, y selección de su recurso humano para\r\n                              cada puesto de trabajo disponible. d) El desempeño\r\n                              laboral del buscador de empleo es responsabilidad\r\n                              exclusiva de él mismo, debiendo por su propia\r\n                              cuenta cuidar su trabajo en el cual fue colocado,\r\n                              demostrando en todo momento profesionalismo, y sus\r\n                              valores éticos y morales, en el ejercicio en su\r\n                              cargo. e) Si por algún motivo el buscador colocado\r\n                              en la empresa remitida decide no continuar\r\n                              laborando o es despedido con causa justificada,\r\n                              los honorarios por Gestión Administrativa siempre\r\n                              deberán ser cancelados a la Agencia de Empleo.\r\n                              <strong\r\n                                 >CLAUSULA SEXTA: RESCISIÓN DE SERVICIOS: POR\r\n                                 PARTE DE ÉL \"BUSCADOR DE EMPLEO</strong\r\n                              >\r\n                              Serán considerados motivos de rescisión de\r\n                              servicios por el buscador de empleo los\r\n                              siguientes: 1) Muerte o incapacidad sobrevenida de\r\n                              el \"Buscador de Empleo\" 2) Cuando \"El buscador de\r\n                              Empleo\" fue colocado y realizó el pago convenido.\r\n                              3) Por desistimiento: entendido como la facultad\r\n                              del buscador de empleo de dejar sin efecto el\r\n                              contrato celebrado notificándoselo por escrito a\r\n                              la Agencia de Empleo Privada <em>(</em>AEP) sin\r\n                              penalización alguna; El desistimiento podrá\r\n                              realizarlo en cualquier momento. Salvo que exista\r\n                              cualquier contrato preliminar vinculante con la\r\n                              empresa a la que fue remitido por la Agencia de\r\n                              Empleo Privada <em>(</em>AEP). 4).- Rescisión\r\n                              Voluntaria: la cual se produce por mutuo acuerdo\r\n                              entre el “Buscador de Empleo y la Agencia de\r\n                              Empleo Privada <em>(</em>AEP). 5).- Cuando los\r\n                              datos personales del buscador brindados a la AEP\r\n                              sean filtrados o utilizados para uso distinto a la\r\n                              colocación en un puesto de trabajo, sin previo\r\n                              consentimiento del buscador de empleo. 6).- Cuando\r\n                              las ofertas de vacantes proporcionadas por la\r\n                              Agencia de Empleo Privada (AEP) sean falsas.\r\n                              <strong\r\n                                 >CLAUSULA SEPTIMA: RESCISION POR PARTE DE LA\r\n                                 AGENCIA DE EMPLEO PRIVADA\r\n                                 <em>(</em>AEP)</strong\r\n                              >\r\n                              la rescisión de servicios por la Agencia de Empleo\r\n                              Privada serán las siguientes: 1) Cierre de\r\n                              operaciones de la AEP en base a ley, 2) Cuando los\r\n                              datos proporcionados por el buscador de empleo no\r\n                              sean fidedignos. 3) No asistir a entrevistas\r\n                              programadas o negarse a ir a entrevistas, sin\r\n                              causas justificadas por escrito durante tres (3)\r\n                              llamados consecutivos. 4) El no actualizar datos\r\n                              como cambios de números telefónicos, dirección\r\n                              domiciliaria entre otros, que perjudiquen la\r\n                              comunicación para contactarlo. 5) Negarse a\r\n                              cumplir sin justificación alguna las\r\n                              recomendaciones encomendadas por la AEP durante el\r\n                              proceso de intermediación. 6) Imposibilidad legal\r\n                              del buscador de empleo decretada por la autoridad\r\n                              competente durante la vigencia del contrato.\r\n                              <strong\r\n                                 >CLAUSULA OCT<em>A</em>VA: VIGENCIA.-</strong\r\n                              >\r\n                              El período de vigencia del presente contrato será\r\n                              de doce meses (12), contados a partir de la firma\r\n                              del mismo.\r\n                              <strong\r\n                                 >CLAUSULA NOVENA: RESOLUCIÓN DE\r\n                                 CONFLICTOS:</strong\r\n                              >\r\n                              Las dudas o controversias de cualquier naturaleza\r\n                              que puedan suscitarse sobre el presente contrato,\r\n                              y que no puedan ser resueltas por las partes\r\n                              contratantes, serán sometidas a las disposiciones\r\n                              establecidas en la legislación nacional vigente y\r\n                              en la jurisdicción correspondiente conforme a la\r\n                              naturaleza del presente contrato. Asimismo, las\r\n                              partes intervinientes acuerdan que todo litigio,\r\n                              discrepancia, cuestión o reclamación resultantes\r\n                              de la ejecución o interpretación del presente\r\n                              contrato o relacionados con él, directa o\r\n                              indirectamente, se resolverán mediante arbitraje\r\n                              administrado <br /><br />\r\n                              por el Centro de Conciliación y Arbitraje (CCA) de\r\n                              la Cámara de Comercio e Industrias de Cortés\r\n                              (CCIC) al que se encomienda la administración del\r\n                              arbitraje y la designación de los árbitros de\r\n                              acuerdo con su Reglamento. Igualmente, los abajo\r\n                              firmantes hacen constar expresamente su compromiso\r\n                              de cumplir el laudo arbitral que se dicte.\r\n                              <strong>CLAUSULA DECIMA:</strong> El afiliado\r\n                              queda obligado a cancelar de sus primeras DOS\r\n                              QUINCENAS, de lo contrario se ve obligado a pagar\r\n                              GASTOS DE PAPELERIA POR TRAMITES LEGALES de\r\n                              QUINIENTOS LEMPIRAS (L500) que, al llegar al área\r\n                              legal de la Empresa, se hará un requerimiento\r\n                              extrajudicial, del cual pagará un cobro mínimo de\r\n                              20% sin que en ningún caso pueda ser inferior,\r\n                              fijado por el arancel profesional de Derecho Art\r\n                              No 105. Leído que fue el presente contrato y\r\n                              enteradas las partes del contenido de todas y cada\r\n                              una de las cláusulas que en el mismo se precisan,\r\n                              firmamos el presente contrato en la ciudad de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp; El Porvenir\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp; </span\r\n                              >.&nbsp;</span\r\n                           >\r\n                        </p>\r\n                        <p\r\n                           style=\"\r\n                              margin-right: 0in;\r\n                              margin-left: 0in;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                              margin-top: 0in;\r\n                              margin-bottom: 8pt;\r\n                              line-height: 150%;\r\n                              margin: 0in;\r\n                              text-align: justify;\r\n                           \"\r\n                        >\r\n                           <span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                           >\r\n                              Departamento de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Atlantida\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n\r\n                              a los\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp; 13 &nbsp;&nbsp;\r\n                              </span>\r\n                              días del mes de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Abril\r\n                                 &nbsp;&nbsp;\r\n                              </span>\r\n                              &nbsp;&nbsp; del año\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp; 2023 &nbsp;&nbsp; </span\r\n                              >.&nbsp;</span\r\n                           >\r\n                        </p>", "Activo" }
                });

            migrationBuilder.InsertData(
                table: "Pregunta_Seguridad",
                columns: new[] { "Id", "CreatedAt", "UpdateAt", "descripcion" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4192), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4194), "¿Cuál es el nombre de tu primera mascota?" },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4196), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4197), "¿Cuál es el nombre de tu libro favorito?" },
                    { 3, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4198), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4198), "¿Cuál es el tu canción favorita?" },
                    { 4, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4199), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4201), "¿Cuál es el tu color favorito?" }
                });

            migrationBuilder.InsertData(
                table: "Profesion",
                columns: new[] { "Id", "CreatedAt", "NombreProfesion", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4217), "Programador", null },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4226), "Diseñador", null },
                    { 3, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4228), "Ingeniero", null },
                    { 4, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4229), "Médico", null },
                    { 5, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4230), "Abogado", null },
                    { 6, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4233), "Arquitecto", null },
                    { 7, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4234), "Psicólogo", null },
                    { 8, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4235), "Enfermero", null },
                    { 9, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4237), "Profesor", null },
                    { 10, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4239), "Periodista", null },
                    { 11, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4241), "Publicista", null },
                    { 12, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4242), "Contador", null },
                    { 13, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4243), "Economista", null },
                    { 14, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4244), "Ingeniero Civil", null },
                    { 15, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4246), "Ingeniero Industrial", null },
                    { 16, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4247), "Ingeniero en Sistemas", null },
                    { 17, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4248), "Analista de Sistemas", null },
                    { 18, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4251), "Consultor de Negocios", null },
                    { 19, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4252), "Chef", null },
                    { 20, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4253), "Decorador", null },
                    { 21, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4254), "Arquitecto", null },
                    { 22, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4255), "Contador", null },
                    { 23, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4257), "Abogado", null },
                    { 24, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4258), "Periodista", null },
                    { 25, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4259), "Psicólogo", null },
                    { 26, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4260), "Médico", null },
                    { 27, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4261), "Enfermero", null },
                    { 28, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4262), "Dentista", null },
                    { 29, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4263), "Farmacéutico", null },
                    { 30, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4264), "Nutricionista", null },
                    { 31, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4266), "Educador", null },
                    { 32, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4267), "Entrenador personal", null },
                    { 33, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4269), "Psicopedagogo", null },
                    { 34, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4271), "Economista", null },
                    { 35, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4273), "Ingeniero civil", null },
                    { 36, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4274), "Ingeniero de sistemas", null },
                    { 37, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4275), "Ingeniero mecánico", null },
                    { 38, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4276), "Ingeniero eléctrico", null },
                    { 39, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4278), "Ingeniero químico", null },
                    { 40, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4279), "Ingeniero industrial", null }
                });

            migrationBuilder.InsertData(
                table: "Rolls",
                columns: new[] { "Id", "CreatedAt", "UpdateAt", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2828), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2842), "Proveedor de Servicios" },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2881), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2882), "Clientes" },
                    { 3, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2899), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2900), "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "departamentos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Atlántida" },
                    { 2, "Choluteca" },
                    { 3, "Colón" },
                    { 4, "Comayagua" },
                    { 5, "Copán" },
                    { 6, "Cortés" },
                    { 7, "El Paraíso" },
                    { 8, "Francisco Morazán" },
                    { 9, "Gracias a Dios" },
                    { 10, "Intibucá" },
                    { 11, "Islas de la Bahía" },
                    { 12, "La Paz" },
                    { 13, "Lempira" },
                    { 14, "Ocotepeque" },
                    { 15, "Olancho" },
                    { 16, "Santa Bárbara" },
                    { 17, "Valle" },
                    { 18, "Yoro" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "La Ceiba" },
                    { 2, 1, "El Porvenir" },
                    { 3, 1, "Esparta" },
                    { 4, 1, "Jutiapa" },
                    { 5, 1, "La Masica" },
                    { 6, 1, "San Francisco" },
                    { 7, 1, "Tela" },
                    { 8, 1, "Arizona" },
                    { 9, 2, "Choluteca" },
                    { 10, 2, "Apacilagua" },
                    { 11, 2, "Concepción de María" },
                    { 12, 2, "Duyure" },
                    { 13, 2, "El Corpus" },
                    { 14, 2, "El Triunfo" },
                    { 15, 2, "Marcovia" },
                    { 16, 2, "Morolica" },
                    { 17, 2, "Namasigüe" },
                    { 18, 2, "Orocuina" },
                    { 19, 2, "Pespire" },
                    { 20, 2, "San Antonio de Flores" },
                    { 21, 2, "San Isidro" },
                    { 22, 2, "San José" },
                    { 23, 2, "San Marcos de Colón" },
                    { 24, 2, "Santa Ana de Yusguare" },
                    { 25, 3, "Trujillo" },
                    { 26, 3, "Balfate" },
                    { 27, 3, "Iriona" },
                    { 28, 3, "Limón" },
                    { 29, 3, "Sabá" },
                    { 30, 3, "Santa Fe" },
                    { 31, 3, "Santa Rosa de Aguán" },
                    { 32, 3, "Sonaguera" },
                    { 33, 3, "Tocoa" },
                    { 34, 3, "Bonito Oriental" },
                    { 35, 4, "Comayagua" },
                    { 36, 4, "Ajuterique" },
                    { 37, 4, "El Rosario" },
                    { 38, 4, "Esquías" },
                    { 39, 4, "Humuya" },
                    { 40, 4, "La Libertad" },
                    { 41, 4, "Lamaní" },
                    { 42, 4, "La Trinidad" },
                    { 43, 4, "Lejamaní" },
                    { 44, 4, "Meámbar" },
                    { 45, 4, "Minas de Oro" },
                    { 46, 4, "Ojos de Agua" },
                    { 47, 4, "San Jerónimo" },
                    { 48, 4, "San José de Comayagua" },
                    { 49, 4, "San José del Potrero" },
                    { 50, 4, "San Luis" },
                    { 51, 4, "San Sebastián" },
                    { 52, 4, "Siguatepeque" },
                    { 53, 5, "Santa Rosa de Copán" },
                    { 54, 5, "Cabañas" },
                    { 55, 5, "Concepción" },
                    { 56, 5, "Copán Ruinas" },
                    { 57, 5, "Corquin" },
                    { 58, 5, "Cucuyagua" },
                    { 59, 5, "Dolores" },
                    { 60, 5, "Dulce Nombre" },
                    { 61, 5, "El Paraíso" },
                    { 62, 5, "Florida" },
                    { 63, 5, "La Jigua" },
                    { 64, 5, "La Unión" },
                    { 65, 5, "Nueva Arcadia" },
                    { 66, 5, "San Agustín" },
                    { 67, 5, "San Antonio" },
                    { 68, 5, "San Jerónimo" },
                    { 69, 5, "San José" },
                    { 70, 5, "San Juan de Opoa" },
                    { 71, 5, "San Nicolás" },
                    { 72, 5, "San Pedro de Copán" },
                    { 73, 5, "Santa Rita" },
                    { 74, 5, "Trinidad de Copán" },
                    { 75, 5, "Veracruz" },
                    { 76, 6, "San Pedro Sula" },
                    { 77, 6, "Choloma" },
                    { 78, 6, "Omoa" },
                    { 79, 6, "Pimienta" },
                    { 80, 6, "Potrerillos" },
                    { 81, 6, "Puerto Cortés" },
                    { 82, 6, "San Antonio de Cortés" },
                    { 83, 6, "San Francisco de Yojoa" },
                    { 84, 6, "San Manuel" },
                    { 85, 6, "Santa Cruz de Yojoa" },
                    { 86, 6, "Villanueva" },
                    { 87, 6, "La Lima" },
                    { 88, 7, "Yuscarán" },
                    { 89, 7, "Alauca" },
                    { 90, 7, "Danlí" },
                    { 91, 7, "El Paraíso" },
                    { 92, 7, "Güinope" },
                    { 93, 7, "Jacaleapa" },
                    { 94, 7, "Liure" },
                    { 95, 7, "Morocelí" },
                    { 96, 7, "Oropolí" },
                    { 97, 7, "Potrerillos" },
                    { 98, 7, "San Antonio de Flores" },
                    { 99, 7, "San Lucas" },
                    { 100, 7, "San Matías" },
                    { 101, 7, "Soledad" },
                    { 102, 7, "Teupasenti" },
                    { 103, 7, "Texiguat" },
                    { 104, 7, "Vado Ancho" },
                    { 105, 7, "Yauyupe" },
                    { 106, 7, "Trojes" },
                    { 107, 8, "Distrito Central" },
                    { 108, 8, "Alubarén" },
                    { 109, 8, "Cedros" },
                    { 110, 8, "Curarén" },
                    { 111, 8, "El Porvenir" },
                    { 112, 8, "Guaimaca" },
                    { 113, 8, "La Libertad" },
                    { 114, 8, "La Venta" },
                    { 115, 8, "Lepaterique" },
                    { 116, 8, "Maraita" },
                    { 117, 8, "Marale" },
                    { 118, 8, "Nueva Armenia" },
                    { 119, 8, "Ojojona" },
                    { 120, 8, "Orica" },
                    { 121, 8, "Reitoca" },
                    { 122, 8, "Sabanagrande" },
                    { 123, 8, "San Antonio de Oriente" },
                    { 124, 8, "San Buenaventura" },
                    { 125, 8, "San Ignacio" },
                    { 126, 8, "San Juan de Flores" },
                    { 127, 8, "San Miguelito" },
                    { 128, 8, "Santa Ana" },
                    { 129, 8, "Santa Lucía" },
                    { 130, 8, "Talanga" },
                    { 131, 8, "Tatumbla" },
                    { 132, 8, "Valle de Angeles" },
                    { 133, 8, "Villa de San Francisco" },
                    { 134, 8, "Vallecillo" },
                    { 135, 9, "Puerto Lempira" },
                    { 136, 9, "Brus Laguna" },
                    { 137, 9, "Ahuas" },
                    { 138, 9, "Juan Francisco Bulnes" },
                    { 139, 9, "Villeda Morales" },
                    { 140, 9, "Wampusirpi" },
                    { 141, 10, "La Esperanza" },
                    { 142, 10, "Camasca" },
                    { 143, 10, "Colomoncagua" },
                    { 144, 10, "Concepción" },
                    { 145, 10, "Dolores" },
                    { 146, 10, "Intibucá" },
                    { 147, 10, "Jesús de Otoro" },
                    { 148, 10, "Magdalena" },
                    { 149, 10, "Masaguara" },
                    { 150, 10, "San Antonio" },
                    { 151, 10, "San Isidro" },
                    { 152, 10, "San Juan" },
                    { 153, 10, "San Marcos de La Sierra" },
                    { 154, 10, "San Miguelito" },
                    { 155, 10, "Santa Lucía" },
                    { 156, 10, "Yamaranguila" },
                    { 157, 10, "San Francisco de Opalaca" },
                    { 158, 11, "Roatán" },
                    { 159, 11, "Guanaja" },
                    { 160, 11, "José Santos Guardiola" },
                    { 161, 11, "Utila" },
                    { 162, 12, "La Paz" },
                    { 163, 12, "Aguanqueterique" },
                    { 164, 12, "Cabañas" },
                    { 165, 12, "Cane" },
                    { 166, 12, "Chinacla" },
                    { 167, 12, "Guajiquiro" },
                    { 168, 12, "Lauterique" },
                    { 169, 12, "Marcala" },
                    { 170, 12, "Mercedes de Oriente" },
                    { 171, 12, "Opatoro" },
                    { 172, 12, "San Antonio del Norte" },
                    { 173, 12, "San José" },
                    { 174, 12, "San Juan" },
                    { 175, 12, "San Pedro de Tutule" },
                    { 176, 12, "Santa Ana" },
                    { 177, 12, "Santa Elena" },
                    { 178, 12, "Santa María" },
                    { 179, 12, "Santiago de Puringla" },
                    { 180, 12, "Yarula" },
                    { 181, 13, "Gracias" },
                    { 182, 13, "Belén" },
                    { 183, 13, "Candelaria" },
                    { 184, 13, "Cololaca" },
                    { 185, 13, "Erandique" },
                    { 186, 13, "Gualcince" },
                    { 187, 13, "Guarita" },
                    { 188, 13, "La Campa" },
                    { 189, 13, "La Iguala" },
                    { 190, 13, "Las Flores" },
                    { 191, 13, "La Unión" },
                    { 192, 13, "La Virtud" },
                    { 193, 13, "Lepaera" },
                    { 194, 13, "Mapulaca" },
                    { 195, 13, "Piraera" },
                    { 196, 13, "San Andrés" },
                    { 197, 13, "San Francisco" },
                    { 198, 13, "San Juan Guarita" },
                    { 199, 13, "San Manuel Colohete" },
                    { 200, 13, "San Rafael" },
                    { 201, 13, "San Sebastián" },
                    { 202, 13, "Santa Cruz" },
                    { 203, 13, "Talgua" },
                    { 204, 13, "Tambla" },
                    { 205, 13, "Tomalá" },
                    { 206, 13, "Valladolid" },
                    { 207, 13, "Virginia" },
                    { 208, 13, "San Marcos de Caiquín" },
                    { 209, 14, "Ocotepeque" },
                    { 210, 14, "Belén Gualcho" },
                    { 211, 14, "Concepción" },
                    { 212, 14, "Dolores Merendón" },
                    { 213, 14, "Fraternidad" },
                    { 214, 14, "La Encarnación" },
                    { 215, 14, "La Labor" },
                    { 216, 14, "Lucerna" },
                    { 217, 14, "Mercedes" },
                    { 218, 14, "San Fernando" },
                    { 219, 14, "San Francisco del Valle" },
                    { 220, 14, "San Jorge" },
                    { 221, 14, "San Marcos" },
                    { 222, 14, "Santa Fe" },
                    { 223, 14, "Sensenti" },
                    { 224, 14, "Sinuapa" },
                    { 225, 15, "Juticalpa" },
                    { 226, 15, "Campamento" },
                    { 227, 15, "Catacamas" },
                    { 228, 15, "Concordia" },
                    { 229, 15, "Dulce Nombre de Culmí" },
                    { 230, 15, "El Rosario" },
                    { 231, 15, "Esquipulas del Norte" },
                    { 232, 15, "Gualaco" },
                    { 233, 15, "Guarizama" },
                    { 234, 15, "Guata" },
                    { 235, 15, "Guayape" },
                    { 236, 15, "Jano" },
                    { 237, 15, "La Unión" },
                    { 238, 15, "Mangulile" },
                    { 239, 15, "Manto" },
                    { 240, 15, "Salamá" },
                    { 241, 15, "San Estebán" },
                    { 242, 15, "San Francisco de Becerra" },
                    { 243, 15, "San Francisco de La Paz" },
                    { 244, 15, "Santa María del Real" },
                    { 245, 15, "Silca" },
                    { 246, 15, "Yocón" },
                    { 247, 15, "Patuca" },
                    { 248, 16, "Santa Bárbara" },
                    { 249, 16, "Arada" },
                    { 250, 16, "Atima" },
                    { 251, 16, "Azacualpa" },
                    { 252, 16, "Ceguaca" },
                    { 253, 16, "Concepción del Norte" },
                    { 254, 16, "Concepción del Sur" },
                    { 255, 16, "Chinda" },
                    { 256, 16, "El Níspero" },
                    { 257, 16, "Gualala" },
                    { 258, 16, "Ilama" },
                    { 259, 16, "Macuelizo" },
                    { 260, 16, "Naranjito" },
                    { 261, 16, "Nuevo Celilac" },
                    { 262, 16, "Petoa" },
                    { 263, 16, "Protección" },
                    { 264, 16, "Quimistán" },
                    { 265, 16, "San Francisco de Ojuera" },
                    { 266, 16, "San José de Colinas" },
                    { 267, 16, "San Luis" },
                    { 268, 16, "San Marcos" },
                    { 269, 16, "San Nicolás" },
                    { 270, 16, "San Pedro  Zacapa" },
                    { 271, 16, "San Vicente Centenario" },
                    { 272, 16, "Santa Rita" },
                    { 273, 16, "Trinidad" },
                    { 274, 16, "Las Vegas" },
                    { 275, 16, "Nueva Frontera" },
                    { 276, 17, "Nacaome" },
                    { 277, 17, "Alianza" },
                    { 278, 17, "Amapala" },
                    { 279, 17, "Aramecina" },
                    { 280, 17, "Caridad" },
                    { 281, 17, "Goascorán" },
                    { 282, 17, "Langue" },
                    { 283, 17, "San Francisco de Coray" },
                    { 284, 17, "San Lorenzo" },
                    { 285, 18, "Yoro" },
                    { 286, 18, "Arenal" },
                    { 287, 18, "El Negrito" },
                    { 288, 18, "El Progreso" },
                    { 289, 18, "Jocón" },
                    { 290, 18, "Morazán" },
                    { 291, 18, "Olanchito" },
                    { 292, 18, "Santa Rita" },
                    { 293, 18, "Sulaco" },
                    { 294, 18, "Victoria" },
                    { 295, 18, "Yorito" }
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "CreatedAt", "UpdateAt", "descripcion", "id_categoria" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4060), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4065), "Registro e Información general.", 1 },
                    { 2, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4068), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4069), "Información Bancaria.", 1 },
                    { 3, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4070), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4072), "Registrar los servicios que brinda.", 1 },
                    { 4, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4074), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4075), "Notificación push y vía correo electrónico de las solicitudes de cotizaciones de los clientes para contratar sus servicios.", 1 },
                    { 5, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4076), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4077), "En esta versión Free el proveedor solo podrá responder y aprobar 2 cotizaciones de servicios. Ya que tendrá que pasarse a la versión de pago si desea seguir contestando y aprobando cotizaciones de servicios de los clientes.", 1 },
                    { 6, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4078), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4079), "El administrador podrá modificar la cantidad de cotizaciones que el proveedor podrá contestar en esta versión Free.", 1 },
                    { 7, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4106), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4107), "Registro e Información general.", 2 },
                    { 8, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4108), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4109), "Información Bancaria.", 2 },
                    { 9, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4111), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4112), "Registrar los servicios que brinda", 2 },
                    { 10, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4113), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4114), "Notificación push y vía correo electrónico de las solicitudes de cotizaciones para contratar sus servicios.", 2 },
                    { 11, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4115), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4115), "Generar cotizaciones y compartirlas a sus clientes desde la aplicación móvil.", 2 },
                    { 12, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4117), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4118), "Recibir y contestar mensajes.", 2 },
                    { 13, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4119), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4120), "Recibir Evaluación de los clientes.", 2 },
                    { 14, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4121), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4122), "Publicar 2 anuncios mensuales de promociones de sus servicios. El administrador podrá ampliar la cantidad de anuncios según la versión de pago.", 2 },
                    { 15, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4143), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4144), "Registro e Información general.", 3 },
                    { 16, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4145), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4146), "Información Bancaria.", 3 },
                    { 17, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4148), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4149), "Registrar los servicios que brinda", 3 },
                    { 18, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4151), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4152), "Notificación push y vía correo electrónico de las solicitudes de cotizaciones para contratar sus servicios.", 3 },
                    { 19, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4153), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4154), "Chat para recibir y contestar mensajes.", 3 },
                    { 20, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4156), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4157), "Generar cotizaciones y compartirlas a sus clientes desde la aplicación móvil.", 3 },
                    { 21, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4158), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4159), "Recibir Evaluación de los clientes.", 3 },
                    { 22, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4160), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4161), "Publicar 4 anuncios mensuales de promociones de sus servicios. El administrador podrá ampliar la cantidad de anuncios según la versión de pago.", 3 },
                    { 23, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4162), new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(4163), "Aparecer como las primeras opciones de búsqueda, siempre y cuando este bien calificado por los clientes.", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Activo", "Contrato_aprobado", "CreatedAt", "Email", "Password", "UpdateAt", "contrato_firmado", "id_categoria_planes", "id_contrato", "id_roll" },
                values: new object[,]
                {
                    { 1, "Activo", false, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(2969), "cesar@cesar.com", "MQAyADMANAA1ADYANwA4ADkAMAA=", new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3013), false, null, null, 1 },
                    { 2, "Activo", false, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3043), "adminv1@adminv1.com", "MQAyADMANAA1ADYANwA4ADkAMAA=", new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3049), false, null, null, 3 },
                    { 3, "Activo", false, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3066), "adminv2@adminv2.com", "MQAyADMANAA1ADYANwA4ADkAMAA=", new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3070), false, null, null, 3 },
                    { 4, "Activo", false, new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3085), "adminv3@adminv3.com", "MQAyADMANAA1ADYANwA4ADkAMAA=", new DateTime(2023, 5, 26, 13, 9, 24, 912, DateTimeKind.Local).AddTicks(3089), false, null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Generales_departamentosId",
                table: "Datos_Generales",
                column: "departamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Generales_MunicipioId",
                table: "Datos_Generales",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Generales_ProfesionId",
                table: "Datos_Generales",
                column: "ProfesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Generales_RegistroUsuarioId",
                table: "Datos_Generales",
                column: "RegistroUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Datos_Generales_Final_RegistroUsuarioId",
                table: "Datos_Generales_Final",
                column: "RegistroUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educacion_DepartamentoId",
                table: "Educacion",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacion_MunicipioId",
                table: "Educacion",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacion_RegistroUsuarioId",
                table: "Educacion",
                column: "RegistroUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_Laboral_DatoGeneralesFinalId",
                table: "Experiencia_Laboral",
                column: "DatoGeneralesFinalId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_Laboral_DepartamentoId",
                table: "Experiencia_Laboral",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_Laboral_MunicipioId",
                table: "Experiencia_Laboral",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_Laboral_RegistroUsuarioId",
                table: "Experiencia_Laboral",
                column: "RegistroUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_firmas_usuarios_RegistroUsuarioId",
                table: "firmas_usuarios",
                column: "RegistroUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_id_categoria",
                table: "Planes",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_Contestadas_PreguntaSeguridadId",
                table: "Pregunta_Contestadas",
                column: "PreguntaSeguridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_Contestadas_RegistroUsuarioId",
                table: "Pregunta_Contestadas",
                column: "RegistroUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_categoria_planes",
                table: "Users",
                column: "id_categoria_planes");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_contrato",
                table: "Users",
                column: "id_contrato");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_roll",
                table: "Users",
                column: "id_roll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos_Generales");

            migrationBuilder.DropTable(
                name: "Educacion");

            migrationBuilder.DropTable(
                name: "Experiencia_Laboral");

            migrationBuilder.DropTable(
                name: "firmas_usuarios");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Pregunta_Contestadas");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "Datos_Generales_Final");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Pregunta_Seguridad");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "departamentos");

            migrationBuilder.DropTable(
                name: "Categoria_Planes");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Rolls");
        }
    }
}
