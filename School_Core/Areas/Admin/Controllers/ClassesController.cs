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
    public class ClassesController : Controller
    {
        private readonly ClassesRepository _classesRepository;

        private readonly StudentRepository _studentRepository;

        private readonly ClassesStudentRepository _classesStudentRepository;

        public ClassesController(ClassesRepository classesRepository, StudentRepository studentRepository, ClassesStudentRepository classesStudentRepository)
        {
            _classesRepository = classesRepository;
            _studentRepository = studentRepository;
            _classesStudentRepository = classesStudentRepository;
        }

        // GET: Classes
        public IActionResult Index()
        {
            return View(_classesRepository.GetAll());
        }

        // GET: Classes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _classesRepository.GetAll() == null)
            {
                return NotFound();
            }

            var nclass = _classesRepository.GetById(id.Value);
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
        public IActionResult Create([Bind("Id,Name,Date,Time")] Class nclass)
        {
            if (ModelState.IsValid)
            {
                _classesRepository.Insert(nclass);
                _classesRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(nclass);
        }

        // GET: Classes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _classesRepository.GetAll() == null)
            {
                return NotFound();
            }

            var nclass = _classesRepository.GetById(id.Value);
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
        public IActionResult Edit(int id, [Bind("Id,Name,Date,Time")] Class nclass)
        {
            if (id != nclass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _classesRepository.Update(nclass);
                    _classesRepository.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nclass);
        }

        // GET: Classes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _classesRepository.GetAll() == null)
            {
                return NotFound();
            }

            var nclass = _classesRepository.GetById(id.Value);
            if (nclass == null)
            {
                return NotFound();
            }

            return View(nclass);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_classesRepository.GetAll() == null)
            {
                return Problem("Entity set 'DB.Classes'  is null.");
            }
            _classesRepository.Delete(id);
            _classesRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignClasses()
        {
            ViewBag.Items = _classesRepository.GetAll();
            return View(_studentRepository.GetAll());
        }

        [HttpPost]
        public IActionResult AssignClasses(int StudentId, int ClassId)
        {
            ClassesStudent classesStudent = new ClassesStudent()
            {
                StudentId = StudentId,
                ClassId = ClassId
            };
            _classesStudentRepository.Insert(classesStudent);
            _classesStudentRepository.Save();
            return Redirect("/Admin/Home/index");
        }

    }
}
