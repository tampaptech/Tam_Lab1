using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tam_Lab1.Data;
using Tam_Lab1.Models;

namespace Tam_Lab1.Controllers
{
    public class Tam_EmployeeController : Controller
    {
        private readonly Tam_EmployeeContext _context;

        public Tam_EmployeeController(Tam_EmployeeContext context)
        {
            _context = context;
        }

        // GET: Tam_Employee
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = from m in _context.Tam_Employee
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Username.Contains(searchString));
            }
            return View(await employees.ToListAsync());
        }

        // GET: Tam_Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tam_Employee = await _context.Tam_Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tam_Employee == null)
            {
                return NotFound();
            }

            return View(tam_Employee);
        }

        // GET: Tam_Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tam_Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,DateOfBirth,FirstName,LastName,Gender")] Tam_Employee tam_Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tam_Employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tam_Employee);
        }

        // GET: Tam_Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tam_Employee = await _context.Tam_Employee.FindAsync(id);
            if (tam_Employee == null)
            {
                return NotFound();
            }
            return View(tam_Employee);
        }

        // POST: Tam_Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,DateOfBirth,FirstName,LastName,Gender")] Tam_Employee tam_Employee)
        {
            if (id != tam_Employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tam_Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tam_EmployeeExists(tam_Employee.Id))
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
            return View(tam_Employee);
        }

        // GET: Tam_Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tam_Employee = await _context.Tam_Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tam_Employee == null)
            {
                return NotFound();
            }

            return View(tam_Employee);
        }

        // POST: Tam_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tam_Employee = await _context.Tam_Employee.FindAsync(id);
            _context.Tam_Employee.Remove(tam_Employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tam_EmployeeExists(int id)
        {
            return _context.Tam_Employee.Any(e => e.Id == id);
        }
    }
}
