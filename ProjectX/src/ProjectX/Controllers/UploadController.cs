using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Data;
using ProjectX.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace ProjectX.Controllers
{
    public class UploadController : Controller
    {
        private readonly UploadDbContext _context;
        private IHostingEnvironment _environment;
        private UserManager<ApplicationUser> _userManager;

        public UploadController(UploadDbContext context, IHostingEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: Upload
        public async Task<IActionResult> Index()
        {
            var uploads = await _context.Uploads.Include(c => c.User).ToListAsync();

            return View(uploads);
        }

        // GET: Upload/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upload = await _context.Uploads.SingleOrDefaultAsync(m => m.Id == id);
            if (upload == null)
            {
                return NotFound();
            }

            return View(upload);
        }

        // GET: Upload/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Upload/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImagePath,UploadTime,UserId")] Image upload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upload);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(upload);
        }
        
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: Upload/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upload = await _context.Uploads.SingleOrDefaultAsync(m => m.Id == id);
            if (upload == null)
            {
                return NotFound();
            }
            return View(upload);
        }

        // POST: Upload/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImagePath,UploadTime,UserId")] Image upload)
        {
            if (id != upload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadExists(upload.Id))
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
            return View(upload);
        }

        // GET: Upload/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upload = await _context.Uploads.SingleOrDefaultAsync(m => m.Id == id);
            if (upload == null)
            {
                return NotFound();
            }

            return View(upload);
        }

        // POST: Upload/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upload = await _context.Uploads.SingleOrDefaultAsync(m => m.Id == id);
            _context.Uploads.Remove(upload);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UploadExists(int id)
        {
            return _context.Uploads.Any(e => e.Id == id);
        }

        [HttpPost]
        public void UploadFile()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var filePath = Path.Combine(_environment.WebRootPath, "uploads");

                    foreach (var file in Request.Form.Files)
                    {
                        filePath = Path.Combine(filePath, Guid.NewGuid() + "_" + file.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        var user = _userManager.GetUserAsync(User).Result;
                        var upload = new Image();

                        upload.ImagePath = filePath;
                        upload.ApplicationUserId = user.Id;
                        upload.UploadTime = DateTime.Now;

                        _context.Add(upload);
                    }

                    var jsonString = "{\"success\":true}";
                    byte[] data = Encoding.UTF8.GetBytes(jsonString);

                    Response.ContentType = "text/plain";
                    Response.Body.Write(data, 0, data.Length);

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var jsonString = "{\"error\":"+ex.Message+"}";
                    byte[] data = Encoding.UTF8.GetBytes(jsonString);

                    Response.ContentType = "text/plain";
                    Response.Body.Write(data, 0, data.Length);
                }
            }
        }
    }
}
