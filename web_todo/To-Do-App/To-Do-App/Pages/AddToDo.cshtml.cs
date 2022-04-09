/*
 * Razor page to add a new todo
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_App.Model;
using To_Do_App.Services;

namespace To_Do_App.Pages
{

    public class AddToDoModel: PageModel
    {
        public ToDoModel ToDoItem = new();
        private ToDoService _service;

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Todo { get; set; } = string.Empty;
        

        public AddToDoModel(ToDoService service)
        {
            _service = service;
        }

        //Fetch data if user press update button
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                List<ToDoModel> items = _service.GetIncompleteToDos();

                ToDoItem = items.FirstOrDefault(m => m.Id == id);

                
                Todo = ToDoItem.Todo;
                
            }

            return Page();
        }


        //when user press add or update, i
        public IActionResult OnPostSubmit(ToDoModel model)
        {
            if (model.Todo == null)
            {
                return null;
            }

            if (model.Id == null)
            {
                model.Id = _service.GetIncompleteToDos().Count + 1;
                model.IsDone = false;
                _service.AddToDo(model);
            }
            else
            {
                List<ToDoModel> items = _service.GetIncompleteToDos();
                int index = items.FindIndex(m => m.Id == model.Id);
                _service.AddToDoAt(model, index);
            }

            return RedirectToPage("Home");

        }

    }
}