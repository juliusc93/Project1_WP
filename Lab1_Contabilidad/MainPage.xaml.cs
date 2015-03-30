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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                    (App.Current as App).Cycle = (App.Current as App).LastCycle = 1;
                }
                else
                {
                    var LastCycle = (from Categories in context.Categories
                                    orderby Categories.Cycle descending
                                    select Categories.Cycle
                                    ).FirstOrDefault();
                    if (LastCycle == 0) (App.Current as App).Cycle = (App.Current as App).LastCycle = 1;
                    else (App.Current as App).Cycle = (App.Current as App).LastCycle = LastCycle;
                }
            }
        }

        private void Button_Tap(object sender, GestureEventArgs e)
        {
            int cycle = int.Parse(txtCycle.Text);

            if (cycle > (App.Current as App).LastCycle) MessageBox.Show("This cycle does not exist!");
            else if (cycle < 1) MessageBox.Show("This cycle number is not valid");
            else
            {
                (App.Current as App).Cycle = cycle;
            }
        }

        private void btnNewCat_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddCategory.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnView_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiddleWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Tap_1(object sender, GestureEventArgs e)
        {
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                if (context.DatabaseExists())
                {
                    context.DeleteDatabase();
                    MessageBox.Show("Database successfully cleaned.");
                    btnCycle.IsEnabled = false;
                }
                else MessageBox.Show("Database successfully created.");
                context.CreateDatabase();
                (App.Current as App).Cycle = (App.Current as App).LastCycle = 1;
            }

            NavigationService.Navigate(new Uri("/AddCategory.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}