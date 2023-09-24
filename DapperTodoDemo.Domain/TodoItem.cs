//https://medium.com/software-development-turkey/asp-net-core-dapper-kullanımı-c40f80e0f0dc

using System;

namespace DapperTodoDemo.Domain
{
    //veritabanındaki dbo.TodoItems tablosuna karşılık gelen bir entity görevi görür.
    //veritabanına yapmış olduğumuz sorgular sonucunda dönen değerleri deserialize ederek ilgili sınıf üzerinden işlemlerimize devam edebilmekteyiz.

    public class TodoItem
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }

        protected TodoItem() //(constructor)  ORM deserialization'u için
        {

        }

        public TodoItem(Guid id, string title, string description)
        {
            Id = id;
            SetTitle(title);
            SetDescription(description);
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException($"{nameof(title)} boş bırakılamaz.");

            Title = title;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException($"{nameof(Description)} boş bırakılamaz.");

            Description = description;
        }

        internal void ChangeStatus(TodoStatus status)
        {
            Status = status;
        }
    }
}