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
    public class user_dataController : Controller
    {
        private readonly project_of_dotnetContext _context;

        public user_dataController(project_of_dotnetContext context)
        {
            _context = context;
        }
        //this is the login by last try.
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var user = _context.user_data.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Successful login logic here
                HttpContext.Session.SetString("UserName", user.Name);
                return RedirectToAction("Harit");
            }

            // Invalid login logic here
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }


        public IActionResult LOGOUT()
        {

            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");

        }
        public IActionResult Harit()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View();
        }



        // GET: user_data
        public async Task<IActionResult> Index()
        {
              return _context.user_data != null ? 
                          View(await _context.user_data.ToListAsync()) :
                          Problem("Entity set 'project_of_dotnetContext.user_data'  is null.");
        }

        // GET: user_data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.user_data == null)
            {
                return NotFound();
            }

            var user_data = await _context.user_data
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_data == null)
            {
                return NotFound();
            }

            return View(user_data);
        }

        // GET: user_data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: user_data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,MobileNumber")] user_data user_data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_data);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("UserName", user_data.Name);
                return RedirectToAction(nameof(Harit));
            }
            return View(user_data);
        }

        // GET: user_data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.user_data == null)
            {
                return NotFound();
            }

            var user_data = await _context.user_data.FindAsync(id);
            if (user_data == null)
            {
                return NotFound();
            }
            return View(user_data);
        }

        // POST: user_data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,MobileNumber")] user_data user_data)
        {
            if (id != user_data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!user_dataExists(user_data.Id))
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
            return View(user_data);
        }

        // GET: user_data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.user_data == null)
            {
                return NotFound();
            }

            var user_data = await _context.user_data
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_data == null)
            {
                return NotFound();
            }

            return View(user_data);
        }

        // POST: user_data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.user_data == null)
            {
                return Problem("Entity set 'project_of_dotnetContext.user_data'  is null.");
            }
            var user_data = await _context.user_data.FindAsync(id);
            if (user_data != null)
            {
                _context.user_data.Remove(user_data);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool user_dataExists(int id)
        {
          return (_context.user_data?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //This is a extra html page conect with the connteroler
        public IActionResult about()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult guide()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult home()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View();
        }
        public IActionResult service()
        {
            ViewData["user"] = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
