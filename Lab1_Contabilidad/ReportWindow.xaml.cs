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
    public partial class ReportWindow : PhoneApplicationPage
    {
        double ExIns=0, ExOuts=0, RealIns = 0, RealOuts = 0;
        int tol;
        List<String> Outliers = new List<String>();

        public ReportWindow()
        {
            InitializeComponent();
            PageTitle.Text = "Cycle #" + (App.Current as App).Cycle;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tol = int.Parse(NavigationContext.QueryString["tol"]);
            btnNext.IsEnabled = ((App.Current as App).Cycle == (App.Current as App).LastCycle);

            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {
                IQueryable<Category> CategoryList = from Categories in context.Categories 
                                                    where Categories.Cycle == (App.Current as App).Cycle
                                                    select Categories;
                List<Category> CategoryItems = CategoryList.ToList();
                foreach (Category item in CategoryItems)
                {
                    if (item.Type.Equals("Income"))
                    {
                        ExIns += item.ExpectedValue;
                        RealIns += item.RealValue;
                    }
                    else
                    {
                        ExOuts += item.ExpectedValue;
                        RealOuts += item.RealValue;
                    }

                    int Percentage = Convert.ToInt32(((item.RealValue - item.ExpectedValue) / item.ExpectedValue) * 100);
                    if (Math.Abs(Percentage) > tol)
                    {
                        if (Percentage > 0) Outliers.Add("The category " + item.Name + " was exceeded by " + Math.Abs(Percentage) + "%");
                        else Outliers.Add("The category " + item.Name + " was not reached by " + Math.Abs(Percentage) + "%");
                    }
                }
            }
            txtGenC.Text = "" + RealIns + "-" + RealOuts;
            txtIncC.Text = "" + RealIns + "-" + ExIns;
            txtOutC.Text = "" + ExOuts + "-" + RealOuts;
            txtGenT.Text = (RealIns-RealOuts).ToString();
            txtIncT.Text = (RealIns-ExIns).ToString();
            txtOutT.Text = (ExOuts-RealOuts).ToString();

            OutliersListBox.ItemsSource = Outliers;
        }

        private void btnNext_Tap(object sender, GestureEventArgs e)
        {
            SaveCycle();
            NavigationService.Navigate(new Uri("/MiddleWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMainMenu_Tap(object sender, GestureEventArgs e)
        {
            if ((App.Current as App).Cycle == (App.Current as App).LastCycle) SaveCycle();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SaveCycle()
        {
            using (ProjectDataContext context = new ProjectDataContext(App.connStr))
            {

                /*Report rep = new Report()
                {
                    Cycle = (App.Current as App).Cycle,
                    GeneralBalance = RealIns - RealOuts,
                    IncomeBalance = RealIns - ExIns,
                    OutcomeBalance = ExOuts - RealOuts
                };
                context.Reports.InsertOnSubmit(rep);
                context.SubmitChanges();
                */

                //Carry over all categories of this cycle with the current expected values to the next cycle
                //So that we can keep a record of the past expected values of previous cycles.

                IQueryable<Category> CategoryList = from Categories in context.Categories
                                                    where Categories.Cycle == (App.Current as App).Cycle
                                                    select Categories;
                List<Category> CategoryItems = CategoryList.ToList();
                Category ImportedCategory;
                foreach (Category item in CategoryItems)
                {
                    ImportedCategory = new Category()
                    {
                        Cycle = (App.Current as App).Cycle + 1,
                        Name = item.Name,
                        Type = item.Type,
                        ExpectedValue = item.ExpectedValue,
                        RealValue = double.Parse("0")
                    };
                    context.Categories.InsertOnSubmit(ImportedCategory);
                    context.SubmitChanges();
                }
            }
            (App.Current as App).Cycle++;
            (App.Current as App).LastCycle++;
        }
    }
}