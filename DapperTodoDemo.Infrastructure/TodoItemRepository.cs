using Dapper;
using DapperTodoDemo.Domain;
using DapperTodoDemo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DapperTodoDemo.Infrastructure
{
    //SqlConnection sınıfının yardımcı methodları olan QueryAsync<>, QueryFirstAsync<> ve ExecuteAsync gibi methodlarla ilgili Raw Sql sorgusunu yazarak veritabanından dönen değerleri Domain katmanında tanımlamış olduğumuz “TodoItem” isimli sınıf ile map’lemiş (Dapper gerçek anlamda burada işe dahil olmuş oluyor) oluyoruz . (Burada ilgili yardımcı methodların senkron hallerinin de olduğunu belirtmek isterim.)
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=DapperTodoDemo;Trusted_Connection=true";

        public async Task<List<TodoItem>> GetListAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            return (await connection.QueryAsync<TodoItem>($"SELECT * FROM dbo.TodoItems")).AsList();
        }

        public async Task<TodoItem> GetAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<TodoItem>($"SELECT * FROM dbo.TodoItems WHERE Id = '{id}'");
        }

        public async Task DeleteAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"DELETE FROM dbo.TodoItems WHERE Id = '{id}'");
        }

        public async Task<TodoItem> InsertAsync(TodoItem todoItem)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO dbo.TodoItems VALUES ('{todoItem.Id}', '{todoItem.Title}', '{todoItem.Description}', {(int)todoItem.Status})";
            await connection.ExecuteAsync(query);
            return todoItem;
        }

        public async Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"UPDATE dbo.TodoItems SET {nameof(TodoItem.Title)} = '{todoItem.Title}', {nameof(TodoItem.Description)} = '{todoItem.Description}', {nameof(TodoItem.Status)} = {(int)todoItem.Status} WHERE Id = '{id}'");
            return todoItem;
        }
    }
}