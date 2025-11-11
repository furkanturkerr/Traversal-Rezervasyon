using ClosedXML.Excel;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Traversal_Rezervasyon.Controllers
{
    public class ExcelController : Controller
    {
        static ExcelController()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Traversal Rezervasyon Dev"); 
        }

        public IActionResult Index()
        {
            return View();
        }

        private List<DestinationModel> DestinationList()
        {
            using var c = new Context();
            return c.Destinations
                .Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                })
                .ToList();
        }

        // EPPlus ile statik rapor
        public IActionResult StaticExcelReport()
        {
            using var excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");

            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            worksheet.Cells[2, 2].Value = "Kadir Yıldız";
            worksheet.Cells[2, 3].Value = 50;

            worksheet.Cells[1, 1, 2, 3].AutoFitColumns();

            var bytes = excel.GetAsByteArray();
            return File(bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Rota.xlsx");
        }

        // ClosedXML ile veritabanından dinamik rapor
        public IActionResult DestinationExcelReport()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Tur Listesi");

            worksheet.Cell(1, 1).Value = "Şehir";
            worksheet.Cell(1, 2).Value = "Konaklama Süresi";
            worksheet.Cell(1, 3).Value = "Fiyat";
            worksheet.Cell(1, 4).Value = "Kapasite";

            var row = 2;
            foreach (var item in DestinationList())
            {
                worksheet.Cell(row, 1).Value = item.City;
                worksheet.Cell(row, 2).Value = item.DayNight;
                worksheet.Cell(row, 3).Value = item.Price;
                worksheet.Cell(row, 4).Value = item.Capacity;
                row++;
            }

            var header = worksheet.Range(1, 1, 1, 4);
            header.Style.Font.Bold = true;
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "TurListesi.xlsx");
        }
    }
}
