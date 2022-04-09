/*
 * Service class to manage the todo model;
 */




using System;
using System.Collections.Generic;
using To_Do_App.Model;

namespace To_Do_App.Services
{
    public class ToDoService
    {
        List<ToDoModel> ToDoList = new();
        List<ToDoModel> InCompleteToDoList = new();

        public ToDoService()
        {
            InCompleteToDoList = ToDoList;
        }

        //Incomplete todos
        public List<ToDoModel> GetIncompleteToDos()
        {
            return InCompleteToDoList;
        }

        //Add todo to the list
        public List<ToDoModel> AddToDo(ToDoModel model)
        {
            ToDoList.Add(model);
            return ToDoList;
        }


        //Remove todo
        public List<ToDoModel> RemoveToDo(int id)
        {
            int ItemIndex = 0;

            for (int i = 0; i < ToDoList.Count; i++)
            {
                if (ToDoList[i].Id == id)
                {
                    ItemIndex = i;
                }
            }

            ToDoList.RemoveAt(index: ItemIndex);
            return ToDoList;
        }

        //Replace todo
        public void AddToDoAt(ToDoModel model, int index)
        {
            ToDoList.RemoveAt(index);
            ToDoList.Insert(index, model);
        }

        //Mark todo as done
        public List<ToDoModel> MarkAsDone(ToDoModel model)
        {
            model.IsDone = true;
            int index = InCompleteToDoList.FindIndex(m => m.Id == model.Id);
            InCompleteToDoList.RemoveAt(index);

            return InCompleteToDoList;
        }

        
        
    }
}
