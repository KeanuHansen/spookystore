﻿#pragma checksum "..\..\..\Search\wndSearch.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A96ED6644146A457D8B12A30983093ADB401950EFFF9FB4546F121117692F091"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupProjectPrototype;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GroupProjectPrototype {
    
    
    /// <summary>
    /// SearchWindow
    /// </summary>
    public partial class SearchWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button mainButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ItemDatagrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceNum;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker invoiceDate;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceTotalCharge;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonFilter;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClear;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSelectInvoice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GroupProjectPrototype;component/search/wndsearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Search\wndSearch.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Search\wndSearch.xaml"
            this.mainButton.Click += new System.Windows.RoutedEventHandler(this.mainButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ItemDatagrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\Search\wndSearch.xaml"
            this.ItemDatagrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.invoiceNum = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.invoiceDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.invoiceTotalCharge = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.buttonFilter = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Search\wndSearch.xaml"
            this.buttonFilter.Click += new System.Windows.RoutedEventHandler(this.buttonFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonClear = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Search\wndSearch.xaml"
            this.buttonClear.Click += new System.Windows.RoutedEventHandler(this.buttonClear_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonSelectInvoice = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Search\wndSearch.xaml"
            this.buttonSelectInvoice.Click += new System.Windows.RoutedEventHandler(this.buttonSelectInvoice_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

