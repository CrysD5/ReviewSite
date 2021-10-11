﻿using Microsoft.AspNetCore.Mvc;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Controllers
{
    public class ParkController : Controller
    {
        private IRepository<Park> _parkRepo;

        public ParkController(IRepository<Park> parkRepo)
        {
            this._parkRepo = parkRepo;
        }
        public IActionResult Index()
        {
            return View(_parkRepo.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Park());
        }
        [HttpPost]
        public IActionResult Create(Park newPark)
        {
            ViewBag.Result = "You've successfully added a new park!";
            _parkRepo.Create(newPark);
            return View();
            
        }

        
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Park park = _parkRepo.GetByID(id);
            return View(park);
        }
        
        // get method for edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            else
            {
                int x = id.GetValueOrDefault();
                Park park = _parkRepo.GetByID(x);
                return View(park);
            }
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Park park)
        {
            _parkRepo.Update(park);
            return RedirectToAction("Index");
        }
    }
}
