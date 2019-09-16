using ToDo_List_App.Service;
using System.Threading.Tasks;
using System;
using ToDo_List_App.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDo_List_App.ViewModel;
using System.Threading;
using Xunit;

namespace ToDoListAngularApp.Tests
{
    public class ToDoListControllerTest : IDisposable
    {
        private readonly TodoService _todoService;
        protected readonly TodoDbContext _context;
        public ToDoListControllerTest()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new TodoDbContext(options);

            _context.Database.EnsureCreated();

            // this.Initialize(_context);

            this._todoService = new TodoService();

        }
 
        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

            var controller = new ToDoListController(this._todoService);

            // var result = await controller.PostCustomer(new Customer { Id = 7, Name = "Scary Terry" });

            var result = await controller.AddTodo(new TodoAddViewModel
            {
                WorkTodo = "Item1",
                IsCompleted = false
            });//.ConfigureAwait(false);

            // Assert.NotNull(result);


            //  var result = await _todoService.Add(new Todo
            //    {
            //        WorkTodo = "Item1",
            //        IsCompleted = false
            //    }).ConfigureAwait(false); 


            //Console.WriteLine(result);

            //Assert.Equals("1", "1");
            // SynchronizationContext.Current.Post(state => { }, null);

            // await Task.Yield();
            
            //Assert.IsType<OkObjectResult>(result);
            //Assert.That(result, Is.InstanceOf<OkObjectResult>());



            //Assert.AreEqual(result, BadRequest());
        }


        public void Initialize(TodoDbContext context)
        {
            if (context.Todos.Any())
            {
                return;
            }

            // Seed(context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}