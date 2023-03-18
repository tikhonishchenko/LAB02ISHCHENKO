using LAB02ISHCHENKO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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

namespace LAB01ISHCHENKO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }

        private void CalculateHoroscopes()
        {
            
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CalculateAge())
            {
                return;
            }
            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            person.InitializeAsync();
            FirstNameAns.Content = "Ім'я: "+ person.Name;
            LastNameAns.Content = "Прізвище: " + person.Surname;
            EmailAns.Content = "Електронна пошта: " + person.EmailAddress;
            BirthDayAns.Content = "Дата народження: " + person.DateOfBirth.ToShortDateString();
            IsAdult.Text = "Чи повнолітній: " + person.IsAdult;
            HoroscopeEnglish.Text = "Знак сонця: " + person.SunSign;
            HoroscopeAsian.Text = "Знак китайського зодіаку: " + person.ChineseSign;
            IsBirthday.Text = "Чи є сьогодні днем народження: " + person.IsBirthday;


        }
        private bool CalculateAge()
        {
            DateTime? birthDate = DatePicker.SelectedDate;
            if (birthDate != null)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate > today.AddYears(-age)) age--;
                if (age > 135)
                {
                    MessageBox.Show("Та ти точно не такий старий, давай пиши справжній");
                    return false;
                }
                else if (age < 0)
                {
                    MessageBox.Show("Ти що з утроба пишеш?");
                    return false;
                }
                else
                {
                    if (birthDate.Value.Month == today.Month && birthDate.Value.Day == today.Day)
                        MessageBox.Show("З днем народження!");
                    return true;
                }
            }
            return false;
        }
        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && DatePicker.SelectedDate != null)
            {
                ProceedButton.IsEnabled = true;
            }
            else
            {
                ProceedButton.IsEnabled = false;
            }
        }
    }
}
