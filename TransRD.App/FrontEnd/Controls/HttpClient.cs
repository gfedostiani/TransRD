using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransRD.FrontEnd.Controls
{
  public static class HttpClientController
  {
    public static HttpClient Client = new HttpClient() { BaseAddress = new Uri("http://localhost:5245") };
  }
}
