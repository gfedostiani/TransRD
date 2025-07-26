using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.Infraestructura.Models
{
  public class CodigoQR
  {
    [Key]
    public int qr_id { get; set; }
    public int cuenta_id { get; set; }
    public string? valor_qr { get; set; }
    public DateTime? fecha_creacion { get; set; }
    public DateTime? valido_hasta { get; set; }
    public string? estado { get; set; }
  }
}
