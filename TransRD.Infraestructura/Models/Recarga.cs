using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class Recarga
  {
    [Key]
    public int recarga_id { get; set; }
    public int cuenta_id { get; set; }
    public decimal? monto { get; set; }
    public string? metodo_pago { get; set; }
    public decimal? fecha_recarga { get; set; }
  }
}
