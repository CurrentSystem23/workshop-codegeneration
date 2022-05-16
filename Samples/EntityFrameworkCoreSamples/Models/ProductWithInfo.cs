using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreSamples.Models
{
  public class ProductWithInfo : Product
  {
    public string ModifiedInformation { get; set; }
  }
}
