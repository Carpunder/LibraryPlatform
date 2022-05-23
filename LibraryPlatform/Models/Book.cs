using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlatform.Models
{
    public class Book
    {
        public Book()
        {
            BookId = Guid.NewGuid();
            DateOfPublication = DateTime.Now;
            Copies = new List<Copy>();
        }
        
        public Guid BookId { get; set; }
        
        [Required(ErrorMessage = "Название книги не указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длинна")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Автор не указан")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Недопустимая длинна")]
        public string Author { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateOfPublication { get; set; }
        
        [Required(ErrorMessage = "Страницы не указаны")]
        [Range(5, 500, ErrorMessage = "Неверный диапазон")]
        public int Pages { get; set; }
        
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Неверный диапазон")]
        public string Genre { get; set; }
        
        [Required(ErrorMessage = "Количество не указано")]
        [Range(1, 100, ErrorMessage = "Неверный диапазон")]
        public int Count { get; set; }
        
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        
        public List<Copy> Copies { get; set; }
    }
}