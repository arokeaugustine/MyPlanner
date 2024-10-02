using Microsoft.AspNetCore.Mvc;
using MyPlanner.Models;


namespace MyDayPlanner.Controllers
{
    public class TodoController : Controller
    {
        private readonly DayPlannerContext _context;

        public TodoController(DayPlannerContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateEntry(Todo request)
        {
            TempData["success"] = null;
            var data = request;
            data.IsDone = false;
            data.DateCreated = DateTime.Now;
            _context.Todos.Add(data);
            int save = _context.SaveChanges();
            if (save > 0)
            {
                TempData["success"] = "Saved successfully";
            }

            return RedirectToAction("Create");
        }

        public IActionResult GetPlans()
        {
            TempData["success"] = null;
            var data = _context.Todos.ToList();
            if (data.Any() == true)
            {
                TempData["success"] = "Items retrieved Successfully";
            }
            return View(data);
        }

        public IActionResult Details(int Id)
        {
            TempData["success"] = null;
            var data = _context.Todos.FirstOrDefault(x => x.Id == Id);
            if (data == null)
            {
                return RedirectToAction("GetPlans");
            }
            TempData["success"] = "Items retrieved Successfully";
            return View(data);
        }
        public IActionResult GetUpdate(int Id)
        {
            TempData["success"] = null;
            var data = _context.Todos.FirstOrDefault(x => x.Id == Id);
            if (data == null)
            {
                return RedirectToAction("GetPlans");
            }
            TempData["success"] = "Items retrieved Successfully";
            return View(data);
        }

        public IActionResult Update(Todo todo)
        {
            TempData["update"] = null;
            var data = _context.Todos.FirstOrDefault(x => x.Id == todo.Id);
            if (data == null)
            {
                TempData["update"] = "false";
                return RedirectToAction("GetPlans");
            }
            data.Name = todo.Name;
            data.StartTime = todo.StartTime;
            data.EndTime = todo.EndTime;
            data.IsDone = todo.IsDone;
            data.Description = todo.Description;

            var save = _context.SaveChanges();
            if (save <= 0)
            {
                TempData["update"] = "false";
                return RedirectToAction("GetPlans");
            }

            TempData["update"] = "true";
            return RedirectToAction("GetPlans");
        }


        public IActionResult Delete(int id)
        {
            TempData["delete"] = null;
            var data = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                TempData["delete"] = "false";
                return RedirectToAction("GetPlans");
            }
            _ = _context.Todos.Remove(data);
            var save = _context.SaveChanges();
            if (save <= 0)
            {
                TempData["delete"] = "false";
                return RedirectToAction("GetPlans");
            }

            TempData["delete"] = "true";
            return RedirectToAction("GetPlans");
        }



    }
}
