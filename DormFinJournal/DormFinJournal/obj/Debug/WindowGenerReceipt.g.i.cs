﻿#pragma checksum "..\..\WindowGenerReceipt.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A072BDD560DF106136FC566D08268205F203F8B861AA4B1CF067427C34EAC314"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DormFinJournal;
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


namespace DormFinJournal {
    
    
    /// <summary>
    /// WindowGenerReceipt
    /// </summary>
    public partial class WindowGenerReceipt : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\WindowGenerReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TenantInfoTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\WindowGenerReceipt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TenantsComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/DormFinJournal;component/windowgenerreceipt.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowGenerReceipt.xaml"
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
            this.TenantInfoTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TenantsComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\WindowGenerReceipt.xaml"
            this.TenantsComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TenantsComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\WindowGenerReceipt.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnBackMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\WindowGenerReceipt.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnReceipt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

