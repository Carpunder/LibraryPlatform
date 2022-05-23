using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LibraryPlatform.Views.LibraryFound
{
    /// <summary>
    /// Логика взаимодействия для PublisherWindow.xaml
    /// </summary>
    public partial class PublisherWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public PublisherWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            publishersDataGrid.ItemsSource = _context.Publishers.ToList();
        }

        private void publishersDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            var temp = 1;
        }

        private void publishersDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            var temp = 1;
        }

        private void publishersDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var temp = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
