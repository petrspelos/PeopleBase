using PeopleBase.Entities;
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
using MessageBox = System.Windows.MessageBox;

namespace PeopleBase
{
    /// <summary>
    /// Interaction logic for NewPersonModal.xaml
    /// </summary>
    public partial class NewPersonModal : Window
    {
        internal PersonForm form;

        public NewPersonModal()
        {
            InitializeComponent();
            form = new PersonForm();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (DateOfBirthPicker.SelectedDate.HasValue)
                form.NewPerson.DateOfBrith = DateOfBirthPicker.SelectedDate.Value;

            form.NewPerson.Email = EmailInput.Text;

            if (!IsValidName(form.NewPerson.FirstName) ||
                !IsValidName(form.NewPerson.LastName) ||
                string.IsNullOrEmpty(form.NewPerson.Email) ||
                form.NewPerson.DateOfBrith >= DateTime.Now)
            {
                MessageBox.Show("Cannot create a new person with the information you provided.",
                    "Cannot create a person", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            form.NewPerson.Gender = GetSelectedGender();
            form.IsFilled = true;
            Close();
        }

        private void FirstNameInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var nameCandidate = FirstNameInput.Text;
            if (IsValidName(nameCandidate))
            {
                FirstNameValidationLabel.Visibility = Visibility.Hidden;
                form.NewPerson.FirstName = nameCandidate;
            }
            else
            {
                FirstNameValidationLabel.Visibility = Visibility.Visible;
            }
        }

        private bool IsValidName(string name) => 
            !(string.IsNullOrEmpty(name) || name.Length < 2 || name.Any(char.IsDigit));

        private void LastNameInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var nameCandidate = LastNameInput.Text;
            if (IsValidName(nameCandidate))
            {
                LastNameValidationLabel.Visibility = Visibility.Hidden;
                form.NewPerson.LastName = nameCandidate;
            }
            else
            {
                LastNameValidationLabel.Visibility = Visibility.Visible;
            }
        }

        private Gender GetSelectedGender()
        {
            if (GenderSelection.SelectedItem.ToString() == "Male")
                return Gender.Male;

            if (GenderSelection.SelectedItem.ToString() == "Female")
                return Gender.Female;

            return Gender.Other;
        }
    }
}
