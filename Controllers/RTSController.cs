using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp6.Data;
using WebApp6.Models;

namespace WebApp6.Controllers
{
    public class RTSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RTSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RTS
        public async Task<IActionResult> Index()
        {
            return View(await _context.RTS.ToListAsync());
        }

        // GET: RTS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rTS = await _context.RTS
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rTS == null)
            {
                return NotFound();
            }

            return View(rTS);
        }

        // GET: RTS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("STAMPSTATUS,IdName,EMPLOYEE,EMPLOYEENAME,SKILL,ASSIGNEDDEPT,ASSIGNEDCREW,AIRCRAFTTYPE,ENGINETYPE,BEGINDATE,ENDDATE,AUTHORIZATIONTYPE,STAMP,EMPLOYEESTATUS,ID")] RTS rTS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rTS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rTS);
        }

        // GET: RTS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rTS = await _context.RTS.FindAsync(id);
            if (rTS == null)
            {
                return NotFound();
            }
            return View(rTS);
        }

        // POST: RTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("STAMPSTATUS,IdName,EMPLOYEE,EMPLOYEENAME,SKILL,ASSIGNEDDEPT,ASSIGNEDCREW,AIRCRAFTTYPE,ENGINETYPE,BEGINDATE,ENDDATE,AUTHORIZATIONTYPE,STAMP,EMPLOYEESTATUS,ID")] RTS rTS)
        {
            if (id != rTS.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rTS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RTSExists(rTS.ID))
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
            return View(rTS);
        }

        // GET: RTS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rTS = await _context.RTS
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rTS == null)
            {
                return NotFound();
            }

            return View(rTS);
        }

        // POST: RTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rTS = await _context.RTS.FindAsync(id);
            _context.RTS.Remove(rTS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RTSExists(int id)
        {
            return _context.RTS.Any(e => e.ID == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> filter([Bind("AUTHORIZATIONTYPE")] RTS rTS)
        {

            if (ModelState.IsValid)
            {
                return View(_context.RTS.Any(x => x.AUTHORIZATIONTYPE == rTS.AUTHORIZATIONTYPE));
            }
            return View(rTS);
        }



    }
}
