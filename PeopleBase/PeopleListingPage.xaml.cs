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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleBase
{
    /// <summary>
    /// Interaction logic for PeopleListingPage.xaml
    /// </summary>
    public partial class PeopleListingPage : Page
    {
        public PeopleListingPage()
        {
            InitializeComponent();
        }

        private void NewPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            var popup = new NewPersonModal();
            popup.ShowDialog();
            if(!popup.form.IsFilled)
            {
                MessageBox.Show("Form wasn't filled.");
            }
            else
            {
                MessageBox.Show("Form was filled.");
            }
        }
    }
}
