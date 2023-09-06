using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using ToDo.Models.EF;

namespace ToDo.Controllers
{
    public class TodolistController : Controller
    {
        private readonly TodolistDbContext _context;

        public TodolistController(TodolistDbContext context)
        {
            _context = context;
        }

        // GET: Todolist
        public async Task<IActionResult> Index()
        {
              return _context.Todolists != null ? 
                          View(await _context.Todolists.ToListAsync()) :
                          Problem("Entity set 'TodolistDbContext.Todolists'  is null.");
        }


        // GET: Todolist/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if(id == 0) 
            {
                return View(new Todolist());
            }
            else { return View(_context.Todolists.Find(id)); }
            
        }

        // POST: Todolist/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Task,Priority,Status,DateCreated")] Todolist todolist)
        {
            if (ModelState.IsValid)
            {
                if (todolist.Id == 0)
                {
                    todolist.DateCreated = DateTime.Now;
                    _context.Add(todolist);
                }
                else
                
                    _context.Update(todolist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(todolist);
        }

        

        // POST: Todolist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Todolists == null)
            {
                return Problem("Entity set 'TodolistDbContext.Todolists'  is null.");
            }
            var todolist = await _context.Todolists.FindAsync(id);
            if (todolist != null)
            {
                _context.Todolists.Remove(todolist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
