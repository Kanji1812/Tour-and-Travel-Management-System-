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
    public class bookingsController : Controller
    {
        private readonly project_of_dotnetContext _context;

        public bookingsController(project_of_dotnetContext context)
        {
            _context = context;
        }

        // GET: bookings
        public async Task<IActionResult> Index()
        {
            var project_of_dotnetContext = _context.booking.Include(b => b.user_data);
            return View(await project_of_dotnetContext.ToListAsync());
        }

        // GET: bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking
                .Include(b => b.user_data)
                .FirstOrDefaultAsync(m => m.B_Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: bookings/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.user_data, "Id", "Email");
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("B_Id,Id")] booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.user_data, "Id", "Email", booking.Id);
            return View(booking);
        }

        // GET: bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.user_data, "Id", "Email", booking.Id);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("B_Id,Id")] booking booking)
        {
            if (id != booking.B_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bookingExists(booking.B_Id))
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
            ViewData["Id"] = new SelectList(_context.user_data, "Id", "Email", booking.Id);
            return View(booking);
        }

        // GET: bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.booking == null)
            {
                return NotFound();
            }

            var booking = await _context.booking
                .Include(b => b.user_data)
                .FirstOrDefaultAsync(m => m.B_Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.booking == null)
            {
                return Problem("Entity set 'project_of_dotnetContext.booking'  is null.");
            }
            var booking = await _context.booking.FindAsync(id);
            if (booking != null)
            {
                _context.booking.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bookingExists(int id)
        {
          return (_context.booking?.Any(e => e.B_Id == id)).GetValueOrDefault();
        }
    }
}
