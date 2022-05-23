using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlatform.Models
{
    public class Publisher
    {
        public Publisher()
        {
            PublisherId = Guid.NewGuid();
            Books = new List<Book>();
        }
        public Guid PublisherId { get; set; }
        
        [Required(ErrorMessage = "Имя не указано")]
        [Range(1, 100, ErrorMessage = "Недопустимая длинна")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Телефон не указан")]
        [Phone(ErrorMessage = "Неверный формат")]
        public string Phone { get; set; }
        
        [Range(1, 50, ErrorMessage = "Недопустимая длинна")]
        public string City { get; set; }
        
        public List<Book> Books { get; set; }
    }
}