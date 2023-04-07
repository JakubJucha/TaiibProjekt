using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektTaiib.DAL.Encje;
using ProjektTaiib.DAL.Repositories;
using ProjektTaiib.DAL.UnitOfWork;

namespace ProjektTaiibWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjektTaiibDbContext _context;
        private readonly UnitOfWork unitOfWork;

        public UserController(ProjektTaiibDbContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
              return unitOfWork.UserRepository!= null ? 
                          View(await unitOfWork.UserRepository.GetAllUsersAsync()) :
                          Problem("Entity set 'ProjektTaiibDbContext.Users'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.UserRepository== null)
            {
                return NotFound();
            }

            var user = await unitOfWork.UserRepository
                .FirstOrDefaultAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_user,Username,Email,Password,Moderator")] User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.AddUser(user);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.UserRepository== null)
            {
                return NotFound();
            }

            var user = await unitOfWork.UserRepository.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_user,Username,Email,Password,Moderator")] User user)
        {
            if (id != user.Id_user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.UserRepository.UpdateUser(user);
                    await unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id_user))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.UserRepository== null)
            {
                return NotFound();
            }

            var user = await unitOfWork.UserRepository
                .FirstOrDefaultAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.UserRepository== null)
            {
                return Problem("Entity set 'ProjektTaiibDbContext.Users'  is null.");
            }
            var user = await unitOfWork.UserRepository.FindAsync(id);
            if (user != null)
            {
                unitOfWork.UserRepository.DeleteUser(user);
            }
            
            await unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (unitOfWork.UserRepository?.ExistUser(id)).GetValueOrDefault();
        }
    }
}
