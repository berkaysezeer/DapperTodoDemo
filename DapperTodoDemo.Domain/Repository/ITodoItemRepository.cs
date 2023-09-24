using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://medium.com/software-development-turkey/asp-net-core-dapper-kullanımı-c40f80e0f0dc

namespace DapperTodoDemo.Domain.Repository
{
    //İlgili CRUD işlemlerini belirlenecek
    //4 temel CRUD işlemini tanımladığımız ve Infrastructure katmanında implemente edilecek metotlar
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetListAsync();

        Task<TodoItem> GetAsync(Guid id);

        Task<TodoItem> InsertAsync(TodoItem todoItem);

        Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem);

        Task DeleteAsync(Guid id);
    }
}
