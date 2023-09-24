//https://medium.com/software-development-turkey/asp-net-core-dapper-kullanımı-c40f80e0f0dc
//Application katmanı, kullanıcının uygulamamızda gerçekleştirdiği işlemlere karşılık gelen use-case’lerin tanımlandığı bir katmandır ve uygulamamızın Business Logic’i burada tanımlanır.
using DapperTodoDemo.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DapperTodoDemo.Application
{
    public class TodoItemDto //Data Transfer Object
    {
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        public string Title { get; set; }

        [Required]
        [NotNull]
        public string Description { get; set; }

        public TodoStatus Status { get; set; }
    }

    public class CreateUpdateTodoItemDto
    {

        [Required]
        [NotNull]
        public string Title { get; set; }

        [Required]
        [NotNull]
        public string Description { get; set; }

        public TodoStatus Status { get; set; }

    }
}