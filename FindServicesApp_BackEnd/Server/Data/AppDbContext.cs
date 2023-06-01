using FindServicesApp_BackEnd.Shared.Models.contrato;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.eduacion;
using FindServicesApp_BackEnd.Shared.Models.Encriptador;
using FindServicesApp_BackEnd.Shared.Models.experiencia_laboral;
using FindServicesApp_BackEnd.Shared.Models.plan_servicios;
using FindServicesApp_BackEnd.Shared.Models.pregunta_seguridad;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Data;
using System.Numerics;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FindServicesApp_BackEnd.Server.Data
{

    //https://jasonwatmore.com/post/2022/03/25/net-6-connect-to-mysql-database-with-entity-framework-core
//https://medium.com/@cptullio/net-core-3-blazor-app-and-security-with-identity-and-mysql-61b12dc7523
    //https://www.youtube.com/watch?v=W8Rjt54GBuo
    //https://zetbit.tech/categories/asp-dot-net-core/41/setup-mysql-connection-dot-net-7-asp-net-core
    public class AppDbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public AppDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}


        //esto es de usuarios
        public DbSet<RegistroUsuario> Users { get; set; }
        public DbSet<DatosGenerales> Datos_Generales { get; set; }
        public DbSet<DatoGeneralesFinal> Datos_Generales_Final { get; set; }
        public DbSet<Experiencia_Laboral> Experiencia_Laboral { get; set; }
        public DbSet<Educacion> Educacion { get; set; }
        public DbSet<FirmaContrato> firmas_usuarios { get; set; }

        //roles de usuarios
        public DbSet<Roll> Rolls { get; set; }


        //Departamentos y municipios
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        //contrato
        public DbSet<Contrato> Contratos { get; set; }

        //planes
        public DbSet<Categoria_planes> Categoria_Planes { get; set; }
        public DbSet<Planes> Planes { get; set; }

        //pregunta de seguridad
        public DbSet<Pregunta_Seguridad> Pregunta_Seguridad { get; set; }
        public DbSet<Pregunta_Contestadas> Pregunta_Contestadas { get; set; }

        //profesiones
        public DbSet<Profesion> Profesion { get; set; }

        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{

        //    // Replace with your connection string.
        //    //var connectionString = "server=localhost; database=usuarios_db; user=root; password=";

        //    //var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));

        //    // connect to mysql with connection string from app settings
        //    //var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //    //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relacion de usuario puede tener un rol
            modelBuilder.Entity<RegistroUsuario>()
           .HasOne(c => c.Roll)
           .WithMany()
           .HasForeignKey(c => c.id_roll);

            //relacion de usuario puede tener un contato
            modelBuilder.Entity<RegistroUsuario>()
           .HasOne(c => c.Contrato)
           .WithMany()
           .HasForeignKey(c => c.id_contrato);

            //relacion de clientes puede tener datos generales
            modelBuilder.Entity<RegistroUsuario>()
            .HasOne(c => c.DatosGenerales)
            .WithOne(d => d.RegistroUsuario)
            .HasForeignKey<DatosGenerales>(d => d.RegistroUsuarioId);

            //relacion de clientes puede tener datos generales parte final
            modelBuilder.Entity<RegistroUsuario>()
            .HasOne(c => c.DatosGeneralesFinal)
            .WithOne(d => d.RegistroUsuario)
            .HasForeignKey<DatoGeneralesFinal>(d => d.RegistroUsuarioId);

            //relacion de departamentos y municipios
            modelBuilder.Entity<Departamentos>()
            .HasMany(d => d.Municipios)
            .WithOne(m => m.Departamento)
            .HasForeignKey(m => m.DepartamentoId);

            //relacion de planes
            // Configurar la relación uno a muchos entre CategoriaPlan y Plan
            modelBuilder.Entity<Planes>()
                .HasOne(p => p.Categoria_Planes)
                .WithMany(c => c.Planes)
                .HasForeignKey(p => p.id_categoria);

            //relacion de usuario puede tener un plan
            modelBuilder.Entity<RegistroUsuario>()
           .HasOne(c => c.categoria_planes)
           .WithMany()
           .HasForeignKey(c => c.id_categoria_planes);


            //relacion de usuario puede tener un preguntas_seguridad
            modelBuilder.Entity<RegistroUsuario>()
            .HasOne(c => c.Pregunta_Contestadas)
            .WithOne(d => d.RegistroUsuario)
            .HasForeignKey<Pregunta_Contestadas>(d => d.RegistroUsuarioId);

            //relacion de usuario puede tener un rol
            modelBuilder.Entity<Pregunta_Contestadas>()
           .HasOne(c => c.PreguntaSeguridad)
           .WithMany()
           .HasForeignKey(c => c.PreguntaSeguridadId);

 


            // Code to seed data
            modelBuilder.Entity<Roll>().HasData(
               new Roll { Id = 1, name = "Proveedor de Servicios",UpdateAt = DateTime.Now });

            modelBuilder.Entity<Roll>().HasData(
               new Roll { Id = 2, name = "Clientes", UpdateAt= DateTime.Now });
            modelBuilder.Entity<Roll>().HasData(
               new Roll { Id = 3, name = "Administrador", UpdateAt =DateTime.Now });


            // contrato
            modelBuilder.Entity<Contrato>().HasData(
               new Contrato { Id = 1, contrato = "prueba de contrato @nombre", status="Inactivo", UpdateAt = DateTime.Now });

            modelBuilder.Entity<Contrato>().HasData(
               new Contrato { Id = 2, 
                   contrato = "<span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >Nosotros: La Agencia de Empleo Privada\r\n                              denominada: INVERSIONES S &amp; R, CONSULAB,\r\n                              debidamente inscrita en el Registro de la\r\n                              Propiedad Mercantil con RTN: 16271993004345 y con\r\n                              Registro en la Secretaría de Trabajo y Seguridad\r\n                              Social bajo Licencia No:RAEP-CF-0004 de fecha 13\r\n                              de febrero del 2018 del domicilio de San Pedro\r\n                              Sula, Cortés para ejercer acciones de\r\n                              intermediación laboral y representada en este acto\r\n                              por Sandy Elizabeth Paredes Jiménez, a quien en lo\r\n                              sucesivo se le denominará: AGENCIA DE EMPLEO\r\n                              PRIVADA <em>(</em>AEP).<br />\r\n                              Y\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; asdas\r\n                                 asasd &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n                              hondureño, mayor de edad, con tarjeta de identidad\r\n                              No.\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                                 0401111343423\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n                              quien actúa en su&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >propia representación y que en el sucesivo se le\r\n                              denominará \"BUSCADOR DE EMPLEO\". Las partes libre\r\n                              y voluntariamente acuerdan la celebración de un\r\n                              contrato de prestación de servicios por Gestión\r\n                              Administrativa para la colocación en un puesto de\r\n                              trabajo, bajo los términos y condiciones\r\n                              siguientes:\r\n                              <strong\r\n                                 >CLAUSULA PRIMER<em>A</em>: OBJETO DE\r\n                                 L<em>A&nbsp;</em>CONTRATACIÓN</strong\r\n                              ></span\r\n                           ><strong\r\n                              ><span\r\n                                 style=\"\r\n                                    font-family: 'Calibri', sans-serif;\r\n                                    color: black;\r\n                                 \"\r\n                                 >.-</span\r\n                              ></strong\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >&nbsp;La prestación de servicio; consiste en la\r\n                              contracción de la \"Agencia de Empleo Privada”\r\n                              <em>(</em>AEP) denominada: INVERSIONES S&amp;R,\r\n                              CONSULAB por el \"Buscador de Empleo\" para la\r\n                              prestación de servicios especializados en\r\n                              intermediación laboral, con la finalidad de\r\n                              encontrar un puesto de trabajo, siendo la\r\n                              actividad de la Agencia de Empleo Privada\r\n                              <em>(</em>AEP) el reclutamiento, pre-selección y\r\n                              remisión de buscadores de empleo a un puesto de\r\n                              trabajo cierto, valido y licito, proporcionado por\r\n                              las empresas que requieren de personal. Quedando a\r\n                              criterio de la empresa la selección del recurso\r\n                              humano idóneo para ocupar la plaza disponible.\r\n                              <strong\r\n                                 >CLAUSULA SEGUNDA: OBLIGACIONES DE LA AGENCIA\r\n                                 DE EMPLEO PRIVADA (AEP). -</strong\r\n                              >\r\n                              La Agencia de Empleo Privada <em>(</em>AEP)\r\n                              “INVERSIONES S &amp; R, CONSULAB\": declara las\r\n                              siguientes obligaciones para con el \"Buscador de\r\n                              Empleo\": 1) No cobrar Membresía, anticipo,\r\n                              comisiones ni ningún costo administrativo al\r\n                              iniciar su proceso de intermediación laboral, es\r\n                              totalmente gratuito el registro o afiliación para\r\n                              el buscador de empleo. 2) Brindarle un trato\r\n                              amable, digno y respetuoso durante el proceso de\r\n                              intermediación laboral 3) Mantener un registro\r\n                              actualizado de buscadores de empleo y vacantes\r\n                              disponibles. 4) Promocionar su Hoja de Vida de\r\n                              acuerdo a la formación académica, experiencia,\r\n                              aptitudes y habilidades laborales según perfil\r\n                              profesional 5) Ofrecer orientación laboral. 6)\r\n                              Brindarle información preliminar sobre la empresa\r\n                              donde será remitido y el puesto requerido 7)\r\n                              Facilitarle la dirección exacta de la empresa\r\n                              donde será remitido, nombre de la persona\r\n                              contacto, hora y fecha de la entrevista. 8) Se\r\n                              obligan a guardar absoluta confidencialidad sobre\r\n                              la información y documentación proporcionada por\r\n                              el buscador de empleo. 9) Remitir a buscadores de\r\n                              empleo a empresas para entrevista de trabajo\r\n                              vinculado según perfil ocupacional. 10) Garantizar\r\n                              al buscador de empleo un procedimiento sin\r\n                              discriminación por razón de racial o étnico, sexo,\r\n                              edad, religión o convicciones, u opinión política,\r\n                              orientación sexual, afiliación sindical, condición\r\n                              social, y discapacidad, destacando condiciones de\r\n                              aptitud para desempeñar un puesto de trabajo. 11)\r\n                              Extender el correspondiente recibo de pago al\r\n                              buscador de empleo colocado.\r\n                              <strong\r\n                                 >CLAUSULA TERCERA: OBLIGACIONES DEL \"BUSCADOR\r\n                                 DE EMPLEO”. -</strong\r\n                              >\r\n                              El \"buscador de Empleo\" al contratar los servicios\r\n                              de la Agencia de Empleo Privada <em>(</em>AEP)\r\n                              Declara que se obliga a: 1) Proporcionar su\r\n                              historial laboral comprobable 2) Facilitar su hoja\r\n                              de vida, dirección domiciliaria, celular, teléfono\r\n                              fijo actualizados, 3) El Buscador de Empleo no\r\n                              podrá difundir por ningún medio los servicios del\r\n                              proceso intermediación laboral establecido por la\r\n                              AEP, sin la autorización expresa de ésta. 4)\r\n                              Presentarse a las charlas de orientación laboral o\r\n                              asesorías para el proceso de intermediación\r\n                              laboral. 4) Acudir de manera puntual a las\r\n                              entrevistas de trabajo programadas 5). -\r\n                              Movilizarse por sus propios medios a las empresas\r\n                              remitidos. 6) Llevar su hoja de vida impresa\r\n                              <em>yl</em>o en el formato solicitado a las\r\n                              empresas remitidas. 7) Informar a la Agencia de\r\n                              Empleo Privada (AEP) una vez contratado por la\r\n                              empresa a la que fue remitido. 8) Cumplir con los\r\n                              requisitos y directrices establecidas por la AEP\r\n                              para la colocación. 9) Reportarse con la Agencia\r\n                              de Empleo Privada <em>(</em>AEP), una vez\r\n                              contratado para dar seguimiento y cumplimiento a\r\n                              su pago por Gestión Administrativa. 10) Pagar a la\r\n                              Agencia de Empleo Privada <em>(</em>AEP) según lo\r\n                              establece el acuerdo No STSS-155-2017.\r\n\r\n                              <!--Inicio Cuarta CLAUSULA a tomar en cuenta a partir del 2021-12-15-->\r\n                              <strong\r\n                                 >CLAUSULA CUARTA: HONORARIOS Y FORMA DE\r\n                                 PAGO.</strong\r\n                              >\r\n                              La Agencia de Empleo Privada (AEP)'INVERSIONES S\r\n                              &amp; R, CONSULAB': una vez haya colocado a el\r\n                              'Buscador de Empleo' en un empleo de forma\r\n                              INDEFINIDO: Serán calculados en base al\r\n                              equivalente al 50% sobre el total de UN MES DE\r\n                              SALARIO COMPLETO, según ar el titulo 361 del\r\n                              Código del Trabajo de Honduras (incluyendo sueldos\r\n                              variables como ser: comisiones, bonos por metas o\r\n                              similares) (salario COMPLETO se entiende como\r\n                              salario de un mes calendario exacto).\r\n\r\n                              <!--Fin Cuarta CLAUSULA-->\r\n\r\n                              <br /><br />\r\n                              EL Buscador de Empleo se compromete legalmente a\r\n                              pagar a La Agencia de Empleo Privada\r\n                              <em>(</em>AEP) \"INVERSIONES S&amp;R, CONSULAB\" la\r\n                              cantidad de __________________ (Lps) equivalente\r\n                              al cincuenta por ciento (50%) de su salario\r\n                              mensual establecido, en concepto de pago por\r\n                              gestiones administrativas. Mismo que deberá pagar\r\n                              en dos (2)&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >cuotas quincenales o su equivalente según método\r\n                              de pago establecido en la empresa que se colocó,\r\n                              en el lugar que</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >&nbsp;ocupa la Agencia de Empleo privada\r\n                              <em>(</em>AEP) quien extenderá el respectivo\r\n                              recibo de pago, al el buscador de empleo. Cuando\r\n                              el Buscador de Empleo haya sido colocado en una\r\n                              empresa mediante la modalidad de un contrato de\r\n                              empleo temporal gestionado por La Agencia de\r\n                              Empleo Privada (AEP), estará en la obligación de\r\n                              realizar pago de honorarios, en concepto de\r\n                              Gestión Administrativa según la tabla\r\n                              siguiente:&nbsp;\r\n                              <strong\r\n                                 ><u>SOLO QUE LA PLAZA SEA TEMPORAL</u></strong\r\n                              >, para lo cual el Asesor le hará mención desde un\r\n                              inicio que le ofrezca la plaza:\r\n                           </span>\r\n                        </p>\r\n                        <div\r\n                           align=\"center\"\r\n                           style=\"\r\n                              margin-top: 0in;\r\n                              margin-right: 0in;\r\n                              margin-bottom: 8pt;\r\n                              margin-left: 0in;\r\n                              line-height: 107%;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                           \"\r\n                        >\r\n                           <table\r\n                              style=\"\r\n                                 width: 467.5pt;\r\n                                 border-collapse: collapse;\r\n                                 border: none;\r\n                              \"\r\n                           >\r\n                              <tbody>\r\n                                 <tr>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 226.55pt;\r\n                                          border: 1pt solid windowtext;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 1 mes 10% del salario\r\n                                             mensual</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 240.95pt;\r\n                                          border-top: 1pt solid windowtext;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-image: initial;\r\n                                          border-left: none;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 2 meses 20% del salario\r\n                                             mensual&nbsp;</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                 </tr>\r\n                                 <tr>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 226.55pt;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-left: 1pt solid windowtext;\r\n                                          border-image: initial;\r\n                                          border-top: none;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo&nbsp;</span\r\n                                          ><span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >de 3 meses 30% del salario\r\n                                             mensual&nbsp;</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                    <td\r\n                                       style=\"\r\n                                          width: 240.95pt;\r\n                                          border-top: none;\r\n                                          border-left: none;\r\n                                          border-bottom: 1pt solid windowtext;\r\n                                          border-right: 1pt solid windowtext;\r\n                                          padding: 0in 5.4pt;\r\n                                          vertical-align: top;\r\n                                       \"\r\n                                    >\r\n                                       <p\r\n                                          style=\"\r\n                                             margin-right: 0in;\r\n                                             margin-left: 0in;\r\n                                             font-size: 15px;\r\n                                             font-family: 'Calibri', sans-serif;\r\n                                             margin-top: 0in;\r\n                                             margin-bottom: 8pt;\r\n                                             line-height: 150%;\r\n                                             margin: 0in;\r\n                                             text-align: justify;\r\n                                          \"\r\n                                       >\r\n                                          <span\r\n                                             style=\"\r\n                                                font-size: 14px;\r\n                                                line-height: 150%;\r\n                                                font-family: 'Calibri',\r\n                                                   sans-serif;\r\n                                                color: black;\r\n                                             \"\r\n                                             >Periodo de 4 o más meses 50 % del\r\n                                             salario mensual</span\r\n                                          >\r\n                                       </p>\r\n                                    </td>\r\n                                 </tr>\r\n                              </tbody>\r\n                           </table>\r\n                        </div>\r\n                        <p\r\n                           style=\"\r\n                              margin-right: 0in;\r\n                              margin-left: 0in;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                              margin-top: 0in;\r\n                              margin-bottom: 8pt;\r\n                              line-height: 150%;\r\n                              margin: 0in;\r\n                              text-align: justify;\r\n                           \"\r\n                        >\r\n                           <span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >Esto no incluye el tiempo de prueba (2 meses)\r\n                              quedando claro que si la persona fuere contratada\r\n                              de nuevo o se le asigne un puesto permanente se\r\n                              realizará el ajuste al cincuenta por ciento (50%)\r\n                              de una contratación permanente que cobra la\r\n                              Agencia de Empleo. Dicho&nbsp;</span\r\n                           ><span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                              >ajuste será aplicado únicamente; si está ha sido\r\n                              parte de la Gestión Administrativa realizada por\r\n                              la Agencia de Empleo privada a favor del buscador\r\n                              de empleo antes que se termine el contrato.\r\n                              <strong\r\n                                 >CLAUSULA QUINTA: EXCEPCIONES DE LA AGENCIA DE\r\n                                 EMPLEO PRIVADA <em>(</em>AEP):</strong\r\n                              >\r\n                              a) La AEP es únicamente un enlace entre el\r\n                              “Buscador de Empleo\" y el empleador, y el tiempo\r\n                              para la contratación inicial dependerá de lo que\r\n                              estipule el empleador. b) La AEP no será\r\n                              responsable del desempeño del candidato\r\n                              contratados por la empresa, ya que su labor es la\r\n                              vinculación entre el buscador de empleo y el\r\n                              empleador c) La AEP no hace recomendaciones de\r\n                              manera expresa al empleador referente a quién\r\n                              tiene que contratar o sobre las habilidades y\r\n                              competencias del buscador de empleo, ya que será\r\n                              el empleador quien deberá hacer su proceso de\r\n                              filtración, y selección de su recurso humano para\r\n                              cada puesto de trabajo disponible. d) El desempeño\r\n                              laboral del buscador de empleo es responsabilidad\r\n                              exclusiva de él mismo, debiendo por su propia\r\n                              cuenta cuidar su trabajo en el cual fue colocado,\r\n                              demostrando en todo momento profesionalismo, y sus\r\n                              valores éticos y morales, en el ejercicio en su\r\n                              cargo. e) Si por algún motivo el buscador colocado\r\n                              en la empresa remitida decide no continuar\r\n                              laborando o es despedido con causa justificada,\r\n                              los honorarios por Gestión Administrativa siempre\r\n                              deberán ser cancelados a la Agencia de Empleo.\r\n                              <strong\r\n                                 >CLAUSULA SEXTA: RESCISIÓN DE SERVICIOS: POR\r\n                                 PARTE DE ÉL \"BUSCADOR DE EMPLEO</strong\r\n                              >\r\n                              Serán considerados motivos de rescisión de\r\n                              servicios por el buscador de empleo los\r\n                              siguientes: 1) Muerte o incapacidad sobrevenida de\r\n                              el \"Buscador de Empleo\" 2) Cuando \"El buscador de\r\n                              Empleo\" fue colocado y realizó el pago convenido.\r\n                              3) Por desistimiento: entendido como la facultad\r\n                              del buscador de empleo de dejar sin efecto el\r\n                              contrato celebrado notificándoselo por escrito a\r\n                              la Agencia de Empleo Privada <em>(</em>AEP) sin\r\n                              penalización alguna; El desistimiento podrá\r\n                              realizarlo en cualquier momento. Salvo que exista\r\n                              cualquier contrato preliminar vinculante con la\r\n                              empresa a la que fue remitido por la Agencia de\r\n                              Empleo Privada <em>(</em>AEP). 4).- Rescisión\r\n                              Voluntaria: la cual se produce por mutuo acuerdo\r\n                              entre el “Buscador de Empleo y la Agencia de\r\n                              Empleo Privada <em>(</em>AEP). 5).- Cuando los\r\n                              datos personales del buscador brindados a la AEP\r\n                              sean filtrados o utilizados para uso distinto a la\r\n                              colocación en un puesto de trabajo, sin previo\r\n                              consentimiento del buscador de empleo. 6).- Cuando\r\n                              las ofertas de vacantes proporcionadas por la\r\n                              Agencia de Empleo Privada (AEP) sean falsas.\r\n                              <strong\r\n                                 >CLAUSULA SEPTIMA: RESCISION POR PARTE DE LA\r\n                                 AGENCIA DE EMPLEO PRIVADA\r\n                                 <em>(</em>AEP)</strong\r\n                              >\r\n                              la rescisión de servicios por la Agencia de Empleo\r\n                              Privada serán las siguientes: 1) Cierre de\r\n                              operaciones de la AEP en base a ley, 2) Cuando los\r\n                              datos proporcionados por el buscador de empleo no\r\n                              sean fidedignos. 3) No asistir a entrevistas\r\n                              programadas o negarse a ir a entrevistas, sin\r\n                              causas justificadas por escrito durante tres (3)\r\n                              llamados consecutivos. 4) El no actualizar datos\r\n                              como cambios de números telefónicos, dirección\r\n                              domiciliaria entre otros, que perjudiquen la\r\n                              comunicación para contactarlo. 5) Negarse a\r\n                              cumplir sin justificación alguna las\r\n                              recomendaciones encomendadas por la AEP durante el\r\n                              proceso de intermediación. 6) Imposibilidad legal\r\n                              del buscador de empleo decretada por la autoridad\r\n                              competente durante la vigencia del contrato.\r\n                              <strong\r\n                                 >CLAUSULA OCT<em>A</em>VA: VIGENCIA.-</strong\r\n                              >\r\n                              El período de vigencia del presente contrato será\r\n                              de doce meses (12), contados a partir de la firma\r\n                              del mismo.\r\n                              <strong\r\n                                 >CLAUSULA NOVENA: RESOLUCIÓN DE\r\n                                 CONFLICTOS:</strong\r\n                              >\r\n                              Las dudas o controversias de cualquier naturaleza\r\n                              que puedan suscitarse sobre el presente contrato,\r\n                              y que no puedan ser resueltas por las partes\r\n                              contratantes, serán sometidas a las disposiciones\r\n                              establecidas en la legislación nacional vigente y\r\n                              en la jurisdicción correspondiente conforme a la\r\n                              naturaleza del presente contrato. Asimismo, las\r\n                              partes intervinientes acuerdan que todo litigio,\r\n                              discrepancia, cuestión o reclamación resultantes\r\n                              de la ejecución o interpretación del presente\r\n                              contrato o relacionados con él, directa o\r\n                              indirectamente, se resolverán mediante arbitraje\r\n                              administrado <br /><br />\r\n                              por el Centro de Conciliación y Arbitraje (CCA) de\r\n                              la Cámara de Comercio e Industrias de Cortés\r\n                              (CCIC) al que se encomienda la administración del\r\n                              arbitraje y la designación de los árbitros de\r\n                              acuerdo con su Reglamento. Igualmente, los abajo\r\n                              firmantes hacen constar expresamente su compromiso\r\n                              de cumplir el laudo arbitral que se dicte.\r\n                              <strong>CLAUSULA DECIMA:</strong> El afiliado\r\n                              queda obligado a cancelar de sus primeras DOS\r\n                              QUINCENAS, de lo contrario se ve obligado a pagar\r\n                              GASTOS DE PAPELERIA POR TRAMITES LEGALES de\r\n                              QUINIENTOS LEMPIRAS (L500) que, al llegar al área\r\n                              legal de la Empresa, se hará un requerimiento\r\n                              extrajudicial, del cual pagará un cobro mínimo de\r\n                              20% sin que en ningún caso pueda ser inferior,\r\n                              fijado por el arancel profesional de Derecho Art\r\n                              No 105. Leído que fue el presente contrato y\r\n                              enteradas las partes del contenido de todas y cada\r\n                              una de las cláusulas que en el mismo se precisan,\r\n                              firmamos el presente contrato en la ciudad de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp; El Porvenir\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp; </span\r\n                              >.&nbsp;</span\r\n                           >\r\n                        </p>\r\n                        <p\r\n                           style=\"\r\n                              margin-right: 0in;\r\n                              margin-left: 0in;\r\n                              font-size: 15px;\r\n                              font-family: 'Calibri', sans-serif;\r\n                              margin-top: 0in;\r\n                              margin-bottom: 8pt;\r\n                              line-height: 150%;\r\n                              margin: 0in;\r\n                              text-align: justify;\r\n                           \"\r\n                        >\r\n                           <span\r\n                              style=\"\r\n                                 font-family: 'Calibri', sans-serif;\r\n                                 color: black;\r\n                              \"\r\n                           >\r\n                              Departamento de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Atlantida\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n                              </span>\r\n\r\n                              a los\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp; 13 &nbsp;&nbsp;\r\n                              </span>\r\n                              días del mes de\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Abril\r\n                                 &nbsp;&nbsp;\r\n                              </span>\r\n                              &nbsp;&nbsp; del año\r\n                              <span class=\"textunderline\">\r\n                                 &nbsp;&nbsp; 2023 &nbsp;&nbsp; </span\r\n                              >.&nbsp;</span\r\n                           >\r\n                        </p>"
                   , status = "Activo"
                   , UpdateAt = DateTime.Now });

            //crear usuarios
            modelBuilder.Entity<RegistroUsuario>().HasData(
               new RegistroUsuario
               {
                   Id = 1,
                   Email = "cesar@cesar.com",
                   Password = Seguridad.Encriptar("1234567890"),
                   id_roll = 1,
                   UpdateAt = DateTime.Now
               });

            modelBuilder.Entity<RegistroUsuario>().HasData(
               new RegistroUsuario
               {
                   Id = 2,
                   Email = "adminv1@adminv1.com",
                   Password = Seguridad.Encriptar("1234567890"),
                   id_roll = 3,
                   UpdateAt = DateTime.Now
               });

            modelBuilder.Entity<RegistroUsuario>().HasData(
               new RegistroUsuario
               {
                   Id = 3,
                   Email = "adminv2@adminv2.com",
                   Password = Seguridad.Encriptar("1234567890"),
                   id_roll = 3,
                   UpdateAt = DateTime.Now
               });

            modelBuilder.Entity<RegistroUsuario>().HasData(
               new RegistroUsuario
               {
                   Id = 4,
                   Email = "adminv3@adminv3.com",
                   Password = Seguridad.Encriptar("1234567890"),
                   id_roll = 3,
                   UpdateAt = DateTime.Now
               });

            //Departamentos y municipio
            modelBuilder.Entity<Departamentos>().HasData(
                            new Departamentos { Id = 1, Nombre = "Atlántida" },
                            new Departamentos { Id = 2, Nombre = "Choluteca" },
                            new Departamentos { Id = 3, Nombre = "Colón" },
                            new Departamentos { Id = 4, Nombre = "Comayagua" },
                            new Departamentos { Id = 5, Nombre = "Copán" },
                            new Departamentos { Id = 6, Nombre = "Cortés" },
                            new Departamentos { Id = 7, Nombre = "El Paraíso" },
                            new Departamentos { Id = 8, Nombre = "Francisco Morazán" },
                            new Departamentos { Id = 9, Nombre = "Gracias a Dios" },
                            new Departamentos { Id = 10, Nombre = "Intibucá" },
                            new Departamentos { Id = 11, Nombre = "Islas de la Bahía" },
                            new Departamentos { Id = 12, Nombre = "La Paz" },
                            new Departamentos { Id = 13, Nombre = "Lempira" },
                            new Departamentos { Id = 14, Nombre = "Ocotepeque" },
                            new Departamentos { Id = 15, Nombre = "Olancho" },
                            new Departamentos { Id = 16, Nombre = "Santa Bárbara" },
                            new Departamentos { Id = 17, Nombre = "Valle" },
                            new Departamentos { Id = 18, Nombre = "Yoro" }
                        );



            //atlantidad
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 1, Nombre = "La Ceiba", DepartamentoId = 1 },
                new Municipio { Id = 2, Nombre = "El Porvenir", DepartamentoId = 1 },
                new Municipio { Id = 3, Nombre = "Esparta", DepartamentoId = 1 },
                new Municipio { Id = 4, Nombre = "Jutiapa", DepartamentoId = 1 },
                new Municipio { Id = 5, Nombre = "La Masica", DepartamentoId = 1 },
                new Municipio { Id = 6, Nombre = "San Francisco", DepartamentoId = 1 },
                new Municipio { Id = 7, Nombre = "Tela", DepartamentoId = 1 },
                new Municipio { Id = 8, Nombre = "Arizona", DepartamentoId = 1 }

            );




            //Choluteca
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 9, Nombre = "Choluteca", DepartamentoId = 2 },
                new Municipio { Id = 10, Nombre = "Apacilagua", DepartamentoId = 2 },
                new Municipio { Id = 11, Nombre = "Concepción de María", DepartamentoId = 2 },
                new Municipio { Id = 12, Nombre = "Duyure", DepartamentoId = 2 },
                new Municipio { Id = 13, Nombre = "El Corpus", DepartamentoId = 2 },
                new Municipio { Id = 14, Nombre = "El Triunfo", DepartamentoId = 2 },
                new Municipio { Id = 15, Nombre = "Marcovia", DepartamentoId = 2 },
                new Municipio { Id = 16, Nombre = "Morolica", DepartamentoId = 2 },
                new Municipio { Id = 17, Nombre = "Namasigüe", DepartamentoId = 2 },
                new Municipio { Id = 18, Nombre = "Orocuina", DepartamentoId = 2 },
                new Municipio { Id = 19, Nombre = "Pespire", DepartamentoId = 2 },
                new Municipio { Id = 20, Nombre = "San Antonio de Flores", DepartamentoId = 2 },
                new Municipio { Id = 21, Nombre = "San Isidro", DepartamentoId = 2 },
                new Municipio { Id = 22, Nombre = "San José", DepartamentoId = 2 },
                new Municipio { Id = 23, Nombre = "San Marcos de Colón", DepartamentoId = 2 },
                new Municipio { Id = 24, Nombre = "Santa Ana de Yusguare", DepartamentoId = 2 }

            );



            //Colón
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 25, Nombre = "Trujillo", DepartamentoId = 3 },
                new Municipio { Id = 26, Nombre = "Balfate", DepartamentoId = 3 },
                new Municipio { Id = 27, Nombre = "Iriona", DepartamentoId = 3 },
                new Municipio { Id = 28, Nombre = "Limón", DepartamentoId = 3 },
                new Municipio { Id = 29, Nombre = "Sabá", DepartamentoId = 3 },
                new Municipio { Id = 30, Nombre = "Santa Fe", DepartamentoId = 3 },
                new Municipio { Id = 31, Nombre = "Santa Rosa de Aguán", DepartamentoId = 3 },
                new Municipio { Id = 32, Nombre = "Sonaguera", DepartamentoId = 3 },
                new Municipio { Id = 33, Nombre = "Tocoa", DepartamentoId = 3 },
                new Municipio { Id = 34, Nombre = "Bonito Oriental", DepartamentoId = 3 }


            );



            //Comayagua
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 35, Nombre = "Comayagua", DepartamentoId = 4 },
                new Municipio { Id = 36, Nombre = "Ajuterique", DepartamentoId = 4 },
                new Municipio { Id = 37, Nombre = "El Rosario", DepartamentoId = 4 },
                new Municipio { Id = 38, Nombre = "Esquías", DepartamentoId = 4 },
                new Municipio { Id = 39, Nombre = "Humuya", DepartamentoId = 4 },
                new Municipio { Id = 40, Nombre = "La Libertad", DepartamentoId = 4 },
                new Municipio { Id = 41, Nombre = "Lamaní", DepartamentoId = 4 },
                new Municipio { Id = 42, Nombre = "La Trinidad", DepartamentoId = 4 },
                new Municipio { Id = 43, Nombre = "Lejamaní", DepartamentoId = 4 },
                new Municipio { Id = 44, Nombre = "Meámbar", DepartamentoId = 4 },
                new Municipio { Id = 45, Nombre = "Minas de Oro", DepartamentoId = 4 },
                new Municipio { Id = 46, Nombre = "Ojos de Agua", DepartamentoId = 4 },
                new Municipio { Id = 47, Nombre = "San Jerónimo", DepartamentoId = 4 },
                new Municipio { Id = 48, Nombre = "San José de Comayagua", DepartamentoId = 4 },
                new Municipio { Id = 49, Nombre = "San José del Potrero", DepartamentoId = 4 },
                new Municipio { Id = 50, Nombre = "San Luis", DepartamentoId = 4 },
                new Municipio { Id = 51, Nombre = "San Sebastián", DepartamentoId = 4 },
                new Municipio { Id = 52, Nombre = "Siguatepeque", DepartamentoId = 4 }


            );



            //Copan
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 53, Nombre = "Santa Rosa de Copán", DepartamentoId = 5 },
                new Municipio { Id = 54, Nombre = "Cabañas", DepartamentoId = 5 },
                new Municipio { Id = 55, Nombre = "Concepción", DepartamentoId = 5 },
                new Municipio { Id = 56, Nombre = "Copán Ruinas", DepartamentoId = 5 },
                new Municipio { Id = 57, Nombre = "Corquin", DepartamentoId = 5 },
                new Municipio { Id = 58, Nombre = "Cucuyagua", DepartamentoId = 5 },
                new Municipio { Id = 59, Nombre = "Dolores", DepartamentoId = 5 },
                new Municipio { Id = 60, Nombre = "Dulce Nombre", DepartamentoId = 5 },
                new Municipio { Id = 61, Nombre = "El Paraíso", DepartamentoId = 5 },
                new Municipio { Id = 62, Nombre = "Florida", DepartamentoId = 5 },
                new Municipio { Id = 63, Nombre = "La Jigua", DepartamentoId = 5 },
                new Municipio { Id = 64, Nombre = "La Unión", DepartamentoId = 5 },
                new Municipio { Id = 65, Nombre = "Nueva Arcadia", DepartamentoId = 5 },
                new Municipio { Id = 66, Nombre = "San Agustín", DepartamentoId = 5 },
                new Municipio { Id = 67, Nombre = "San Antonio", DepartamentoId = 5 },
                new Municipio { Id = 68, Nombre = "San Jerónimo", DepartamentoId = 5 },
                new Municipio { Id = 69, Nombre = "San José", DepartamentoId = 5 },
                new Municipio { Id = 70, Nombre = "San Juan de Opoa", DepartamentoId = 5 },
                new Municipio { Id = 71, Nombre = "San Nicolás", DepartamentoId = 5 },
                new Municipio { Id = 72, Nombre = "San Pedro de Copán", DepartamentoId = 5 },
                new Municipio { Id = 73, Nombre = "Santa Rita", DepartamentoId = 5 },
                new Municipio { Id = 74, Nombre = "Trinidad de Copán", DepartamentoId = 5 },
                new Municipio { Id = 75, Nombre = "Veracruz", DepartamentoId = 5 }

            );



            //Cortés
            modelBuilder.Entity<Municipio>().HasData(
                new Municipio { Id = 76, Nombre = "San Pedro Sula", DepartamentoId = 6 },
                new Municipio { Id = 77, Nombre = "Choloma", DepartamentoId = 6 },
                new Municipio { Id = 78, Nombre = "Omoa", DepartamentoId = 6 },
                new Municipio { Id = 79, Nombre = "Pimienta", DepartamentoId = 6 },
                new Municipio { Id = 80, Nombre = "Potrerillos", DepartamentoId = 6 },
                new Municipio { Id = 81, Nombre = "Puerto Cortés", DepartamentoId = 6 },
                new Municipio { Id = 82, Nombre = "San Antonio de Cortés", DepartamentoId = 6 },
                new Municipio { Id = 83, Nombre = "San Francisco de Yojoa", DepartamentoId = 6 },
                new Municipio { Id = 84, Nombre = "San Manuel", DepartamentoId = 6 },
                new Municipio { Id = 85, Nombre = "Santa Cruz de Yojoa", DepartamentoId = 6 },
                new Municipio { Id = 86, Nombre = "Villanueva", DepartamentoId = 6 },
                new Municipio { Id = 87, Nombre = "La Lima", DepartamentoId = 6 }


            );




            //El Paraíso
            modelBuilder.Entity<Municipio>().HasData(

                new Municipio { Id = 88, Nombre = "Yuscarán", DepartamentoId = 7 },
                new Municipio { Id = 89, Nombre = "Alauca", DepartamentoId = 7 },
                new Municipio { Id = 90, Nombre = "Danlí", DepartamentoId = 7 },
                new Municipio { Id = 91, Nombre = "El Paraíso", DepartamentoId = 7 },
                new Municipio { Id = 92, Nombre = "Güinope", DepartamentoId = 7 },
                new Municipio { Id = 93, Nombre = "Jacaleapa", DepartamentoId = 7 },
                new Municipio { Id = 94, Nombre = "Liure", DepartamentoId = 7 },
                new Municipio { Id = 95, Nombre = "Morocelí", DepartamentoId = 7 },
                new Municipio { Id = 96, Nombre = "Oropolí", DepartamentoId = 7 },
                new Municipio { Id = 97, Nombre = "Potrerillos", DepartamentoId = 7 },
                new Municipio { Id = 98, Nombre = "San Antonio de Flores", DepartamentoId = 7 },
                new Municipio { Id = 99, Nombre = "San Lucas", DepartamentoId = 7 },
                new Municipio { Id = 100, Nombre = "San Matías", DepartamentoId = 7 },
                new Municipio { Id = 101, Nombre = "Soledad", DepartamentoId = 7 },
                new Municipio { Id = 102, Nombre = "Teupasenti", DepartamentoId = 7 },
                new Municipio { Id = 103, Nombre = "Texiguat", DepartamentoId = 7 },
                new Municipio { Id = 104, Nombre = "Vado Ancho", DepartamentoId = 7 },
                new Municipio { Id = 105, Nombre = "Yauyupe", DepartamentoId = 7 },
                new Municipio { Id = 106, Nombre = "Trojes", DepartamentoId = 7 }

            );



            //Francisco Morazán
            modelBuilder.Entity<Municipio>().HasData(

                new Municipio { Id = 107, Nombre = "Distrito Central", DepartamentoId = 8 },
                new Municipio { Id = 108, Nombre = "Alubarén", DepartamentoId = 8 },
                new Municipio { Id = 109, Nombre = "Cedros", DepartamentoId = 8 },
                new Municipio { Id = 110, Nombre = "Curarén", DepartamentoId = 8 },
                new Municipio { Id = 111, Nombre = "El Porvenir", DepartamentoId = 8 },
                new Municipio { Id = 112, Nombre = "Guaimaca", DepartamentoId = 8 },
                new Municipio { Id = 113, Nombre = "La Libertad", DepartamentoId = 8 },
                new Municipio { Id = 114, Nombre = "La Venta", DepartamentoId = 8 },
                new Municipio { Id = 115, Nombre = "Lepaterique", DepartamentoId = 8 },
                new Municipio { Id = 116, Nombre = "Maraita", DepartamentoId = 8 },
                new Municipio { Id = 117, Nombre = "Marale", DepartamentoId = 8 },
                new Municipio { Id = 118, Nombre = "Nueva Armenia", DepartamentoId = 8 },
                new Municipio { Id = 119, Nombre = "Ojojona", DepartamentoId = 8 },
                new Municipio { Id = 120, Nombre = "Orica", DepartamentoId = 8 },
                new Municipio { Id = 121, Nombre = "Reitoca", DepartamentoId = 8 },
                new Municipio { Id = 122, Nombre = "Sabanagrande", DepartamentoId = 8 },
                new Municipio { Id = 123, Nombre = "San Antonio de Oriente", DepartamentoId = 8 },
                new Municipio { Id = 124, Nombre = "San Buenaventura", DepartamentoId = 8 },
                new Municipio { Id = 125, Nombre = "San Ignacio", DepartamentoId = 8 },
                new Municipio { Id = 126, Nombre = "San Juan de Flores", DepartamentoId = 8 },
                new Municipio { Id = 127, Nombre = "San Miguelito", DepartamentoId = 8 },
                new Municipio { Id = 128, Nombre = "Santa Ana", DepartamentoId = 8 },
                new Municipio { Id = 129, Nombre = "Santa Lucía", DepartamentoId = 8 },
                new Municipio { Id = 130, Nombre = "Talanga", DepartamentoId = 8 },
                new Municipio { Id = 131, Nombre = "Tatumbla", DepartamentoId = 8 },
                new Municipio { Id = 132, Nombre = "Valle de Angeles", DepartamentoId = 8 },
                new Municipio { Id = 133, Nombre = "Villa de San Francisco", DepartamentoId = 8 },
                new Municipio { Id = 134, Nombre = "Vallecillo", DepartamentoId = 8 }

            );




            //Gracias a Dios
            modelBuilder.Entity<Municipio>().HasData(

                new Municipio { Id = 135, Nombre = "Puerto Lempira", DepartamentoId = 9 },
                new Municipio { Id = 136, Nombre = "Brus Laguna", DepartamentoId = 9 },
                new Municipio { Id = 137, Nombre = "Ahuas", DepartamentoId = 9 },
                new Municipio { Id = 138, Nombre = "Juan Francisco Bulnes", DepartamentoId = 9 },
                new Municipio { Id = 139, Nombre = "Villeda Morales", DepartamentoId = 9 },
                new Municipio { Id = 140, Nombre = "Wampusirpi", DepartamentoId = 9 }

            );



            //Intibucá
            modelBuilder.Entity<Municipio>().HasData(

                new Municipio { Id = 141, Nombre = "La Esperanza", DepartamentoId = 10 },
                new Municipio { Id = 142, Nombre = "Camasca", DepartamentoId = 10 },
                new Municipio { Id = 143, Nombre = "Colomoncagua", DepartamentoId = 10 },
                new Municipio { Id = 144, Nombre = "Concepción", DepartamentoId = 10 },
                new Municipio { Id = 145, Nombre = "Dolores", DepartamentoId = 10 },
                new Municipio { Id = 146, Nombre = "Intibucá", DepartamentoId = 10 },
                new Municipio { Id = 147, Nombre = "Jesús de Otoro", DepartamentoId = 10 },
                new Municipio { Id = 148, Nombre = "Magdalena", DepartamentoId = 10 },
                new Municipio { Id = 149, Nombre = "Masaguara", DepartamentoId = 10 },
                new Municipio { Id = 150, Nombre = "San Antonio", DepartamentoId = 10 },
                new Municipio { Id = 151, Nombre = "San Isidro", DepartamentoId = 10 },
                new Municipio { Id = 152, Nombre = "San Juan", DepartamentoId = 10 },
                new Municipio { Id = 153, Nombre = "San Marcos de La Sierra", DepartamentoId = 10 },
                new Municipio { Id = 154, Nombre = "San Miguelito", DepartamentoId = 10 },
                new Municipio { Id = 155, Nombre = "Santa Lucía", DepartamentoId = 10 },
                new Municipio { Id = 156, Nombre = "Yamaranguila", DepartamentoId = 10 },
                new Municipio { Id = 157, Nombre = "San Francisco de Opalaca", DepartamentoId = 10 }


            );


            //Isla de la Bahia
            modelBuilder.Entity<Municipio>().HasData(

                new Municipio { Id = 158, Nombre = "Roatán", DepartamentoId = 11 },
                new Municipio { Id = 159, Nombre = "Guanaja", DepartamentoId = 11 },
                new Municipio { Id = 160, Nombre = "José Santos Guardiola", DepartamentoId = 11 },
                new Municipio { Id = 161, Nombre = "Utila", DepartamentoId = 11 }

            );


            //La Paz
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 162, Nombre = "La Paz", DepartamentoId = 12 },
                new Municipio { Id = 163, Nombre = "Aguanqueterique", DepartamentoId = 12 },
                new Municipio { Id = 164, Nombre = "Cabañas", DepartamentoId = 12 },
                new Municipio { Id = 165, Nombre = "Cane", DepartamentoId = 12 },
                new Municipio { Id = 166, Nombre = "Chinacla", DepartamentoId = 12 },
                new Municipio { Id = 167, Nombre = "Guajiquiro", DepartamentoId = 12 },
                new Municipio { Id = 168, Nombre = "Lauterique", DepartamentoId = 12 },
                new Municipio { Id = 169, Nombre = "Marcala", DepartamentoId = 12 },
                new Municipio { Id = 170, Nombre = "Mercedes de Oriente", DepartamentoId = 12 },
                new Municipio { Id = 171, Nombre = "Opatoro", DepartamentoId = 12 },
                new Municipio { Id = 172, Nombre = "San Antonio del Norte", DepartamentoId = 12 },
                new Municipio { Id = 173, Nombre = "San José", DepartamentoId = 12 },
                new Municipio { Id = 174, Nombre = "San Juan", DepartamentoId = 12 },
                new Municipio { Id = 175, Nombre = "San Pedro de Tutule", DepartamentoId = 12 },
                new Municipio { Id = 176, Nombre = "Santa Ana", DepartamentoId = 12 },
                new Municipio { Id = 177, Nombre = "Santa Elena", DepartamentoId = 12 },
                new Municipio { Id = 178, Nombre = "Santa María", DepartamentoId = 12 },
                new Municipio { Id = 179, Nombre = "Santiago de Puringla", DepartamentoId = 12 },
                new Municipio { Id = 180, Nombre = "Yarula", DepartamentoId = 12 }


            );




            //Lempira
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 181, Nombre = "Gracias", DepartamentoId = 13 },
                new Municipio { Id = 182, Nombre = "Belén", DepartamentoId = 13 },
                new Municipio { Id = 183, Nombre = "Candelaria", DepartamentoId = 13 },
                new Municipio { Id = 184, Nombre = "Cololaca", DepartamentoId = 13 },
                new Municipio { Id = 185, Nombre = "Erandique", DepartamentoId = 13 },
                new Municipio { Id = 186, Nombre = "Gualcince", DepartamentoId = 13 },
                new Municipio { Id = 187, Nombre = "Guarita", DepartamentoId = 13 },
                new Municipio { Id = 188, Nombre = "La Campa", DepartamentoId = 13 },
                new Municipio { Id = 189, Nombre = "La Iguala", DepartamentoId = 13 },
                new Municipio { Id = 190, Nombre = "Las Flores", DepartamentoId = 13 },
                new Municipio { Id = 191, Nombre = "La Unión", DepartamentoId = 13 },
                new Municipio { Id = 192, Nombre = "La Virtud", DepartamentoId = 13 },
                new Municipio { Id = 193, Nombre = "Lepaera", DepartamentoId = 13 },
                new Municipio { Id = 194, Nombre = "Mapulaca", DepartamentoId = 13 },
                new Municipio { Id = 195, Nombre = "Piraera", DepartamentoId = 13 },
                new Municipio { Id = 196, Nombre = "San Andrés", DepartamentoId = 13 },
                new Municipio { Id = 197, Nombre = "San Francisco", DepartamentoId = 13 },
                new Municipio { Id = 198, Nombre = "San Juan Guarita", DepartamentoId = 13 },
                new Municipio { Id = 199, Nombre = "San Manuel Colohete", DepartamentoId = 13 },
                new Municipio { Id = 200, Nombre = "San Rafael", DepartamentoId = 13 },
                new Municipio { Id = 201, Nombre = "San Sebastián", DepartamentoId = 13 },
                new Municipio { Id = 202, Nombre = "Santa Cruz", DepartamentoId = 13 },
                new Municipio { Id = 203, Nombre = "Talgua", DepartamentoId = 13 },
                new Municipio { Id = 204, Nombre = "Tambla", DepartamentoId = 13 },
                new Municipio { Id = 205, Nombre = "Tomalá", DepartamentoId = 13 },
                new Municipio { Id = 206, Nombre = "Valladolid", DepartamentoId = 13 },
                new Municipio { Id = 207, Nombre = "Virginia", DepartamentoId = 13 },
                new Municipio { Id = 208, Nombre = "San Marcos de Caiquín", DepartamentoId = 13 }

            );




            //Ocotepeque
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 209, Nombre = "Ocotepeque", DepartamentoId = 14 },
                new Municipio { Id = 210, Nombre = "Belén Gualcho", DepartamentoId = 14 },
                new Municipio { Id = 211, Nombre = "Concepción", DepartamentoId = 14 },
                new Municipio { Id = 212, Nombre = "Dolores Merendón", DepartamentoId = 14 },
                new Municipio { Id = 213, Nombre = "Fraternidad", DepartamentoId = 14 },
                new Municipio { Id = 214, Nombre = "La Encarnación", DepartamentoId = 14 },
                new Municipio { Id = 215, Nombre = "La Labor", DepartamentoId = 14 },
                new Municipio { Id = 216, Nombre = "Lucerna", DepartamentoId = 14 },
                new Municipio { Id = 217, Nombre = "Mercedes", DepartamentoId = 14 },
                new Municipio { Id = 218, Nombre = "San Fernando", DepartamentoId = 14 },
                new Municipio { Id = 219, Nombre = "San Francisco del Valle", DepartamentoId = 14 },
                new Municipio { Id = 220, Nombre = "San Jorge", DepartamentoId = 14 },
                new Municipio { Id = 221, Nombre = "San Marcos", DepartamentoId = 14 },
                new Municipio { Id = 222, Nombre = "Santa Fe", DepartamentoId = 14 },
                new Municipio { Id = 223, Nombre = "Sensenti", DepartamentoId = 14 },
                new Municipio { Id = 224, Nombre = "Sinuapa", DepartamentoId = 14 }



            );




            //Olancho
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 225, Nombre = "Juticalpa", DepartamentoId = 15 },
                new Municipio { Id = 226, Nombre = "Campamento", DepartamentoId = 15 },
                new Municipio { Id = 227, Nombre = "Catacamas", DepartamentoId = 15 },
                new Municipio { Id = 228, Nombre = "Concordia", DepartamentoId = 15 },
                new Municipio { Id = 229, Nombre = "Dulce Nombre de Culmí", DepartamentoId = 15 },
                new Municipio { Id = 230, Nombre = "El Rosario", DepartamentoId = 15 },
                new Municipio { Id = 231, Nombre = "Esquipulas del Norte", DepartamentoId = 15 },
                new Municipio { Id = 232, Nombre = "Gualaco", DepartamentoId = 15 },
                new Municipio { Id = 233, Nombre = "Guarizama", DepartamentoId = 15 },
                new Municipio { Id = 234, Nombre = "Guata", DepartamentoId = 15 },
                new Municipio { Id = 235, Nombre = "Guayape", DepartamentoId = 15 },
                new Municipio { Id = 236, Nombre = "Jano", DepartamentoId = 15 },
                new Municipio { Id = 237, Nombre = "La Unión", DepartamentoId = 15 },
                new Municipio { Id = 238, Nombre = "Mangulile", DepartamentoId = 15 },
                new Municipio { Id = 239, Nombre = "Manto", DepartamentoId = 15 },
                new Municipio { Id = 240, Nombre = "Salamá", DepartamentoId = 15 },
                new Municipio { Id = 241, Nombre = "San Estebán", DepartamentoId = 15 },
                new Municipio { Id = 242, Nombre = "San Francisco de Becerra", DepartamentoId = 15 },
                new Municipio { Id = 243, Nombre = "San Francisco de La Paz", DepartamentoId = 15 },
                new Municipio { Id = 244, Nombre = "Santa María del Real", DepartamentoId = 15 },
                new Municipio { Id = 245, Nombre = "Silca", DepartamentoId = 15 },
                new Municipio { Id = 246, Nombre = "Yocón", DepartamentoId = 15 },
                new Municipio { Id = 247, Nombre = "Patuca", DepartamentoId = 15 }


            );




            //Santa Bárbara
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 248, Nombre = "Santa Bárbara", DepartamentoId = 16 },
                new Municipio { Id = 249, Nombre = "Arada", DepartamentoId = 16 },
                new Municipio { Id = 250, Nombre = "Atima", DepartamentoId = 16 },
                new Municipio { Id = 251, Nombre = "Azacualpa", DepartamentoId = 16 },
                new Municipio { Id = 252, Nombre = "Ceguaca", DepartamentoId = 16 },
                new Municipio { Id = 253, Nombre = "Concepción del Norte", DepartamentoId = 16 },
                new Municipio { Id = 254, Nombre = "Concepción del Sur", DepartamentoId = 16 },
                new Municipio { Id = 255, Nombre = "Chinda", DepartamentoId = 16 },
                new Municipio { Id = 256, Nombre = "El Níspero", DepartamentoId = 16 },
                new Municipio { Id = 257, Nombre = "Gualala", DepartamentoId = 16 },
                new Municipio { Id = 258, Nombre = "Ilama", DepartamentoId = 16 },
                new Municipio { Id = 259, Nombre = "Macuelizo", DepartamentoId = 16 },
                new Municipio { Id = 260, Nombre = "Naranjito", DepartamentoId = 16 },
                new Municipio { Id = 261, Nombre = "Nuevo Celilac", DepartamentoId = 16 },
                new Municipio { Id = 262, Nombre = "Petoa", DepartamentoId = 16 },
                new Municipio { Id = 263, Nombre = "Protección", DepartamentoId = 16 },
                new Municipio { Id = 264, Nombre = "Quimistán", DepartamentoId = 16 },
                new Municipio { Id = 265, Nombre = "San Francisco de Ojuera", DepartamentoId = 16 },
                new Municipio { Id = 266, Nombre = "San José de Colinas", DepartamentoId = 16 },
                new Municipio { Id = 267, Nombre = "San Luis", DepartamentoId = 16 },
                new Municipio { Id = 268, Nombre = "San Marcos", DepartamentoId = 16 },
                new Municipio { Id = 269, Nombre = "San Nicolás", DepartamentoId = 16 },
                new Municipio { Id = 270, Nombre = "San Pedro  Zacapa", DepartamentoId = 16 },
                new Municipio { Id = 271, Nombre = "San Vicente Centenario", DepartamentoId = 16 },
                new Municipio { Id = 272, Nombre = "Santa Rita", DepartamentoId = 16 },
                new Municipio { Id = 273, Nombre = "Trinidad", DepartamentoId = 16 },
                new Municipio { Id = 274, Nombre = "Las Vegas", DepartamentoId = 16 },
                new Municipio { Id = 275, Nombre = "Nueva Frontera", DepartamentoId = 16 }


            );





            //Valle
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 276, Nombre = "Nacaome", DepartamentoId = 17 },
                new Municipio { Id = 277, Nombre = "Alianza", DepartamentoId = 17 },
                new Municipio { Id = 278, Nombre = "Amapala", DepartamentoId = 17 },
                new Municipio { Id = 279, Nombre = "Aramecina", DepartamentoId = 17 },
                new Municipio { Id = 280, Nombre = "Caridad", DepartamentoId = 17 },
                new Municipio { Id = 281, Nombre = "Goascorán", DepartamentoId = 17 },
                new Municipio { Id = 282, Nombre = "Langue", DepartamentoId = 17 },
                new Municipio { Id = 283, Nombre = "San Francisco de Coray", DepartamentoId = 17 },
                new Municipio { Id = 284, Nombre = "San Lorenzo", DepartamentoId = 17 }



            );


            //Yoro
            modelBuilder.Entity<Municipio>().HasData(


                new Municipio { Id = 285, Nombre = "Yoro", DepartamentoId = 18 },
                new Municipio { Id = 286, Nombre = "Arenal", DepartamentoId = 18 },
                new Municipio { Id = 287, Nombre = "El Negrito", DepartamentoId = 18 },
                new Municipio { Id = 288, Nombre = "El Progreso", DepartamentoId = 18 },
                new Municipio { Id = 289, Nombre = "Jocón", DepartamentoId = 18 },
                new Municipio { Id = 290, Nombre = "Morazán", DepartamentoId = 18 },
                new Municipio { Id = 291, Nombre = "Olanchito", DepartamentoId = 18 },
                new Municipio { Id = 292, Nombre = "Santa Rita", DepartamentoId = 18 },
                new Municipio { Id = 293, Nombre = "Sulaco", DepartamentoId = 18 },
                new Municipio { Id = 294, Nombre = "Victoria", DepartamentoId = 18 },
                new Municipio { Id = 295, Nombre = "Yorito", DepartamentoId = 18 }


            );



            //data de categoria_plan
            modelBuilder.Entity<Categoria_planes>().HasData(

               new Categoria_planes { Id = 1,
                   precio= 0,
                   nombre_plan = "Versión Free", UpdateAt= DateTime.Now },
               new Categoria_planes { Id = 2, 
                   precio = 400,
                   nombre_plan = "Versión Clásica (Versión de Pago)", UpdateAt = DateTime.Now },
               new Categoria_planes { Id = 3,
                   precio = 1500,
                   nombre_plan = "Versión Oro (versión de Pago)", UpdateAt = DateTime.Now }

           );

            //data de planes version free
            modelBuilder.Entity<Planes>().HasData(

               new Planes { Id = 1, descripcion = "Registro e Información general.", id_categoria=1, UpdateAt = DateTime.Now },
               new Planes { Id = 2, descripcion = "Información Bancaria.", id_categoria = 1, UpdateAt = DateTime.Now },
               new Planes { Id = 3, descripcion = "Registrar los servicios que brinda.", id_categoria = 1, UpdateAt = DateTime.Now },
               new Planes { Id = 4, descripcion = "Notificación push y vía correo electrónico de las solicitudes de cotizaciones de los clientes para contratar sus servicios.", id_categoria = 1, UpdateAt = DateTime.Now },
               new Planes { Id = 5, descripcion = "En esta versión Free el proveedor solo podrá responder y aprobar 2 cotizaciones de servicios. Ya que tendrá que pasarse a la versión de pago si desea seguir contestando y aprobando cotizaciones de servicios de los clientes.", id_categoria = 1, UpdateAt = DateTime.Now },
               new Planes { Id = 6, descripcion = "El administrador podrá modificar la cantidad de cotizaciones que el proveedor podrá contestar en esta versión Free.", id_categoria = 1, UpdateAt = DateTime.Now }

           );

            //data de planes Versión Clásica (Versión de Pago)
            modelBuilder.Entity<Planes>().HasData(

               new Planes { Id = 7, 
                   descripcion = "Registro e Información general.",
                   id_categoria = 2, 
                   UpdateAt = DateTime.Now },

               new Planes
               {
                   Id = 8,
                   descripcion = "Información Bancaria.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 9,
                   descripcion = "Registrar los servicios que brinda",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 10,
                   descripcion = "Notificación push y vía correo electrónico de las solicitudes de cotizaciones para contratar sus servicios.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 11,
                   descripcion = "Generar cotizaciones y compartirlas a sus clientes desde la aplicación móvil.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 12,
                   descripcion = "Recibir y contestar mensajes.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 13,
                   descripcion = "Recibir Evaluación de los clientes.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 14,
                   descripcion = "Publicar 2 anuncios mensuales de promociones de sus servicios. El administrador podrá ampliar la cantidad de anuncios según la versión de pago.",
                   id_categoria = 2,
                   UpdateAt = DateTime.Now
               } 


           );

            //data de planes Versión Oro (versión de Pago)
            modelBuilder.Entity<Planes>().HasData(

               new Planes
               {
                   Id = 15,
                   descripcion = "Registro e Información general.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 16,
                   descripcion = "Información Bancaria.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 17,
                   descripcion = "Registrar los servicios que brinda",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 18,
                   descripcion = "Notificación push y vía correo electrónico de las solicitudes de cotizaciones para contratar sus servicios.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 19,
                   descripcion = "Chat para recibir y contestar mensajes.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 20,
                   descripcion = "Generar cotizaciones y compartirlas a sus clientes desde la aplicación móvil.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 21,
                   descripcion = "Recibir Evaluación de los clientes.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 22,
                   descripcion = "Publicar 4 anuncios mensuales de promociones de sus servicios. El administrador podrá ampliar la cantidad de anuncios según la versión de pago.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               },

               new Planes
               {
                   Id = 23,
                   descripcion = "Aparecer como las primeras opciones de búsqueda, siempre y cuando este bien calificado por los clientes.",
                   id_categoria = 3,
                   UpdateAt = DateTime.Now
               }


           );

            //preguntas de seguridad
             
            modelBuilder.Entity<Pregunta_Seguridad>().HasData(

               new Pregunta_Seguridad { Id = 1, 
                   descripcion = "¿Cuál es el nombre de tu primera mascota?",
                   UpdateAt = DateTime.Now },

                new Pregunta_Seguridad
                {
                    Id = 2,
                    descripcion = "¿Cuál es el nombre de tu libro favorito?",
                    UpdateAt = DateTime.Now
                },

                new Pregunta_Seguridad
                {
                    Id = 3,
                    descripcion = "¿Cuál es el tu canción favorita?",
                    UpdateAt = DateTime.Now
                },

                new Pregunta_Seguridad
                {
                    Id = 4,
                    descripcion = "¿Cuál es el tu color favorito?",
                    UpdateAt = DateTime.Now
                } 



           );

            var profesiones = new List<Profesion>
            {
                new Profesion { Id = 1, NombreProfesion = "Programador" },
                new Profesion { Id = 2, NombreProfesion = "Diseñador" },
                new Profesion { Id = 3, NombreProfesion = "Ingeniero" },
                new Profesion { Id = 4, NombreProfesion = "Médico" },
                new Profesion { Id = 5, NombreProfesion = "Abogado" },
                new Profesion { Id = 6, NombreProfesion = "Arquitecto" },
                new Profesion { Id = 7, NombreProfesion = "Psicólogo" },
                new Profesion { Id = 8, NombreProfesion = "Enfermero" },
                new Profesion { Id = 9, NombreProfesion = "Profesor" },
                new Profesion { Id = 10, NombreProfesion = "Periodista" },
                new Profesion { Id = 11, NombreProfesion = "Publicista" },
                new Profesion { Id = 12, NombreProfesion = "Contador" },
                new Profesion { Id = 13, NombreProfesion = "Economista" },
                new Profesion { Id = 14, NombreProfesion = "Ingeniero Civil" },
                new Profesion { Id = 15, NombreProfesion = "Ingeniero Industrial" },
                new Profesion { Id = 16, NombreProfesion = "Ingeniero en Sistemas" },
                new Profesion { Id = 17, NombreProfesion = "Analista de Sistemas" },
                new Profesion { Id = 18, NombreProfesion = "Consultor de Negocios" },
                new Profesion { Id = 19, NombreProfesion = "Chef" },
                new Profesion { Id = 20, NombreProfesion = "Decorador" },
                new Profesion { Id = 21, NombreProfesion = "Arquitecto" },
                new Profesion { Id = 22, NombreProfesion = "Contador" },
                new Profesion { Id = 23, NombreProfesion = "Abogado" },
                new Profesion { Id = 24, NombreProfesion = "Periodista" },
                new Profesion { Id = 25, NombreProfesion = "Psicólogo" },
                new Profesion { Id = 26, NombreProfesion = "Médico" },
                new Profesion { Id = 27, NombreProfesion = "Enfermero" },
                new Profesion { Id = 28, NombreProfesion = "Dentista" },
                new Profesion { Id = 29, NombreProfesion = "Farmacéutico" },
                new Profesion { Id = 30, NombreProfesion = "Nutricionista" },
                new Profesion { Id = 31, NombreProfesion = "Educador" },
                new Profesion { Id = 32, NombreProfesion = "Entrenador personal" },
                new Profesion { Id = 33, NombreProfesion = "Psicopedagogo" },
                new Profesion { Id = 34, NombreProfesion = "Economista" },
                new Profesion { Id = 35, NombreProfesion = "Ingeniero civil" },
                new Profesion { Id = 36, NombreProfesion = "Ingeniero de sistemas" },
                new Profesion { Id = 37, NombreProfesion = "Ingeniero mecánico" },
                new Profesion { Id = 38, NombreProfesion = "Ingeniero eléctrico" },
                new Profesion { Id = 39, NombreProfesion = "Ingeniero químico" },
                new Profesion { Id = 40, NombreProfesion = "Ingeniero industrial" }
                // Agrega más profesiones aquí si lo necesitas
            };

            // Agregamos todas las profesiones a la base de datos
            modelBuilder.Entity<Profesion>().HasData(profesiones);


            //fin del metodo oncreating
        }






        //fin

    }
}
