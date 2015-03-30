using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Lab1_Contabilidad
{
    public class ProjectDataContext : DataContext
    {
        public ProjectDataContext(String connectionString)
            : base(connectionString)
        {

        }

        public Table<Category> Categories
        {
            get
            {
                return this.GetTable<Category>();
            }
        }

        /*public Table<Report> Reports
        {
            get
            {
                return this.GetTable<Report>();
            }
        }
        */
    }
}
