using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceFarmacia.Models;
using WebServiceFarmacia.Models.Request;
using WebServiceFarmacia.Models.Response;

namespace WebServiceFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (DrogueriaP3sContext db = new DrogueriaP3sContext())
                {
                    var lst = db.Cliente.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }

            }
            catch (Exception ex){
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (DrogueriaP3sContext db = new DrogueriaP3sContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombres = model.Nombres;
                    oCliente.Apellidos = model.Apellidos;
                    oCliente.Celular = model.Celular;
                    oCliente.Telefono = model.Telefono;
                    oCliente.Correo = model.Correo;
                    oCliente.FechaNac = model.FechaNac;

                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest model)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (DrogueriaP3sContext db = new DrogueriaP3sContext())
                {
                    Cliente oCliente = db.Cliente.Find(model.Id);
                    oCliente.Nombres = model.Nombres;
                    oCliente.Apellidos = model.Apellidos;
                    oCliente.Celular = model.Celular;
                    oCliente.Telefono = model.Telefono;
                    oCliente.Correo = model.Correo;
                    oCliente.FechaNac = model.FechaNac;

                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (DrogueriaP3sContext db = new DrogueriaP3sContext())
                {
                    Cliente oCliente = db.Cliente.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


    }
}