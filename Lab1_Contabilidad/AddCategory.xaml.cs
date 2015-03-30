using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Lab1_Contabilidad
{
    public partial class AddCategory : PhoneApplicationPage
    {
        public AddCategory()
        {
            InitializeComponent();
            PageTitle.Text = "Cycle #" + (App.Current as App).Cycle;
        }

        private void Button_Tap(object sender, GestureEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCategory.Text) || String.IsNullOrWhiteSpace(txtValue.Text))
                MessageBox.Show("Can't leave a field blank!");
            else
            {
                using (ProjectDataContext context = new ProjectDataContext(App.connStr))
                {
                    var CheckCategory = (from Cat in context.Categories where Cat.Name.Equals(txtCategory.Text) select Cat).FirstOrDefault();
                    if (CheckCategory != null) MessageBox.Show("There is already a category with this name for this cycle.");
                    else
                    {
                        Category cat = new Category()
                        {
                            Cycle = (App.Current as App).Cycle,
                            Name = txtCategory.Text,
                            Type = ((bool)rbtnIn.IsChecked) ? "Income" : "Outcome",
                            ExpectedValue = double.Parse(txtValue.Text),
                            RealValue = double.Parse("0")
                        };
                        context.Categories.InsertOnSubmit(cat);
                        context.SubmitChanges();
                        MessageBox.Show("Category Added Successfully");
                    }
                }
            }
        }

        private void Button_Tap_1(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiddleWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}