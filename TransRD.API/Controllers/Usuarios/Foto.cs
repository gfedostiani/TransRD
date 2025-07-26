using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransRD.APi.Controllers;
using TransRD.Infraestructura.Models;

namespace TransRD.API.Controllers.Usuarios
{

  public class FotoData 
  {
    public Usuario usuario;
    public string foto;
   }
  [Route("usuarios/[controller]")]
  [ApiController]
  public class Foto : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    [HttpPost]
    public ActionResult Post([FromBody] FotoData fotoData)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.usuario_id == fotoData.usuario.usuario_id)
        .FirstOrDefault();

      if (usuario == null) return BadRequest("Invalid User!");

      usuario.foto = fotoData.foto;

      TransRDDb._context.Usuario.Update(usuario);
      TransRDDb._context.SaveChanges();

      return Ok("Updated Picture!");
    }
  }
}
