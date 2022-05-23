using System.Windows;
using LibraryPlatform.Controllers;
using LibraryPlatform.Views.LibraryFound;
using LibraryPlatform.Models;

namespace LibraryPlatform.Views.Admin
{
    public partial class AdminWindow : Window
    {
        private readonly BooksController _controller;
        public AdminWindow()
        {
            _controller = new BooksController();
            InitializeComponent();
        }

        private void booksButton_Click(object sender, RoutedEventArgs e)
        {
            var adminBookWindow = new AdminBookWindow();
            adminBookWindow.Show();
            Close();
        }

        private void foundButton_Click(object sender, RoutedEventArgs e)
        {
            var libFoundWindow = new LibraryFoundMainWindow();
            libFoundWindow.Show();
            Close();
        }
    }
}