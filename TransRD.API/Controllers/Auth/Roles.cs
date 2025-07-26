using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransRD.APi.Controllers;
using TransRD.API.Controllers.Usuarios;
using TransRD.Infraestructura.Models;

namespace TransRD.API.Controllers.Auth
{
  [Route("auth/[controller]")]
  [ApiController]
  public class Roles : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    [HttpGet]
    public ActionResult Get(int id)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.usuario_id == id)
        .FirstOrDefault();

      if (usuario == null) return BadRequest("Invalid User!");

      return Ok(usuario.roles);
    }
  }
}
