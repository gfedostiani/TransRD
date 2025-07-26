using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransRD.APi.Controllers;
using TransRD.Data;
using TransRD.Infraestructura.Models;
using Xamarin.Essentials;

namespace TransRD.API.Controllers.Auth
{
  [Route("auth/[controller]")]
  [ApiController]
  public class Me : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    [HttpGet]
    public async Task<ActionResult> Get(string token) {
      if (token == null)
      {
        return BadRequest("Not Logged in.");
      }
      else
      {
        Usuario? usuario = TransRDDb._context.Usuario
          .Where(u => u.usuario_id == int.Parse(token))
          .FirstOrDefault();
        return Ok(usuario);
      }
    }
  }
}
