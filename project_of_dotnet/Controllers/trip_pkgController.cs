using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_of_dotnet.Data;
using project_of_dotnet.Models;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace project_of_dotnet.Controllers
{
    public class trip_pkgController : Controller
    {
        private readonly project_of_dotnetContext _context;

        public trip_pkgController(project_of_dotnetContext context)
        {
            _context = context;
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
        // GET: trip_pkg
        public async Task<IActionResult> Index()
        {
              return _context.trip_pkg != null ? 
                          View(await _context.trip_pkg.ToListAsync()) :
                          Problem("Entity set 'project_of_dotnetContext.trip_pkg'  is null.");
        }
        public async Task<IActionResult> package()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");

            return _context.trip_pkg != null ?
                        View(await _context.trip_pkg.ToListAsync()) :
                        Problem("Entity set 'project_of_dotnetContext.trip_pkg'  is null.");
        }

        // GET: trip_pkg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.trip_pkg == null)
            {
                return NotFound();
            }

            var trip_pkg = await _context.trip_pkg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip_pkg == null)
            {
                return NotFound();
            }

            return View(trip_pkg);
        }

        // GET: trip_pkg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: trip_pkg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,image,Location,PersonNumber,StarNumber,TotalPerson,Price,Description,GuideName,Guide_Photo,GuideDescription")] trip_pkg trip_pkg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip_pkg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip_pkg);
        }

        // GET: trip_pkg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.trip_pkg == null)
            {
                return NotFound();
            }

            var trip_pkg = await _context.trip_pkg.FindAsync(id);
            if (trip_pkg == null)
            {
                return NotFound();
            }
            return View(trip_pkg);
        }

        // POST: trip_pkg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,image,Location,PersonNumber,StarNumber,TotalPerson,Price,Description,GuideName,Guide_Photo,GuideDescription")] trip_pkg trip_pkg)
        {
            if (id != trip_pkg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip_pkg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!trip_pkgExists(trip_pkg.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trip_pkg);
        }

        // GET: trip_pkg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.trip_pkg == null)
            {
                return NotFound();
            }

            var trip_pkg = await _context.trip_pkg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip_pkg == null)
            {
                return NotFound();
            }

            return View(trip_pkg);
        }

        // POST: trip_pkg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trip_pkg == null)
            {
                return Problem("Entity set 'project_of_dotnetContext.trip_pkg'  is null.");
            }
            var trip_pkg = await _context.trip_pkg.FindAsync(id);
            if (trip_pkg != null)
            {
                _context.trip_pkg.Remove(trip_pkg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool trip_pkgExists(int id)
        {
          return (_context.trip_pkg?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> about_guide(int? id)
        {
            if (id == null || _context.trip_pkg == null)
            {
                return NotFound();
            }

            var trip_pkg = await _context.trip_pkg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip_pkg == null)
            {
                return NotFound();
            }
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View(trip_pkg);
        }
    }
}
