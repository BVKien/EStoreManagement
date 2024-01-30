using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Reports
{
    public class OrderReportRepository
    {
        public OrderReportRepository()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Revenue { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
