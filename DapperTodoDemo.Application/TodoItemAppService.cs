using AutoMapper;
using DapperTodoDemo.Domain;
using DapperTodoDemo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTodoDemo.Application
{
    public class TodoItemAppService : ITodoItemAppService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemAppService(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUpdateTodoItemDto todoItem)
        {
            var todo = new TodoItem(Guid.NewGuid(), todoItem.Title, todoItem.Description);
            await _todoItemRepository.InsertAsync(todo);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _todoItemRepository.DeleteAsync(id);
        }

        public async Task<TodoItemDto> GetAsync(Guid id)
        {
            var todo = await _todoItemRepository.GetAsync(id);
            return _mapper.Map<TodoItem, TodoItemDto>(todo);
        }

        public async Task<List<TodoItemDto>> GetTodosAsync()
        {
            var todos = await _todoItemRepository.GetListAsync();
            return _mapper.Map<List<TodoItem>, List<TodoItemDto>>(todos);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateTodoItemDto todoItem)
        {
            var todo = new TodoItem(id, todoItem.Title, todoItem.Description)
            {
                Status = todoItem.Status
            };

            await _todoItemRepository.UpdateAsync(id, todo);
        }
    }
}
