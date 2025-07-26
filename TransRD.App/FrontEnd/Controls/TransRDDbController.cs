using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransRD.Data;

namespace TransRD.FrontEnd.Controls
{
  public class TransRDDbController
  {
    public TransRDDbContext _context;
    public TransRDDbController()
    {
      string DefaultConnection = "Server=gfedo.database.windows.net;Database=TransRD;User Id=gfedo;Password=2210Gabi#;";
      DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<TransRDDbContext>().UseAzureSql(DefaultConnection);

      this._context = new TransRDDbContext(optionsBuilder.Options);
    }
}
}
