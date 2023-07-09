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
    public class TeachersController : Controller
    {
        private readonly TeacherRepository _teacherRepository;

        private readonly ClassesRepository _classesRepository;

        public TeachersController(TeacherRepository teacherRepository, ClassesRepository classesRepository)
        {
            _teacherRepository = teacherRepository;
            _classesRepository = classesRepository;
        }

        // GET: Teachers
        public IActionResult Index()
        {
            return _teacherRepository.GetAll() != null ?
                        View(_teacherRepository.GetAll()) :
                        Problem("Entity set 'DB.Teachers'  is null.");
        }

        // GET: Teachers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _teacherRepository.GetAll() == null)
            {
                return NotFound();
            }

            var teacher = _teacherRepository.GetById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Field,PhoneNumber")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherRepository.Insert(teacher);
                _teacherRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _teacherRepository.GetAll() == null)
            {
                return NotFound();
            }

            var teacher = _teacherRepository.GetById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Field,PhoneNumber")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _teacherRepository.Update(teacher);
                    _teacherRepository.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _teacherRepository.GetAll()==null)
            {
                return NotFound();
            }

            var teacher = _teacherRepository.GetById(id.Value);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_teacherRepository.GetAll() == null)
            {
                return Problem("Entity set 'DB.Teachers'  is null.");
            }
            _teacherRepository.Delete(id);
            _teacherRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignTeacher()
        {
            ViewBag.Items = _classesRepository.GetAll();
            return View(_teacherRepository.GetAll());
        }
        [HttpPost]
        public IActionResult AssignTeacher(int TeacherId, int ClassId)
        {
            Class myClass = _classesRepository.GetById(ClassId)!;
            myClass.Teacher_id = TeacherId;
            _classesRepository.Update(myClass);
            _classesRepository.Save();
            return Redirect("/Admin/Home/Index");
        }

    }
}
