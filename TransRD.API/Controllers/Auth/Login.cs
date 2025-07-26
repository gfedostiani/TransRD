namespace TransRD.API.Controllers.Auth
{
  using Microsoft.AspNetCore.Http.HttpResults;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
  using System.Net;
  using TransRD.APi.Controllers;
  using TransRD.Infraestructura.Models;

  [Route("auth/[controller]")]
  [ApiController]
  public class Login : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    // POST api/<Login>
    [HttpPost]
    public ActionResult Post([FromBody] LoginData Login)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.email == Login.Email)
        .Where(u => u.contraseña == Login.Password)
        .FirstOrDefault();
      if (usuario == null) {
        return BadRequest("Wrong Credentials");
      } 
      else
      {
        return Ok(usuario.usuario_id);
      }
    }
  }
}
