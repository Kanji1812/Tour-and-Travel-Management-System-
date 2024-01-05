using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Microsoft.EntityFrameworkCore;
using project_of_dotnet.Data;
using project_of_dotnet.Models;

namespace project_of_dotnet.Controllers
{
    public class adminsController : Controller
    {
        private readonly project_of_dotnetContext _context;

        public adminsController(project_of_dotnetContext context)
        {
            _context = context;
            //this is a for PDF craete
            //_converter = context;
        }

        //This is a Login code 

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var admin = _context.admin.FirstOrDefault(a => a.Email == email && a.Password == password);

            if (admin != null)
            {
                // Successful login logic here
                HttpContext.Session.SetString("Admin_name", admin.Name);
                return RedirectToAction("home");
            }

            // Invalid login logic here
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }


        public async Task<IActionResult> Index()
        {
              return _context.admin != null ? 
                          View(await _context.admin.ToListAsync()) :
                          Problem("Entity set 'project_of_dotnetContext.admin'  is null.");
        }

        // GET: admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,MobileNumber")] admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,MobileNumber")] admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adminExists(admin.Id))
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
            return View(admin);
        }

        // GET: admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.admin == null)
            {
                return Problem("Entity set 'project_of_dotnetContext.admin'  is null.");
            }
            var admin = await _context.admin.FindAsync(id);
            if (admin != null)
            {
                _context.admin.Remove(admin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adminExists(int id)
        {
          return (_context.admin?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult home()
        {
            return View();
        }





       
    }
}
