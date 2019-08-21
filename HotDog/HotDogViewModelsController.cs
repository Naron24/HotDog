using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotDog.Models;
using System.Diagnostics;

namespace HotDog
{   
    public class HotDogViewModelsController : Controller
    {
        private readonly HotDogContext _context;

        public HotDogViewModelsController(HotDogContext context)
        {
            _context = context;
        }

        // GET: HotDogViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotDogViewModel.ToListAsync());
        }

        // GET: HotDogViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotDogViewModel = await _context.HotDogViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotDogViewModel == null)
            {
                return NotFound();
            }

            return View(hotDogViewModel);
        }

        // GET: HotDogViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotDogViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] HotDogViewModel hotDogViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotDogViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotDogViewModel);
        }

        // GET: HotDogViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotDogViewModel = await _context.HotDogViewModel.FindAsync(id);
            if (hotDogViewModel == null)
            {
                return NotFound();
            }
            return View(hotDogViewModel);
        }

        // POST: HotDogViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] HotDogViewModel hotDogViewModel)
        {
            if (id != hotDogViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotDogViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotDogViewModelExists(hotDogViewModel.Id))
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
            return View(hotDogViewModel);
        }

        // GET: HotDogViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotDogViewModel = await _context.HotDogViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotDogViewModel == null)
            {
                return NotFound();
            }

            return View(hotDogViewModel);
        }

        // POST: HotDogViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotDogViewModel = await _context.HotDogViewModel.FindAsync(id);
            _context.HotDogViewModel.Remove(hotDogViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotDogViewModelExists(int id)
        {
            return _context.HotDogViewModel.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
