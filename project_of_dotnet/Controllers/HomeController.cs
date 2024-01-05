using Microsoft.AspNetCore.Mvc;
using project_of_dotnet.Models;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Diagnostics;

namespace project_of_dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ExportToPDF()
        {

            //this is a code for curent url.
           // string currentUrl= HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path;

            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            

            //Convert URL to PDF document
            PdfDocument document = htmlConverter.Convert("file:///C:/Users/savan/OneDrive/Desktop/kanji%20Tour%20and%20travel/package.html");

            //Create memory stream
            MemoryStream stream = new MemoryStream();

            //Save the document
            document.Save(stream);

            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "HTML-to-PDF.pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}