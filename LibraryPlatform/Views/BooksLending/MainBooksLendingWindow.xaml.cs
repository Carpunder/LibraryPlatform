using LibraryPlatform.Controllers;
using LibraryPlatform.Models;
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

namespace LibraryPlatform.Views.BooksLending
{
    /// <summary>
    /// Interaction logic for MainBooksLendingWindow.xaml
    /// </summary>
    public partial class MainBooksLendingWindow : Window
    {
        private ControllerContext _controllers;
        private readonly AppDbContext _context;

        public MainBooksLendingWindow()
        {
            _context = new AppDbContext();
            _controllers = new ControllerContext(_context);
            InitializeComponent();
            foreach(var reader in _controllers.LibraryCardsController.GetAllReader())
            {
                readersComboBox.Items.Add(reader.LibraryCardNumber);
            }
            foreach(var book in _controllers.CopiesController.GetAll())
            {
                booksComboBox.Items.Add(book.CopyLibNumber);
            }
        }

        private void fioCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            readersComboBox.Items.Clear();
            foreach (var reader in _controllers.LibraryCardsController.GetAllReader())
            {
                readersComboBox.Items.Add(reader.FIO);
            }
        }

        private void fioCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            readersComboBox.Items.Clear();
            foreach (var reader in _controllers.LibraryCardsController.GetAllReader())
            {
                readersComboBox.Items.Add(reader.LibraryCardNumber);
            }
        }

        private void readersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (fioCheckBox.IsChecked == true)
                {
                    var reader = new UserDTO(_context.LibraryCards.Include("User")
                        .FirstOrDefault(x => x.User.FIO == readersComboBox.SelectedValue.ToString()));

                    readersGroupBox.Content = reader;
                    readersDeptDataGrid.ItemsSource = _controllers.BookCardsController.GetDebtBooksByUserName(readersComboBox.SelectedValue.ToString());
                    
                }
                else
                {
                    int.TryParse(readersComboBox.SelectedValue.ToString(), out int libCardNum);
                    var reader = new UserDTO(_context.LibraryCards.Include("User")
                        .FirstOrDefault(x => x.LibraryCardNumber == libCardNum));

                    readersGroupBox.Content = reader;
                    readersDeptDataGrid.ItemsSource = _controllers.BookCardsController.GetDebtBooksByLibraryCardId(libCardNum);
                }
            }
            catch
            {
                return;
            }
        }

        private void giveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (booksComboBox.SelectedValue == null || readersComboBox.SelectedValue == null)
                return;
            var libCard = new LibraryCard();
            if(fioCheckBox.IsChecked == true)
            {
                libCard = _context.LibraryCards.Include("User").FirstOrDefault(x => x.User.FIO == readersComboBox.SelectedValue.ToString());
            }
            else
            {
                if (!int.TryParse(readersComboBox.SelectedValue.ToString(), out int libCardNum)) {
                    return;
                }
                libCard = _context.LibraryCards.Include("User").FirstOrDefault(x => x.LibraryCardNumber == libCardNum);
            }

            var copy = _controllers.CopiesController.GetCopyIdByLibNumber(booksComboBox.SelectedValue.ToString());
            _controllers.BookCardsController.RegisterBookCard(copy.CopyId, libCard);

            MessageBox.Show("Книга успешно отдана");        }

        private void booksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var copy = _controllers.CopiesController.GetCopyIdByLibNumber(booksComboBox.SelectedValue.ToString());

            var book = new CopyDTO(_context.Copies.Include("Book").Include("Book.Publisher").Include("Library")
                .FirstOrDefault(x => x.CopyId == copy.CopyId));
            bookGroupBox.Content = book;
        }

        private void readersDeptDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var bookCard = (BookCardDTO)e.Row.DataContext;
            if (DateTime.Parse(bookCard.DateOfService) < DateTime.Now)
            {
                e.Row.Background = new SolidColorBrush(Colors.IndianRed);
            }
        }
    }
}
