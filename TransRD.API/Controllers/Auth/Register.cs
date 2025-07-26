using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransRD.APi.Controllers;
using TransRD.Infraestructura.Models;

namespace TransRD.API.Controllers.Auth
{

  [Route("auth/[controller]")]
  [ApiController]
  public class Register : ControllerBase
  {
    public TransRDDbController TransRDDb = new TransRDDbController();
    [HttpPost]
    public ActionResult Post([FromBody] RegisterData User)
    {
      Usuario? usuario = TransRDDb._context
        .Usuario
        .Where(u => u.email == User.Email)
        .FirstOrDefault();
      if (usuario != null)
      {
        return BadRequest("Email Already Exists");
      }
      else
      {
        try
        {
          TransRDDb._context.Usuario.Add(new Usuario { 
            nombre = User.Name, 
            email = User.Email, 
            contraseña = User.Password, 
            estado = "Activo" 
          });
          TransRDDb._context.SaveChanges();
          return Ok("Ok");
        } 
        catch (Exception ex)
        {
          return BadRequest(ex);
        }
      }
    }
  }
}
