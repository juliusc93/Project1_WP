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
    public partial class EditCategory : PhoneApplicationPage
    {
        int id;
        public EditCategory()
        {
            InitializeComponent();
            PageTitle.Text = "Cycle #" + (App.Current as App).Cycle;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            id = int.Parse(NavigationContext.QueryString["id"]);
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                var LoadedCategory = (from Cat in context.Categories where Cat.ID == id select Cat).FirstOrDefault();
                if (LoadedCategory != null)
                {
                    txtName.Text = "Modifying: " + LoadedCategory.Name;
                    txtExValue.Text = LoadedCategory.ExpectedValue.ToString();
                    txtSpValue.Text = "0";
                }
            }
        }

        private void btnSave_Tap(object sender, GestureEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSpValue.Text)) txtSpValue.Text = "0";
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                var LoadedCategory = (from Cat in context.Categories where Cat.ID.Equals(id) select Cat).FirstOrDefault();
                if (LoadedCategory != null)
                {
                    LoadedCategory.ExpectedValue = double.Parse(txtExValue.Text);
                    LoadedCategory.RealValue += double.Parse(txtSpValue.Text);
                    context.SubmitChanges();
                }
            }
            NavigationService.Navigate(new Uri("/MiddleWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void txtSpValue_Tap(object sender, GestureEventArgs e)
        {
            txtSpValue.Text = "";
        }
    }
}