using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class ConfiguracionTarifas
  {
    [Key]
    public int config_id { get; set; }
    public int tipo_id { get; set; }
    public decimal? tarifa { get; set; }
    public string? email { get; set; }
    public DateTime? vigente_desde { get; set; }
    public DateTime? vigente_hasta { get; set; }
    public string? estado { get; set; }
  }
}
