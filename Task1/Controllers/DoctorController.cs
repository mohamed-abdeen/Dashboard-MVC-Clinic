using Microsoft.AspNetCore.Mvc;
using System;
using Task.BLL.interfaces;
using Task.BLL.Reposatiories;
using Task.DAL.Entity;

namespace Task1PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorReposatiory _doctorReposatiory;
        public DoctorController(IDoctorReposatiory doctorReposatiory)
        {
            _doctorReposatiory = doctorReposatiory;
        }

        public IActionResult Index()
        {
            var secretary = _doctorReposatiory.GetAll();
            return View(secretary);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorReposatiory.Add(doctor);
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }
        public IActionResult Details(int? PatientId, string v)
        {

            if (PatientId == null)
                return NotFound();
            var doctor = _doctorReposatiory.Get(PatientId.Value);
            if (doctor == null)
                return NotFound();
            return View(doctor);
        }

        public IActionResult Edit(int? PatientId)
        {
            //return Details(PatientId, "Edit");
            if (PatientId == null)
                return BadRequest();
            var doctor = _doctorReposatiory.Get(PatientId.Value);
            if (doctor == null)
                return BadRequest();
            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id, Doctor doctor)
        {
            if (Id != doctor.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _doctorReposatiory.Update(doctor);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(doctor);
                }
            }

            return View(doctor);
        }
        public IActionResult Delete(int? patientId)
        {
            return Details(patientId, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id, Doctor doctor)
        {

            if (Id != doctor.Id)
                return BadRequest();
            try
            {
                _doctorReposatiory.Delete(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(doctor);
            }
        }
    }
}
