using LibraryPlatform.Controllers;
using LibraryPlatform.ViewModels;
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

namespace LibraryPlatform.Views.ReturnBook
{
    /// <summary>
    /// Логика взаимодействия для BooksReturnWindow.xaml
    /// </summary>
    public partial class BooksReturnWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;
        public BooksReturnWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            foreach (var reader in _controllers.LibraryCardsController.GetAllReader())
            {
                LibraryCardComboBox.Items.Add(reader.LibraryCardNumber);
            }
        }

        private void LibraryCardComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bookCardComboBox.Items.Clear();
            int.TryParse(LibraryCardComboBox.SelectedValue.ToString(), out int libCardNum);
            var bookCards = _controllers.BookCardsController.GetDebtBooksByLibraryCardId(libCardNum);
            foreach (var bookCard in bookCards)
            {
                bookCardComboBox.Items.Add(bookCard.CopyLibNumber);
            }
            booksDataGrid.ItemsSource = bookCards;
        }

        private void booksDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var bookCard = (BookCardDTO)e.Row.DataContext;
            if (DateTime.Parse(bookCard.DateOfService) < DateTime.Now)
            {
                e.Row.Background = new SolidColorBrush(Colors.IndianRed);
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LibraryCardComboBox.SelectedValue == null || bookCardComboBox.SelectedValue == null)
                {
                    return;
                }
                if (!int.TryParse(LibraryCardComboBox.SelectedValue.ToString(), out int libCardNum))
                {
                    return;
                }
                var libCard = _context.LibraryCards.Include("User").FirstOrDefault(x => x.LibraryCardNumber == libCardNum);
                _controllers.BookCardsController.ReturnCopy(libCardNum, bookCardComboBox.SelectedValue.ToString());

                MessageBox.Show("Книга возвращена");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
