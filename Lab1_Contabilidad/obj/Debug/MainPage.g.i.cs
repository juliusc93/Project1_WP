﻿#pragma checksum "C:\Users\JULIO\documents\visual studio 2010\Projects\Lab1_Contabilidad\Lab1_Contabilidad\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "18A6D1B631D0E9FB635D3B49D36B95E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.17929
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Lab1_Contabilidad {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnR;
        
        internal System.Windows.Controls.TextBox txtCycle;
        
        internal System.Windows.Controls.Button btnCycle;
        
        internal System.Windows.Controls.Button btnNewCat;
        
        internal System.Windows.Controls.Button btnView;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Lab1_Contabilidad;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnR = ((System.Windows.Controls.Button)(this.FindName("btnR")));
            this.txtCycle = ((System.Windows.Controls.TextBox)(this.FindName("txtCycle")));
            this.btnCycle = ((System.Windows.Controls.Button)(this.FindName("btnCycle")));
            this.btnNewCat = ((System.Windows.Controls.Button)(this.FindName("btnNewCat")));
            this.btnView = ((System.Windows.Controls.Button)(this.FindName("btnView")));
        }
    }
}
