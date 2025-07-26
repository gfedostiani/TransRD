using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class Viaje
  {
    [Key]
    public int viaje_id { get; set; }
    public int usuario_id { get; set; }
    public int tipo_id { get; set; }
    public double origen_lat { get; set; }
    public double origen_lng { get; set; }
    public double destino_lat { get; set; }
    public double destino_lng { get; set; }
    public DateTime fecha_inicio { get; set; }
    public DateTime fecha_fin { get; set; }
    public decimal costo {  get; set; }
    public string? Ubicacion_actual { get; set; }
    public string? Destino { get; set; }
  }
}
