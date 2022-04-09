using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_App.Model;
using To_Do_App.Services;

namespace To_Do_App.Pages
{
    public class HomeModel : PageModel
    {
        private ToDoService _service;
        public List<ToDoModel> Items { get; set; }

        public HomeModel(ToDoService service)
        {
            _service = service;
        }

        //Called on page load
        public ActionResult OnGet()
        {
            Items = _service.GetIncompleteToDos();
            return Page();
        }

        //Called on Mark as Done button action
        public IActionResult OnPostSubmit(int id)
        {
            List<ToDoModel> items = _service.GetIncompleteToDos();
            ToDoModel model = items.Find(m => m.Id == id);

            Items = _service.MarkAsDone(model);
            return Page();
        }

    }
}