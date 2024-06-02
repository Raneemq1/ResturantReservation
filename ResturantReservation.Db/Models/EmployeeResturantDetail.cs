using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Models
{
    public record EmployeeResturantDetail(int EmployeeId,string EmployeeName,string ResturantName,string ResturantAddress);
}
