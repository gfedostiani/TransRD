using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class TipoTransporte
  {
    [Key]
    public int tipo_id { get; set; }
    public string? nombre { get; set; }
    public decimal? tarifa_base { get; set; }
  }
}
