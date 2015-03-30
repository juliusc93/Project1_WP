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
using System.Windows.Navigation;

namespace Lab1_Contabilidad
{
    public partial class ReportByCategory : PhoneApplicationPage
    {
        String name;
        public ReportByCategory()
        {
            InitializeComponent();
            PageTitle.Text = "Cycle #" + (App.Current as App).Cycle;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            name = NavigationContext.QueryString["name"];
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                IQueryable<Category> CategoryList = (from Categories in context.Categories 
                                                     where Categories.Name.Equals(name) && Categories.Cycle <= (App.Current as App).Cycle
                                                     select Categories);
                List<Category> CategoryItems = CategoryList.ToList();
                RepCapListBox.ItemsSource = CategoryItems;
            }
        }

        private void button1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MiddleWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}