using PeopleBase.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;

namespace PeopleBase
{
    /// <summary>
    /// Interaction logic for PeopleListingPage.xaml
    /// </summary>
    public partial class PeopleListingPage : Page
    {
        private XDocument _xDoc;
        private List<Person> _people;

        public PeopleListingPage(/*string source*/)
        {
            InitializeComponent();
            
            _people = new List<Person>();

            //if (source is null) return;

            //_xDoc = XDocument.Load(source);
        }

        private void NewPersonBtn_Click(object sender, RoutedEventArgs e)
        {
            var popup = new NewPersonModal();
            popup.ShowDialog();
            if(!popup.form.IsFilled)
            {
                //MessageBox.Show("Form wasn't filled.");
            }
            else
            {
                //MessageBox.Show("Form was filled.");
                _people.Add(popup.form.NewPerson);
                Serialize();
            }
        }

        private void Serialize()
        {
            _xDoc = new XDocument(
                new XElement("Root",
                    new XElement("People"))
            );

            var peopleNode = _xDoc.Root?.Element("People");

            foreach (var person in _people)
            {
                peopleNode?.Add(new XElement("Person", 
                    new XAttribute("Name", person.FirstName + " " + person.LastName),
                    new XAttribute("Email", person.Email),
                    new XAttribute("Gender", person.Gender.ToString()),
                    new XAttribute("DateOfBirth", person.DateOfBrith.ToLongDateString())
                ));
            }

            XmlOutput.Document.Blocks.Clear();
            XmlOutput.Document.Blocks.Add(new Paragraph(new Run(_xDoc.ToString())));
        }

        private void SaveFileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            var r = saveFileDialog.ShowDialog();

            if (r == true)
                _xDoc.Save(saveFileDialog.FileName);
        }
    }
}
