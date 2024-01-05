using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_of_dotnet.Data;
using project_of_dotnet.Models;

namespace project_of_dotnet.Controllers
{
    public class destinationsController : Controller
    {
        private readonly project_of_dotnetContext _context;

        public destinationsController(project_of_dotnetContext context)
        {
            _context = context;
        }

        // GET: destinations
        public async Task<IActionResult> Index()
        {
              return _context.destination != null ? 
                          View(await _context.destination.ToListAsync()) :
                          Problem("Entity set 'project_of_dotnetContext.destination'  is null.");
        }

        // GET: destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.destination == null)
            {
                return NotFound();
            }

            var destination = await _context.destination
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: destinations/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Harit()
        {
            return View();
        }

        // POST: destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Location,NumberOfCities,AboutLocation")] destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: destinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.destination == null)
            {
                return NotFound();
            }

            var destination = await _context.destination.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        // POST: destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Location,NumberOfCities,AboutLocation")] destination destination)
        {
            if (id != destination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!destinationExists(destination.Id))
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
            return View(destination);
        }

        // GET: destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.destination == null)
            {
                return NotFound();
            }

            var destination = await _context.destination
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.destination == null)
            {
                return Problem("Entity set 'project_of_dotnetContext.destination'  is null.");
            }
            var destination = await _context.destination.FindAsync(id);
            if (destination != null)
            {
                _context.destination.Remove(destination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool destinationExists(int id)
        {
          return (_context.destination?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //this is use the add a new page 
  
        public async Task<IActionResult> destination_data()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return _context.destination != null ?
                        View(await _context.destination.ToListAsync()) :
                        Problem("Entity set 'project_of_dotnetContext.destination'  is null.");
        }

      

        public async Task<IActionResult> details_of_destination(int? id)
        {
            if (id == null || _context.destination == null)
            {
                return NotFound();
            }

            var destination = await _context.destination.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View(destination);
        }
        
    }
}
