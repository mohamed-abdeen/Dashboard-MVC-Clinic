using Microsoft.AspNetCore.Mvc;
using System;
using Task.BLL.interfaces;
using Task.BLL.Reposatiories;
using Task.DAL.Entity;

namespace Task1PL.Controllers
{
    public class SecretaryController : Controller
    {
        private readonly IsecretaryReposatiory _secretaryReposatiory;
        public SecretaryController(IsecretaryReposatiory secretaryReposatiory)
        {
            _secretaryReposatiory = secretaryReposatiory;
        }

        public IActionResult Index()
        {
            var secretary = _secretaryReposatiory.GetAll();
            return View(secretary);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                _secretaryReposatiory.Add(secretary);
                return RedirectToAction(nameof(Index));
            }
            return View(secretary);
        }
        public IActionResult Details(int? PatientId, string v)
        {

            if (PatientId == null)
                return NotFound();
            var secretary = _secretaryReposatiory.Get(PatientId.Value);
            if (secretary == null)
                return NotFound();
            return View(secretary);
        }

        public IActionResult Edit(int? PatientId)
        {
            //return Details(PatientId, "Edit");
            if (PatientId == null)
                return BadRequest();
            var secretary = _secretaryReposatiory.Get(PatientId.Value);
            if (secretary == null)
                return BadRequest();
            return View(secretary);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int patientId, Secretary secretary)
        {
            if (patientId != secretary.patientId)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _secretaryReposatiory.Update(secretary);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(secretary);
                }
            }

            return View(secretary);
        }
        public IActionResult Delete(int? patientId)
        {
            return Details(patientId, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? patientId, Secretary secretary)
        {

            if (patientId != secretary.patientId)
                return BadRequest();
            try
            {
                _secretaryReposatiory.Delete(secretary);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(secretary);
            }
        }
    }
}

