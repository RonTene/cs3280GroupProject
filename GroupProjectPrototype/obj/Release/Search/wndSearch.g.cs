﻿#pragma checksum "..\..\..\Search\wndSearch.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "52A48DAE2EEE4E8BA37E513FEF89009748DAA4F567C9F129AF84A08495AE8959"
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


namespace GroupProjectPrototype.Search {
    
    
    /// <summary>
    /// wndSearch
    /// </summary>
    public partial class wndSearch : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GroupProjectPrototype.Search.wndSearch Search;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label invoiceNumLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceNumSelect;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InvoiceCostLabel;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox InvoiceCostSelect;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label invoiceDateLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker invoiceDateSelect;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataDisplay;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submitButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Search\wndSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
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
            this.Search = ((GroupProjectPrototype.Search.wndSearch)(target));
            
            #line 8 "..\..\..\Search\wndSearch.xaml"
            this.Search.Closing += new System.ComponentModel.CancelEventHandler(this.Search_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.invoiceNumLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.invoiceNumSelect = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\Search\wndSearch.xaml"
            this.invoiceNumSelect.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filters_changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.InvoiceCostLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.InvoiceCostSelect = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\Search\wndSearch.xaml"
            this.InvoiceCostSelect.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filters_changed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.invoiceDateLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.invoiceDateSelect = ((System.Windows.Controls.DatePicker)(target));
            
            #line 20 "..\..\..\Search\wndSearch.xaml"
            this.invoiceDateSelect.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.filters_changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dataDisplay = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\..\Search\wndSearch.xaml"
            this.dataDisplay.CurrentCellChanged += new System.EventHandler<System.EventArgs>(this.dataDisplay_CurrentCellChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.submitButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Search\wndSearch.xaml"
            this.submitButton.Click += new System.Windows.RoutedEventHandler(this.submitButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Search\wndSearch.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.clearButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

