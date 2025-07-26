using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class Boleto
  {
    [Key]
    public int boleto_id { get; set; }
    public int usuario_id { get; set; }
    public int viaje_id { get; set; }
    public DateTime? fecha_compra { get; set; }
    public string? estado { get; set; }
  }
}
