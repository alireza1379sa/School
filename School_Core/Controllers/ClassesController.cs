using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using School_Core;

namespace School_Core.Controllers
{
    public class ClassesController : Controller
    {
        private readonly DB _context;

        public ClassesController(DB context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var dB = _context.Classes.Include(n => n.Teacher);
            return View(await dB.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var nclass = await _context.Classes
                .Include(n => n.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nclass == null)
            {
                return NotFound();
            }

            return View(nclass);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,Time")] Class nclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nclass);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var nclass = await _context.Classes.FindAsync(id);
            if (nclass == null)
            {
                return NotFound();
            }
            return View(nclass);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,Time")] Class nclass)
        {
            if (id != nclass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(nclass.Id))
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
            return View(nclass);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var nclass = await _context.Classes
                .Include(n => n.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nclass == null)
            {
                return NotFound();
            }

            return View(nclass);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'DB.Classes'  is null.");
            }
            var nclass = await _context.Classes.FindAsync(id);
            if (nclass != null)
            {
                _context.Classes.Remove(nclass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignClasses()
        {
            ViewBag.Items = _context.Classes;
            return View(_context.Students);
        }

        [HttpPost]
        public IActionResult AssignClasses(int StudentId, int ClassId)
        {
            ClassesStudent classesStudent = new ClassesStudent()
            {
                StudentId= StudentId,
                ClassId= ClassId
            };
            _context.ClassesStudents.Add(classesStudent);
            _context.SaveChanges();
            return Redirect("/Home/index");
        }

        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
