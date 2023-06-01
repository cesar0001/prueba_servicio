using FindServicesApp_BackEnd.Server.Data;
using FindServicesApp_BackEnd.Shared.Dto.firmaDto;
using FindServicesApp_BackEnd.Shared.Dto.preguntas_seguridadDto;
using FindServicesApp_BackEnd.Shared.Dto.usuarioDto;
using FindServicesApp_BackEnd.Shared.Models.departamento_municipios;
using FindServicesApp_BackEnd.Shared.Models.Encriptador;
using FindServicesApp_BackEnd.Shared.Models.Profesiones;
using FindServicesApp_BackEnd.Shared.Models.usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IO;
using System.Xml.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System.Runtime.Intrinsics.X86;

namespace FindServicesApp_BackEnd.Server.Controllers.usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UsuariosController : ControllerBase
    {

        /*
          probar aver si funciona
        var personasYNumeros_2 = from p in personas
                                     from n in numeros
                                     select new
                                     {
                                         Persona = p,
                                         Numero = n
                                     };
         */




        private readonly AppDbContext context;
        //para entrar a la configuracion appsetting.json
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment env;
        private readonly HttpContext _http;

        public UsuariosController(AppDbContext context, IConfiguration configuration, IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            _configuration = configuration;
            this.env = env;
            _http = contextAccessor.HttpContext;
        }

        [HttpPost("crearUsuario")]
        //con la instruccion de abajo estamos diciendo que puede usar sin token
        [AllowAnonymous]
        public async Task<ActionResult> crearUsuario(RegistroUsuario registroUsuario)
        {
            var data = await context.Users.FirstOrDefaultAsync(x => x.Email == registroUsuario.Email);
            //ver si el correo existe

            if (data == null)
            {
                registroUsuario.CreatedAt = DateTime.Now;
                registroUsuario.Password = Seguridad.Encriptar(registroUsuario.Password);
                //si no existe se guarda
                context.Add(registroUsuario);
                await context.SaveChangesAsync();
                return Ok(new { res = "true", token = BuildToken(registroUsuario) });
            }
            else
            {

                return Ok(new { res = "false" });
            }

            //return Ok(new { dato = "hola",res="true" });
        }

        [HttpPost("loginUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult> loginUsuario(Login login)
        {
            login.Password = Seguridad.Encriptar(login.Password);
            var data = await context.Users.FirstOrDefaultAsync(x => ((x.Email == login.Email) && (x.Password == login.Password)) == true);

            if (data == null)
            {
                //el usuario no existe
                return Ok(new { res = "false" });

            }
            else
            {
                return Ok(new { res = "true", token = BuildToken(data) });
            }



            //return Ok(new { dato = "hola", res = "true" });

        }


        [HttpGet("tenerUsuario/{id}")]
        //[AllowAnonymous]
        //con esta instruccion estamos diciendo que se ocupa el token
        public async Task<ActionResult> Get(string id)
        {
            int id_convertido = int.Parse(Seguridad.DesEncriptar(id));

            UsuarioGeneralDto data = await context.Users
                 .Include(x => x.Roll)
                 .Include(x => x.DatosGenerales)
                 .Include(x => x.DatosGeneralesFinal)
                 .Include(x => x.firma)
                 .Include(x => x.Contrato)
                 .Include(x => x.Pregunta_Contestadas)
                 .Select(p => new UsuarioGeneralDto
                 {
                     Id = p.Id,
                     Email = p.Email,
                     Password = p.Password,
                     id_roll = p.id_roll,
                     Roll = p.Roll,
                     DatosGenerales = p.DatosGenerales,
                     DatosGeneralesFinal = p.DatosGeneralesFinal,
                     firma = p.firma,
                     id_contrato = p.id_contrato,
                     Contrato = p.Contrato,
                     Contrato_aprobado = p.Contrato_aprobado,
                     contrato_firmado = p.contrato_firmado,
                     id_categoria_planes = p.id_categoria_planes,
                     categoria_planes = p.categoria_planes,
                     Pregunta_Contestadas = p.Pregunta_Contestadas,
                     Activo = p.Activo,
                     CreatedAt = p.CreatedAt,
                     UpdateAt = p.UpdateAt

                 })
                .FirstOrDefaultAsync(x => x.Id == id_convertido) ?? new UsuarioGeneralDto();

            //var data = await context.Users
            //     .Include(x => x.Roll)
            //     .Include(x => x.DatosGenerales)
            //     .Include(x => x.DatosGeneralesFinal)
            //     .Include(x => x.firma)
            //     .Include(x => x.Contrato)
            //     .Include(x => x.Pregunta_Contestadas)
            //    .FirstOrDefaultAsync(x => x.Id == id_convertido);




            //var cliente = context.Users.Include(c => c.DatosGenerales).FirstOrDefault(c => c.Id == 1);
            //return Ok(new { res = cliente });

            if (data == null)
            {
                UsuarioGeneralDto registro = new UsuarioGeneralDto();
                return Ok(registro);
            }
            else
            {
                if(data.DatosGeneralesFinal != null)
                {
                    if (string.IsNullOrEmpty(data.DatosGeneralesFinal.foto_perfil) == false)
                    {
                        data.DatosGeneralesFinal.foto_perfil =
                        $"{_http.Request.Scheme}://{_http.Request.Host}/fotos/{data.DatosGeneralesFinal.foto_perfil}";

                    }

                    if (string.IsNullOrEmpty(data.DatosGeneralesFinal.foto_identidad_adelantera) == false)
                    {
                        data.DatosGeneralesFinal.foto_identidad_adelantera =
                        $"{_http.Request.Scheme}://{_http.Request.Host}/identidad_adelante/{data.DatosGeneralesFinal.foto_identidad_adelantera}";

                    }

                    if (string.IsNullOrEmpty(data.DatosGeneralesFinal.foto_identidad_trasera) == false)
                    {
                        data.DatosGeneralesFinal.foto_identidad_trasera =
                        $"{_http.Request.Scheme}://{_http.Request.Host}/identidad_trasera/{data.DatosGeneralesFinal.foto_identidad_trasera}";

                    }
                }

                if (data.DatosGenerales != null)
                {
                    //if(string.IsNullOrEmpty(data.DatosGenerales.foto_personal) == false)
                    //{
                    //    data.DatosGenerales.foto_personal =
                    //    $"{_http.Request.Scheme}://{_http.Request.Host}/fotos/{data.DatosGenerales.foto_personal}";

                    //}

                    if (string.IsNullOrEmpty(data.DatosGenerales.id_profesion.ToString()) == false)
                    {
                        Profesion profesiones = new Profesion();
                        profesiones = await context.Profesion
                            .FirstOrDefaultAsync(x => x.Id == data.DatosGenerales.id_profesion) ?? new Profesion();
                        data.DatosGenerales.Profesion = profesiones;
                    }

                    Municipio municipio = await context.Municipios
                    .Where(x => x.Id == data.DatosGenerales.MunicipioId)
                    .Select(x => new Municipio
                    {
                        Id = x.Id,
                        DepartamentoId = x.DepartamentoId,
                        Nombre = x.Nombre
                    })
                    .FirstOrDefaultAsync() ?? new Municipio();

                    data.DatosGenerales.Estado = municipio;
                    //////////////////////////////////

                    Departamentos departamentos = await context.departamentos
                    .Where(x => x.Id == municipio.DepartamentoId)
                    .Select(x => new Departamentos
                    {
                        Id = x.Id,
                        Nombre = x.Nombre
                    })
                    .FirstOrDefaultAsync() ?? new Departamentos();


                    //Departamentos departamentos = new Departamentos();
                    //departamentos = await context.departamentos
                    //        .FirstOrDefaultAsync(x => x.Id == municipio.DepartamentoId);
                    data.DatosGenerales.departamentos = departamentos;

                }
                if (data.firma != null)
                {
                    if (string.IsNullOrEmpty(data.firma.Firma) == false)
                    {
                        data.firma.Firma =
                        $"{_http.Request.Scheme}://{_http.Request.Host}/firmas/{data.firma.Firma}";

                    }

                }

                data.cantidad_experiencia_lab = await context.Experiencia_Laboral
                .Where(x => x.RegistroUsuarioId == id_convertido)
                .CountAsync();

                data.cantidad_educacion = await context.Educacion
                .Where(x => x.RegistroUsuarioId == id_convertido)
                .CountAsync();


                data.Password = Seguridad.DesEncriptar(data.Password);
                return Ok(data);

            }

            /*
             coloco esta informacion aqui por si se desea hacer un filtrado
            usando lo quees DTO
            public class PersonaDTO
            {
                public int Id { get; set; }
                public string Nombre { get; set; }
                public int EstadoId { get; set; }
            }

             var personas = _context.Personas
            .Include(p => p.Estado)
            .Select(p => new PersonaViewModel
            {
                Id = p.Id,
                Nombre = p.Nombre,
                EstadoId = p.Estado.Id
            })
            .ToList();

            //otra forma
             
             var data = await context.Users
                 .Include(x => x.Roll)
                 .Include(x => x.DatosGenerales)
                 .Include(x => x.firma)
                  .Where(x => x.Id == id_convertido)
                 .Select(x => new
                 {
                     Rol = x.Roll.name,
                     Email = x.firma.Firma
                 })
                .FirstOrDefaultAsync( );
             
             */


        }


        [HttpPost("crearDatosGenerales")]
        public async Task<ActionResult> crearDatosGenerales(DatosGeneralesDto datosGenerales)
        {

            var data = await context.Datos_Generales.FirstOrDefaultAsync(x => x.RegistroUsuarioId == datosGenerales.RegistroUsuarioId  );

            if (data == null)
            {

 

                DatosGenerales datosAGuardar = new DatosGenerales();
                datosAGuardar.Id = datosGenerales.Id; 
                datosAGuardar.Nombre = datosGenerales.Nombre;
                datosAGuardar.Apellido = datosGenerales.Apellido;
                datosAGuardar.id_profesion = datosGenerales.id_profesion;
                datosAGuardar.Identidad = datosGenerales.Identidad;
                datosAGuardar.Fecha_nacimiento = datosGenerales.Fecha_nacimiento;
                datosAGuardar.Genero = datosGenerales.Genero;
                datosAGuardar.Opinion_Personal = datosGenerales.Opinion_Personal;
                datosAGuardar.RegistroUsuarioId = datosGenerales.RegistroUsuarioId;
                datosAGuardar.RegistroUsuario = datosGenerales.RegistroUsuario;
                datosAGuardar.MunicipioId = datosGenerales.MunicipioId;
                datosAGuardar.DepartamentoId = datosGenerales.DepartamentoId;
                datosAGuardar.Estado = datosGenerales.Estado;
                datosAGuardar.latitud = datosGenerales.latitud;
                datosAGuardar.longitud = datosGenerales.longitud;
                datosAGuardar.Celular = datosGenerales.Celular;
                datosAGuardar.Telefono = datosGenerales.Telefono;
                datosAGuardar.Direccion = datosGenerales.Direccion;
                datosAGuardar.Facebook = datosGenerales.Facebook;
                datosAGuardar.Instagram = datosGenerales.Instagram;
 

                //if (string.IsNullOrEmpty(datosGenerales.Imagen.FileName) == false)
                //{
                //    //formato de fecha el id es de la tabla datos_generales dia-mes-año
                //    string nombre = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos";
                //    var extension = System.IO.Path.GetExtension(datosGenerales.Imagen.FileName);

                //    //Guid.NewGuid() //con esta funcion saca dato unico
                //    string nameComplete = $"{nombre}{extension}";

                //    var path = $"{env.WebRootPath}/fotos/{nameComplete}";
                //    //var path = $"{env.WebRootPath}\\{nameComplete}";
                //    var fs = System.IO.File.Create(path);
                //    fs.Write(datosGenerales.Imagen.FileContent, 0,
                //    datosGenerales.Imagen.FileContent.Length);
                //    fs.Close();

                //    datosAGuardar.foto_personal = nameComplete;
                //}
                //else
                //{
                //    datosAGuardar.foto_personal = null;
                //}
 

                //--------------------------------------
                datosGenerales.CreatedAt = DateTime.Now;
                context.Datos_Generales.Add(datosAGuardar);

                await context.SaveChangesAsync();
                return Ok(new { res = "true" });

            }
            else
            {
                //entra aqui para modificar datos_generales
                //if (data.foto_personal != null)
                //{
                //    data.UpdateAt = DateTime.Now;
                //    var imagePath = Path.Combine(env.WebRootPath, "fotos", data.foto_personal);

                //    if (System.IO.File.Exists(imagePath) == true)
                //    {
                //        System.IO.File.Delete(imagePath);
                //    }

                //}


                data.Nombre = datosGenerales.Nombre;
                data.Apellido = datosGenerales.Apellido;
                data.id_profesion = datosGenerales.id_profesion;
                data.Identidad = datosGenerales.Identidad;
                data.Fecha_nacimiento = datosGenerales.Fecha_nacimiento;
                data.Genero = datosGenerales.Genero;
                data.Opinion_Personal = datosGenerales.Opinion_Personal;
                data.RegistroUsuarioId = datosGenerales.RegistroUsuarioId;
                data.RegistroUsuario = datosGenerales.RegistroUsuario;
                data.MunicipioId = datosGenerales.MunicipioId;
                data.DepartamentoId = datosGenerales.DepartamentoId;
                data.Estado = datosGenerales.Estado;
                data.latitud = datosGenerales.latitud;
                data.longitud = datosGenerales.longitud;
                data.Celular = datosGenerales.Celular;
                data.Telefono = datosGenerales.Telefono;
                data.Direccion = datosGenerales.Direccion;
                data.Facebook = datosGenerales.Facebook;
                data.Instagram = datosGenerales.Instagram;

                //if (string.IsNullOrEmpty(datosGenerales.Imagen.FileName) == false)
                //{
                //    //formato de fecha el id es de la tabla datos_generales dia-mes-año
                //    string nombre = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos";
                //    var extension = System.IO.Path.GetExtension(datosGenerales.Imagen.FileName);

                //    //Guid.NewGuid() //con esta funcion saca dato unico
                //    string nameComplete = $"{nombre}{extension}";

                //    var path = $"{env.WebRootPath}/fotos/{nameComplete}";
                //    //var path = $"{env.WebRootPath}\\{nameComplete}";
                //    var fs = System.IO.File.Create(path);
                //    fs.Write(datosGenerales.Imagen.FileContent, 0,
                //    datosGenerales.Imagen.FileContent.Length);
                //    fs.Close();

                //    data.foto_personal = nameComplete;
                //}
                //else
                //{
                //    data.foto_personal = null;
                //}
                data.UpdateAt = DateTime.Now;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                //si es false es porque ya se creo
                return Ok(new { res = "true" });
            }



        }

 

        //api para firma
        [HttpPost("crearFirma")]
        public async Task<ActionResult> crearFirma(FirmaCreateOrEditDto firma)
        {

            var data = await context.firmas_usuarios.FirstOrDefaultAsync(x => x.RegistroUsuarioId == firma.idUsuario);

            if (data == null)
            {

                string carpeta_firma = Path.Combine(env.WebRootPath, "firmas");

                if (!Directory.Exists(carpeta_firma))
                {
                    Directory.CreateDirectory(carpeta_firma);

                }

                //formato de fecha dia-mes-año
                string nombre = $"{firma.idUsuario}_{DateTime.Now.ToString("dd-MM-yyyy")}_firmas";
                var extension = System.IO.Path.GetExtension(firma.FileName);

                //Guid.NewGuid() //con esta funcion saca dato unico
                string nameComplete = $"{nombre}{extension}";

                var path = $"{env.WebRootPath}/firmas/{nameComplete}";
              
                //var fs = System.IO.File.Create(path);
                //fs.Write(firma.FileContent, 0,
                //firma.FileContent.Length);
                //fs.Close();

                await ResizeImage(path, firma.FileContent);

                FirmaContrato takeData = new FirmaContrato();
                takeData.RegistroUsuarioId = firma.idUsuario;
                takeData.CreatedAt = DateTime.Now;
                takeData.Firma = nameComplete;

                context.firmas_usuarios.Add(takeData);

                await context.SaveChangesAsync();
                return Ok(new { res = "true" });

            }
            else
            {
                await EliminarFotoAlmacenada("firmas", data.Firma);
                //UpdateAt = DateTime.Now;
                //formato de fecha dia-mes-año
                string nombre = $"{firma.idUsuario}_{DateTime.Now.ToString("dd-MM-yyyy")}_firmas";
                var extension = System.IO.Path.GetExtension(firma.FileName);

                //Guid.NewGuid() //con esta funcion saca dato unico
                string nameComplete = $"{nombre}{extension}";

                var path = $"{env.WebRootPath}/firmas/{nameComplete}";

                await ResizeImage(path, firma.FileContent);

                data.Firma = nameComplete;
                data.UpdateAt = DateTime.Now;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(new { res = "true" });
            }



        }


        [HttpPost("modificar/usuario")]
        public async Task<ActionResult> modificarDataUsuario(UsuarioModificarDto dataUser)
        {
            string contraActual = Seguridad.Encriptar(dataUser.ContraseñaActual);
            var data = await context.Users.FirstOrDefaultAsync(x => (x.Id == dataUser.Id)==true && (x.Password == contraActual) == true  );

            if (data == null)
            {

                //UpdateAt = DateTime.Now;
                //si es false es porque ya se creo
                return Ok(new { res = "false" });
            }
            else
            {

                data.Password = Seguridad.Encriptar(dataUser.ConfirmarContraseña); ;
                data.UpdateAt = DateTime.Now;
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { res = "true" });
            }



        }

        [HttpPost("modificar/imagen/usuario")]
        public async Task<ActionResult> modificarImageUsuario(ImagenLocal dataUser)
        {
            
            var data = await context.Users.Include(x => x.DatosGenerales).FirstOrDefaultAsync(x => (x.Id == dataUser.Id) == true  );

            if (data == null)
            {

                //UpdateAt = DateTime.Now;
                //si es false es porque ya se creo
                return Ok(new { res = "false" });
            }
            else
            {

                //if(data.DatosGenerales.foto_personal != null)
                //{
                //    data.UpdateAt = DateTime.Now;
                //    var imagePath = Path.Combine(env.WebRootPath, "fotos", data.DatosGenerales.foto_personal);

                //    if (System.IO.File.Exists(imagePath) == true)
                //    {
                //        System.IO.File.Delete(imagePath);
                //    }
                     
                //}


                if (string.IsNullOrEmpty(dataUser.FileName) == false)
                {
                    //if (dataUser.FileContent != null)
                    //{
                    //    //formato de fecha el id es de la tabla datos_generales dia-mes-año
                    //    string nombre = $"{data.Id}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos";
                    //    var extension = System.IO.Path.GetExtension(dataUser.FileName);

                    //    //Guid.NewGuid() //con esta funcion saca dato unico
                    //    string nameComplete = $"{nombre}{extension}";

                    //    var path = $"{env.WebRootPath}/fotos/{nameComplete}";
                    //    //var path = $"{env.WebRootPath}\\{nameComplete}";
                    //    var fs = System.IO.File.Create(path);
                    //    fs.Write(dataUser.FileContent, 0,
                    //    dataUser.FileContent.Length);
                    //    fs.Close();


 




                    //    data.DatosGenerales.foto_personal = nameComplete;
                    //}

                    context.Entry(data).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                }
 
                 
                return Ok(new { res = "true" });


            }



        }

        [HttpPost("existe/correo")]
        [AllowAnonymous] //no quitar
        public async Task<ActionResult> ExisteCorreo(existeCorreoDto login)
        {
 
            var data = await context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);

            if (data == null)
            {
                //el usuario no existe
                return Ok(new { res = "false" });
            }
            else
            {
                return Ok(new { res = "true" });
            }

        }

        [HttpPost("tener/pregunta/correo")]
        [AllowAnonymous] //esta no quitar
        public async Task<ActionResult> DataPorCorreo(existeCorreoDto correo)
        {

            var data = await context.Users
                .Include(x => x.Pregunta_Contestadas)
                .FirstOrDefaultAsync(x => x.Email == correo.Email);

            if (data == null)
            {
                //el usuario no existe
                return Ok(new { res = "false" });
            }
            else
            {
                if(data.Pregunta_Contestadas==null)
                {
                    return Ok(new { otro = "error" });
                }

                var pregunta = await context.Pregunta_Seguridad.FirstOrDefaultAsync(x => x.Id == data.Pregunta_Contestadas.PreguntaSeguridadId);
                recuperando_claveDto salida = new recuperando_claveDto();
                salida.idUsuario = data.Id;
                salida.idPreguntaSeguridad = pregunta.Id; 
                salida.miPregunta = pregunta.descripcion;
                salida.miRespuesta = data.Pregunta_Contestadas.respuesta;


                return Ok(new { res = "true", modelo = salida });
            }

        }

        [HttpPost("cambiar/password/pregunta")]
        [AllowAnonymous] //no quitar
        public async Task<ActionResult> cambiarPasworPregunta(CambiarContraseaDto clave)
        {

            var data = await context.Users
                .FirstOrDefaultAsync(x => x.Id == clave.IdUsuario);

            if (data == null)
            {
                //el usuario no existe
                return Ok(new { res = "false" });
            }
            else
            {
                data.Password = Seguridad.Encriptar(clave.ClaveNueva);
                context.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(new { res = "true"  });
            }

        }



        [HttpPost("crearDatosGeneralesFinal")]
        public async Task<ActionResult> crearDatosGeneralesFinal(DatoGeneralesFinalDto datosGenerales)
        {

            var data = await context.Datos_Generales_Final.FirstOrDefaultAsync(x => x.RegistroUsuarioId == datosGenerales.RegistroUsuarioId);

            if (data == null)
            {
                string carpeta_fotos = Path.Combine(env.WebRootPath, "fotos");
                string carpeta_identidad_adelante = Path.Combine(env.WebRootPath, "identidad_adelante");
                string carpeta_identidad_trasera = Path.Combine(env.WebRootPath, "identidad_trasera");

                if (!Directory.Exists(carpeta_identidad_trasera))
                {
                    Directory.CreateDirectory(carpeta_identidad_trasera);

                }

                if (!Directory.Exists(carpeta_identidad_adelante))
                {
                    Directory.CreateDirectory(carpeta_identidad_adelante);

                }

                if (!Directory.Exists(carpeta_fotos))
                {
                    Directory.CreateDirectory(carpeta_fotos);
                    
                }


                string nombre_perfil = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos.png";
                //await GuardarByteAImagen(datosGenerales.Imagen_perfil.FileContent, "fotos", nombre_perfil); 
                await ResizeImage($"{env.WebRootPath}/fotos/{nombre_perfil}", datosGenerales.Imagen_perfil.FileContent);

                string nombre_identidad_adelante = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_identidad_adelante.png";
                //await GuardarByteAImagen(datosGenerales.Imagen_identidad_delantera.FileContent, "identidad_adelante", nombre_identidad_adelante);
                await ResizeImage($"{env.WebRootPath}/identidad_adelante/{nombre_identidad_adelante}", datosGenerales.Imagen_identidad_delantera.FileContent);

                string nombre_identidad_trasera = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_identidad_trasera.png";
                //await GuardarByteAImagen(datosGenerales.Imagen_identidad_trasera.FileContent, "identidad_trasera", nombre_identidad_trasera);
                await ResizeImage($"{env.WebRootPath}/identidad_trasera/{nombre_identidad_trasera}", datosGenerales.Imagen_identidad_trasera.FileContent);


                DatoGeneralesFinal datosAGuardar = new DatoGeneralesFinal();
                datosAGuardar.Id = datosGenerales.Id;
 
                datosAGuardar.foto_perfil = nombre_perfil;
                datosAGuardar.foto_identidad_adelantera = nombre_identidad_adelante;
                datosAGuardar.foto_identidad_trasera = nombre_identidad_trasera;
                datosAGuardar.RegistroUsuarioId = datosGenerales.RegistroUsuarioId;


                datosGenerales.CreatedAt = DateTime.Now;
                context.Datos_Generales_Final.Add(datosAGuardar);

                await context.SaveChangesAsync();
                return Ok(new { res = "true" });

            }
            else
            {

                //entra aqui para modificar datos_generales
           

                string nombre_perfil, nombre_identidad_adelante="", nombre_identidad_trasera="";

                if (datosGenerales.Imagen_perfil.esHttp == true)
                {
                    nombre_perfil = data.foto_perfil;
                }
                else
                {
                    await EliminarFotoAlmacenada("fotos", data.foto_perfil);
                    nombre_perfil = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos.png";
                    //await GuardarByteAImagen(datosGenerales.Imagen_perfil.FileContent, "fotos", nombre_perfil);
                    await ResizeImage($"{env.WebRootPath}/fotos/{nombre_perfil}", datosGenerales.Imagen_perfil.FileContent);

                }

                //identidad adelantera
                if (datosGenerales.Imagen_identidad_delantera.esHttp == true)
                {
                    nombre_identidad_adelante = data.foto_identidad_adelantera;
                }
                else
                {
                    await EliminarFotoAlmacenada("identidad_adelante", data.foto_identidad_adelantera);
                    nombre_identidad_adelante = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_identidad_adelante.png";
                    //await GuardarByteAImagen(datosGenerales.Imagen_identidad_delantera.FileContent, "identidad_adelante", nombre_identidad_adelante);
                    await ResizeImage($"{env.WebRootPath}/identidad_adelante/{nombre_identidad_adelante}", datosGenerales.Imagen_identidad_delantera.FileContent);

                }

                //identidad trasera
                if (datosGenerales.Imagen_identidad_trasera.esHttp == true)
                {
                    nombre_identidad_trasera = data.foto_identidad_trasera;
                }
                else
                {
                    await EliminarFotoAlmacenada("identidad_trasera", data.foto_identidad_trasera);
                    nombre_identidad_trasera = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_identidad_trasera.png";
                    //await GuardarByteAImagen(datosGenerales.Imagen_identidad_trasera.FileContent, "identidad_trasera", nombre_identidad_trasera);
                    await ResizeImage($"{env.WebRootPath}/identidad_trasera/{nombre_identidad_trasera}", datosGenerales.Imagen_identidad_trasera.FileContent);
                }

                data.foto_perfil = nombre_perfil;
                data.foto_identidad_adelantera = nombre_identidad_adelante;
                data.foto_identidad_trasera = nombre_identidad_trasera;
                

                //if (string.IsNullOrEmpty(datosGenerales.Imagen.FileName) == false)
                //{
                //    //formato de fecha el id es de la tabla datos_generales dia-mes-año
                //    string nombre = $"{datosGenerales.RegistroUsuarioId}_{DateTime.Now.ToString("dd-MM-yyyy")}_fotos";
                //    var extension = System.IO.Path.GetExtension(datosGenerales.Imagen.FileName);

                //    //Guid.NewGuid() //con esta funcion saca dato unico
                //    string nameComplete = $"{nombre}{extension}";

                //    var path = $"{env.WebRootPath}/fotos/{nameComplete}";
                //    //var path = $"{env.WebRootPath}\\{nameComplete}";
                //    var fs = System.IO.File.Create(path);
                //    fs.Write(datosGenerales.Imagen.FileContent, 0,
                //    datosGenerales.Imagen.FileContent.Length);
                //    fs.Close();

                //    data.foto_personal = nameComplete;
                //}
                //else
                //{
                //    data.foto_personal = null;
                //}
                 data.UpdateAt = DateTime.Now;
                 context.Entry(data).State = EntityState.Modified;
                 await context.SaveChangesAsync();
                
                return Ok(new { res = "true" });
            }



        }

        async Task GuardarByteAImagen(byte[] data, string donde, string nombre)
        {
            //Task.Run se usa en una funcion larga
            await Task.Run(() =>
            {
                //ejemplo  https://programa.com/,  donde=foto, nombre=melisa.png
                string path = Path.Combine(env.WebRootPath, donde, nombre);
                 
                System.IO.File.WriteAllBytes(path, data);

            });
        }

        public async Task EliminarFotoAlmacenada(string lugar, string nombre)
        {
            var imagePath = Path.Combine(env.WebRootPath, lugar, nombre);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        private async Task ResizeImage(string path, byte[] data)
        {
            //https://www.youtube.com/watch?v=Dc2_9CPLKCw
            //https://sixlabors.com/products/imagesharp/

            try
            {

                using (Image image = Image.Load(data))
                {
                    if (image.Width > 1024)
                    {
                        image.Mutate(x => x.Resize(700, ((700 * image.Height) / image.Width)));
                        await image.SaveAsync(path);
                    }
                    else
                    {
                        if (image.Width > 600)
                        {
                            image.Mutate(x => x.Resize(540, ((540 * image.Height) / image.Width)));
                            await image.SaveAsync(path);
                        }
                        else
                        {
                            await image.SaveAsync(path);

                        }
                             
                    }


                }


            }
            catch (Exception)
            {


            }

        }

        //construir el token
        private string BuildToken(RegistroUsuario userInfo)
        {

            var fecha_expiracion = DateTime.UtcNow.AddHours(1);

            // Cabecera
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["jwt:key"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // Claims
            var _Claims = new[] {
                new Claim("data",  Seguridad.Encriptar(userInfo.Id.ToString())),
                new Claim(ClaimTypes.Role, userInfo.id_roll.ToString()),
                new Claim("correo", userInfo.Email),
                new Claim("expiracion_token", fecha_expiracion.ToString("dd")+"/"+fecha_expiracion.ToString("MM")+"/"+fecha_expiracion.ToString("yyyy")),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //Payload
            var _Payload = new JwtPayload(
                    issuer: _configuration["jwt:Issuer"],
                    audience: _configuration["jwt:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                     expires: fecha_expiracion
                );

            // Token
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }


        //


    }
}
