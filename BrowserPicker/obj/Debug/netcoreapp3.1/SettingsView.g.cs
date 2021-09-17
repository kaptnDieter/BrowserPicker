﻿#pragma checksum "..\..\..\SettingsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4AFCDD704C30E8D69A0E75FB50406C98682B1154"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using BrowserPicker;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BrowserPicker {
    
    
    /// <summary>
    /// SettingsView
    /// </summary>
    public partial class SettingsView : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 23 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Datagrid_listOfRules;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListView_listOfBrowsers;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_newRuleUrl;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combobox_newRuleBrowser;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Checkbox_globalSettings_alwaysAsk;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Checkbox_globalSettings_writeLog;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\SettingsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combobox_defaultBrowser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BrowserPicker;component/settingsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SettingsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Datagrid_listOfRules = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.ListView_listOfBrowsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.Textbox_newRuleUrl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Combobox_newRuleBrowser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 67 "..\..\..\SettingsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addRule);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Checkbox_globalSettings_alwaysAsk = ((System.Windows.Controls.CheckBox)(target));
            
            #line 77 "..\..\..\SettingsView.xaml"
            this.Checkbox_globalSettings_alwaysAsk.Checked += new System.Windows.RoutedEventHandler(this.alwaysAsk_Changed);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\SettingsView.xaml"
            this.Checkbox_globalSettings_alwaysAsk.Unchecked += new System.Windows.RoutedEventHandler(this.alwaysAsk_Changed);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Checkbox_globalSettings_writeLog = ((System.Windows.Controls.CheckBox)(target));
            
            #line 78 "..\..\..\SettingsView.xaml"
            this.Checkbox_globalSettings_writeLog.Checked += new System.Windows.RoutedEventHandler(this.writeLog_Changed);
            
            #line default
            #line hidden
            
            #line 78 "..\..\..\SettingsView.xaml"
            this.Checkbox_globalSettings_writeLog.Unchecked += new System.Windows.RoutedEventHandler(this.writeLog_Changed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Combobox_defaultBrowser = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\..\SettingsView.xaml"
            this.Combobox_defaultBrowser.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combobox_defaultBrowser_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 30 "..\..\..\SettingsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteRule);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

