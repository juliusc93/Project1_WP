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
    public partial class MiddleWindow : PhoneApplicationPage
    {
        public MiddleWindow()
        {
            InitializeComponent();
            PageTitle.Text = "Cycle #" + (App.Current as App).Cycle;
            LoadCategories();

            btnEdit.IsEnabled = btnAdd.IsEnabled = (App.Current as App).Cycle == (App.Current as App).LastCycle;
        }

        private void LoadCategories()
        {
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                IQueryable<Category> CategoryList = (from Categories in context.Categories where Categories.Cycle == (App.Current as App).Cycle select Categories);
                List<Category> CategoryItems = CategoryList.ToList();
                CategoryListBox.ItemsSource = CategoryItems;
            }
        }

        private void btnSave_Tap(object sender, GestureEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtPercent.Text)) MessageBox.Show("A percent value is required");
            else NavigationService.Navigate(new Uri("/ReportWindow.xaml?tol=" + txtPercent.Text, UriKind.RelativeOrAbsolute));
        }

        /*private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryListBox.SelectedIndex != -1)
            {
                if ((App.Current as App).Cycle == (App.Current as App).LastCycle)
                {
                    Category cat = (Category)CategoryListBox.SelectedItem;
                    NavigationService.Navigate(new Uri("/EditCategory.xaml?id=" + cat.ID, UriKind.RelativeOrAbsolute));
                }
            }
        }*/

        private void btnAdd_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddCategory.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnEdit_Tap(object sender, GestureEventArgs e)
        {
            if (CategoryListBox.SelectedIndex != -1)
            {
                Category cat = (Category)CategoryListBox.SelectedItem;
                NavigationService.Navigate(new Uri("/EditCategory.xaml?id=" + cat.ID, UriKind.RelativeOrAbsolute));
            }
            else MessageBox.Show("A category must be selected in order to edit it!");
        }

        private void btnCatReport_Tap(object sender, GestureEventArgs e)
        {
            if (CategoryListBox.SelectedIndex != -1)
            {
                Category cat = (Category)CategoryListBox.SelectedItem;
                NavigationService.Navigate(new Uri("/ReportByCategory.xaml?name=" + cat.Name, UriKind.RelativeOrAbsolute));
            }
            else MessageBox.Show("A category must be selected in order to view its history!");
        }

        private void button1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml?name=", UriKind.RelativeOrAbsolute));
        }
    }
}