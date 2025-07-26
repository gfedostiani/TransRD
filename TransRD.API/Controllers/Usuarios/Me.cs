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
    public ActionResult Post([FromBody] int _id)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.usuario_id == _id)
        .FirstOrDefault();

      if (usuario == null) return BadRequest("That's not a valid user.");
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

      TransRDDb._context.Usuario
        .Attach(_usuario);
      TransRDDb._context.SaveChanges();

      return Ok("Updated User!");
    }
  }
}
