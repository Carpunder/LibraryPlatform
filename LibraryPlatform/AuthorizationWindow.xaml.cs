using LibraryPlatform.Models;
using LibraryPlatform.Views.Main;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryPlatform
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        protected readonly AppDbContext _context;
        public AuthorizationWindow()
        {
            _context = new AppDbContext();
            if (!_context.Database.Exists())
            {
                try
                {
                    var libraryStock = new LibraryStock ();
                    var library = new Library
                    {
                        LibraryId = Guid.NewGuid(),
                        Address = "Кошевого 10",
                        Number = "Библиотека-филиал 6",
                        CodeNumber = "AA",
                        Login = "admin",
                        Password = "admin",
                        LibraryStockId = libraryStock.LibraryStockId,
                        LibraryStock = libraryStock
                    };
                    _context.Database.Create();
                    _context.LibraryStocks.Add(libraryStock);
                    _context.Libraries.Add(library);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            
            InitializeComponent();
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            var libary = _context.Libraries.FirstOrDefault(x => x.Login == loginTextBox.Text);
            if (libary != null && libary.Password == passwordBox.Password)
            {
                Values.Values.CurrentLibraryValue = libary.LibraryId;
                Values.Values.Library = libary;
                var mainWindow = new MainWindow(libary.Number);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                enterButton_Click(sender, e);
            }
        }
    }
}
