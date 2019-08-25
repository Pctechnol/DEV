using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsightConsulting.Domain.Entities;
using InsightConsulting.Domain;
using InsightConsulting.API.Controllers;
using InsightConsulting.Web.Models;
using System.Diagnostics;

namespace InsightConsulting.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly InsightConsultingDomain _context;
        private readonly UsersApiController usersApiController;

        public UsersController(InsightConsultingDomain context)
        {
            _context = context;
            usersApiController = new UsersApiController(_context);
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var model = usersApiController.GetAllUsers().Result;
                    if(model.Value == null)
                    {
                        var getError = model.Result;
                        
                        throw new Exception(model.Result.ToString());
                    }
                    return View(model.Value);
                });
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
                try
                {
                    return await Task.Run(() =>
                    {
                        var model = usersApiController.GetUser(id).Result;
                        if (model.Value == null)
                        {
                            var getError = model.Result;

                            throw new Exception(model.Result.ToString());
                        }
                        return View(model.Value);
                    });
                }
                catch (Exception ex)
                {
                    return View("Error", new ErrorViewModel { RequestId = ex.Message });
                }
            }

        // GET: Users/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,age,email,dateOfBirth,identityNumber,address,lineOne,lineTwo,city,country,postalCode")] Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await usersApiController.AddUser(user);
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var result = await usersApiController.GetUser(id);
                if (result.Value == null)
                {
                    var getError = result.Result;

                    throw new Exception(result.Result.ToString());
                }
                return View(result.Value);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,age,email,dateOfBirth,identityNumber,address,lineOne,lineTwo,city,country,postalCode")] Users user)
        {
            try
            {
                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    await usersApiController.UpdateUser(id, user);
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var result = await usersApiController.GetUser(id);

                if (result.Value == null)
                {
                    var getError = result.Result;

                    throw new Exception(result.Result.ToString());
                }

                return View(result.Value);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var accounts = await usersApiController.DeleteUser(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
