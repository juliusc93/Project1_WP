using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Lab1_Contabilidad
{
    [Table]
    public class Report
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ID { get; set; }

        [Column(CanBeNull = false)]
        public int Cycle { get; set; }

        [Column(CanBeNull = false)]
        public double GeneralBalance { get; set; }

        [Column(CanBeNull = false)]
        public double IncomeBalance { get; set; }

        [Column(CanBeNull = false)]
        public double OutcomeBalance { get; set; }

        [Column(CanBeNull = true)]
        public List<String> OutsideTolerance { get; set; }

        [Column(CanBeNull = true)]
        public List<int> Values { get; set; }
    }
}
