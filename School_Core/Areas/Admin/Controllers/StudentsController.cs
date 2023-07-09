using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using School_Core.Services;

namespace School_Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;
        public StudentsController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Students
        public IActionResult Index()
        {
            return _studentRepository.GetAll() != null ?
                        View(_studentRepository.GetAll()) :
                        Problem("Entity set 'DB.Students'  is null.");
        }

        // GET: Students/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _studentRepository.GetAll() == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Major,Age,NationalCode")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Insert(student);
                _studentRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _studentRepository.GetAll() == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Major,Age,NationalCode")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepository.Update(student);
                    _studentRepository.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _studentRepository.GetAll() == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_studentRepository.GetAll() == null)
            {
                return Problem("Entity set 'DB.Students'  is null.");
            }
            _studentRepository.Delete(id);
            _studentRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
