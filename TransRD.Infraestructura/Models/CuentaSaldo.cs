using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class CuentaSaldo
  {
    [Key]
    public int cuenta_id { get; set; }
    public int usuario_id { get; set; }
    public decimal? saldo_actual { get; set; }
    public DateTime? fecha_actualizacion { get; set; }
  }
}
