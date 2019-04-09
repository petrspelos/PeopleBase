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
    /// Interaction logic for LoadDataPage.xaml
    /// </summary>
    public partial class LoadDataPage : Page
    {
        public LoadDataPage()
        {
            InitializeComponent();
        }

        private void LoadFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var personFormWindow = new PeopleListingPage();
            NavigationService.Navigate(personFormWindow);
        }
    }
}
