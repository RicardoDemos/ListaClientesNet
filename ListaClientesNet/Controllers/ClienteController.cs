using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ListaClientesNet.Controllers
{
    public class ClienteController : Controller
    {

        AppDBEntities db = new AppDBEntities();

        public ActionResult Index()
        {
            //Testmail();

            List<Models.ClienteModel> lista = new List<Models.ClienteModel>();

            lista = (from u in db.Cliente
                     select new Models.ClienteModel
                     {
                         id = u.ID,
                         dni = u.DNI,
                         nombre = u.Nombre,
                         apellido = u.Apellido,
                         email = u.Email,
                         telefono = u.Telefono,
                         nacimiento = (DateTime) u.Nacimiento,
                         pais = u.Pais
                     }).ToList();

            return View(lista);
        }


        //FUNCION EXPERIMENTAL
        public ActionResult SendMail(int id, string email)
        {
            try
            {
                
                //Construir URL para mejor visualizacion
                string host = System.Web.HttpContext.Current.Request.Url.Host;
                int port = System.Web.HttpContext.Current.Request.Url.Port;
                string url = String.Format("https://{0}:{1}/Cliente/Datos/{2}", host, port, id);

                //Datos de email de origen
                var mailOrigen = "test@test.com"; //Modificar segun sea el caso
                var passOrigen = "1234"; //Modificar segun sea el caso
                var nombreOrigen = "Origen";
                

                //Nombre receptor generico
                var nombreReceptor = "Receptor";


                //Construir objetos
                var dirOrigen = new MailAddress(mailOrigen, nombreOrigen);
                var dirReceptor = new MailAddress(email, nombreReceptor);


                //Construyendo el contenido del email
                var sub = "OTRA PRUEBA CON ID " + id;
                var body = "SAMPLE TEXT: \nID DEL ITEM " + id + "\n" + url;
                var smtp = new SmtpClient
                {
                    Host = "smtp-mail.outlook.com",     //Modificar segun sea el caso
                    Port = 587,     //Modificar segun sea el caso
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(dirOrigen.Address, passOrigen)
                };

                using (var mess = new MailMessage(dirOrigen, dirReceptor)
                {
                    Subject = sub,
                    Body = body
                })
                
                {
                    smtp.Send(mess);
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Models.ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                Cliente cl = new Cliente();
                cl.Nombre = model.nombre;
                cl.Apellido = model.apellido;
                cl.DNI = model.dni;
                cl.Email = model.email;
                cl.Pais = model.pais;
                cl.Nacimiento = model.nacimiento;
                cl.Telefono = model.telefono;

                db.Cliente.Add(cl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Datos(int id)
        {
            Models.ClienteModel cliente = (from u in db.Cliente
                                           where u.ID == id
                                           select new Models.ClienteModel
                                           {
                                               id = u.ID,
                                               activado  = (int) u.Activar,
                                               apellido = u.Apellido,
                                               dni = u.DNI,
                                               nombre = u.Nombre,

                                               empresa = u.Empresa,
                                               intereses = u.Intereses,
                                               twitter = u.Twitter,
                                               genero = u.Genero
                                               
                                           }).FirstOrDefault();

            return View(cliente);
        }


        [HttpPost]
        public ActionResult Datos(Models.ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = (from u in db.Cliente
                                   where u.ID == model.id
                                   select u).FirstOrDefault();

                cliente.Empresa = model.empresa;
                cliente.Intereses = model.intereses;
                cliente.Twitter = model.twitter;
                cliente.Genero = model.genero;
                cliente.Activar = 1;


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }




        public ActionResult Details(int id)
        {

            Models.ClienteModel cliente = (from u in db.Cliente
                                           where u.ID == id
                                           select new Models.ClienteModel
                                           {
                                               id = u.ID,
                                               activado = (int) u.Activar,
                                               apellido = u.Apellido,
                                               dni = u.DNI,
                                               nombre = u.Nombre,
                                               email = u.Email,
                                               nacimiento = (DateTime)u.Nacimiento,
                                               pais = u.Pais,
                                               telefono = u.Telefono,
                                               empresa = u.Empresa,
                                               twitter = u.Twitter,
                                               intereses = u.Intereses,
                                               genero = u.Genero
                                           }).FirstOrDefault();

            return View(cliente);
        }


        public ActionResult Edit(int id)
        {

            Models.ClienteModel cliente = (from u in db.Cliente
                                           where u.ID == id
                                           select new Models.ClienteModel 
                                           { 
                                               id = u.ID,
                                               activado = (int) u.Activar,
                                               apellido = u.Apellido,
                                               dni = u.DNI,
                                               nombre = u.Nombre,
                                               email = u.Email,
                                               nacimiento = (DateTime)u.Nacimiento,
                                               pais = u.Pais,
                                               telefono = u.Telefono,
                                               empresa = u.Empresa,
                                               twitter = u.Twitter,
                                               intereses = u.Intereses,
                                               genero = u.Genero
                                           }).FirstOrDefault();

            return View(cliente);
        }


        [HttpPost]
        public ActionResult Edit(Models.ClienteModel model)
        {
            if (ModelState.IsValid)
            {

                Cliente cliente = (from u in db.Cliente
                                   where u.ID == model.id
                                   select u).FirstOrDefault();

                cliente.Nombre = model.nombre;
                cliente.Apellido = model.apellido;
                cliente.DNI = model.dni;
                cliente.Email = model.email;
                cliente.Pais = model.pais;
                cliente.Nacimiento = model.nacimiento;
                cliente.Telefono = model.telefono;
                cliente.Empresa = model.empresa;
                cliente.Twitter = model.twitter;
                cliente.Intereses = model.intereses;
                cliente.Genero = model.genero;



                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Delete(int id)
        {

            Cliente cliente = (from u in db.Cliente
                               where u.ID == id
                               select u).FirstOrDefault();

            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
