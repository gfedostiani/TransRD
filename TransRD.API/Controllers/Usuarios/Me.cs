using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TransRD.APi.Controllers;
using TransRD.Infraestructura.Models;

namespace TransRD.API.Controllers.Usuarios
{
  [Route("usuarios/[controller]")]
  [ApiController]
  public class Me : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    [HttpGet]
    public ActionResult Get(int _id)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.usuario_id == _id)
        .FirstOrDefault();

      if (usuario == null) return BadRequest("You're not logged in.");
      return Ok(usuario);
    }
    [HttpPut]
    public ActionResult Put([FromBody] Usuario _usuario)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.usuario_id == _usuario.usuario_id)
        .FirstOrDefault();

      if (usuario == null) return BadRequest("User Doesn't Exist");

      usuario.nombre = _usuario.nombre;
      usuario.email = _usuario.email;
      usuario.estado = _usuario.estado ?? "Activo";
      usuario.telefono = _usuario.telefono;
      usuario.contraseña = _usuario.contraseña;

      TransRDDb._context.Usuario.Update(usuario);
      TransRDDb._context.SaveChanges();
      //
      return Ok("Updated User!");
    }
  }
}
