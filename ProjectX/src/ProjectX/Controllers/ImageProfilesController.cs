using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectX.Data;
using ProjectX.Models;

namespace ProjectX.Controllers
{
    public class ImageProfilesController : Controller
    {
        private readonly ImageProfileDbContext _context;

        public ImageProfilesController(ImageProfileDbContext context)
        {
            _context = context;    
        }

        // GET: ImageProfiles
        public async Task<IActionResult> Index()
        {
            var imageProfileDbContext = _context.ImageProfiles.Include(i => i.Image);
            return View(await imageProfileDbContext.ToListAsync());
        }

        // GET: ImageProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageProfile = await _context.ImageProfiles.SingleOrDefaultAsync(m => m.Id == id);
            if (imageProfile == null)
            {
                return NotFound();
            }

            return View(imageProfile);
        }

        // GET: ImageProfiles/Create
        public IActionResult Create()
        {
            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id");
            return View();
        }

        // POST: ImageProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ImageId,Title,UserId")] ImageProfile imageProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", imageProfile.Image);
            return View(imageProfile);
        }

        // GET: ImageProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageProfile = await _context.ImageProfiles.SingleOrDefaultAsync(m => m.Id == id);
            if (imageProfile == null)
            {
                return NotFound();
            }
            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", imageProfile.Image);
            return View(imageProfile);
        }

        // POST: ImageProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ImageId,Title,UserId")] ImageProfile imageProfile)
        {
            if (id != imageProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageProfileExists(imageProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", imageProfile.Image);
            return View(imageProfile);
        }

        // GET: ImageProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageProfile = await _context.ImageProfiles.SingleOrDefaultAsync(m => m.Id == id);
            if (imageProfile == null)
            {
                return NotFound();
            }

            return View(imageProfile);
        }

        // POST: ImageProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageProfile = await _context.ImageProfiles.SingleOrDefaultAsync(m => m.Id == id);
            _context.ImageProfiles.Remove(imageProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ImageProfileExists(int id)
        {
            return _context.ImageProfiles.Any(e => e.Id == id);
        }
    }
}
