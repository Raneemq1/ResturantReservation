using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Models
{
    public record OrderMenuItem(int OrderId,MenuItem Items);
   
}
