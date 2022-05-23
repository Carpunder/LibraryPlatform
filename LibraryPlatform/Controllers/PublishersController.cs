using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers
{
    public class PublishersController
    {
        private readonly AppDbContext _context;

        public PublishersController()
        {
            _context = new AppDbContext();
        }

        public PublishersController(AppDbContext context)
        {
            _context = context;
        }
    }
}
