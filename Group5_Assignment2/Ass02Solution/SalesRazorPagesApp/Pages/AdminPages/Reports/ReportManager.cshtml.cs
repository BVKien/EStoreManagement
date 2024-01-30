using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Reports;

namespace SalesRazorPagesApp.Pages.AdminPages.Reports
{
    public class ReportManagerModel : PageModel
    {
        public void OnGet(DateTime fromDate, DateTime toDate)
        {
            using (var context = new eStoreContext())
            {
                var orderReports = context.Orders
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                    .Select(o => new OrderReportRepository
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        ShippedDate = o.ShippedDate,
                        Revenue = o.OrderDetails.Sum(od => (od.UnitPrice * od.Quantity) - od.Discount),
                        OrderDetails = o.OrderDetails.Select(od => new OrderDetail
                        {
                            ProductId = od.ProductId,
                            Quantity = od.Quantity,
                            UnitPrice = od.UnitPrice,
                            Discount = od.Discount
                        }).ToList()
                    })
                    .ToList();

                ViewData["report"]= orderReports;
            }
        }
    }
}
