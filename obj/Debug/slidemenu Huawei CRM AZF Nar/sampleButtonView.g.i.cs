﻿#pragma checksum "..\..\..\slidemenu Huawei CRM AZF Nar\sampleButtonView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5FDD9F473810454D513903015666AA85"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Genesyslab.Desktop.WPFCommon;
using Genesyslab.Desktop.WPFCommon.Controls;
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


namespace Genesyslab.Desktop.Modules.ExtensionSample.slidemenu_Huawei_CRM_AZF_Nar {
    
    
    /// <summary>
    /// sampleButtonView
    /// </summary>
    public partial class sampleButtonView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\slidemenu Huawei CRM AZF Nar\sampleButtonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Genesyslab.Desktop.WPFCommon.Controls.SideButton splitToggleButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Genesyslab.Desktop.Modules.ExtensionSample;component/slidemenu%20huawei%20crm%20" +
                    "azf%20nar/samplebuttonview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\slidemenu Huawei CRM AZF Nar\sampleButtonView.xaml"
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
            this.splitToggleButton = ((Genesyslab.Desktop.WPFCommon.Controls.SideButton)(target));
            
            #line 17 "..\..\..\slidemenu Huawei CRM AZF Nar\sampleButtonView.xaml"
            this.splitToggleButton.Click += new System.Windows.RoutedEventHandler(this.splitToggleButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

