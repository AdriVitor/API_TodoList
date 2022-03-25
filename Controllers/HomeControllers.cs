using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers {

    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("/")]
        // [Route("/a")]
        public List<TodoModel> Get([FromServices] AppDbContext context){
            return context.Todos.ToList();
        }

        [HttpPost("/")]
        public TodoModel Post([FromBody] TodoModel todo,
                              [FromServices] AppDbContext context){

                                 context.Todos.Add(todo);
                                 context.SaveChanges();

                                 return todo;
                             }

        [HttpGet("/{id:int}")]

        public TodoModel GetById([FromRoute] int id,
                                 [FromServices] AppDbContext context)
                                 {
                                    return context.Todos.FirstOrDefault(x=>x.Id == id);
                                 }


        [HttpPut("/{id:int}")]

        public TodoModel Put([FromRoute] int id,
                             [FromBody] TodoModel todo,
                             [FromServices] AppDbContext context){

                                 var model = context.Todos.FirstOrDefault(x=>x.Id == id);

                                 model.Title = todo.Title;
                                 model.Done = todo.Done;

                                 context.Todos.Update(model);
                                 context.SaveChanges();
                                 return model;

                             }

        [HttpDelete("/{id:int}")]
        public TodoModel Delete([FromRoute] int id,
                                [FromServices] AppDbContext context){
                                
                                var model = context.Todos.FirstOrDefault(x => x.Id == id);

                                context.Todos.Remove(model);
                                context.SaveChanges();
                                return model;
        }
    }
}