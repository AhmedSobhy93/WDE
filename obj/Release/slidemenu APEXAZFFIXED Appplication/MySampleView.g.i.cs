﻿#pragma checksum "..\..\..\slidemenu APEXAZFFIXED Appplication\MySampleView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8536F35790FBCA8CD0641C6A833ECC2714D20BF9"
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


namespace Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample {
    
    
    /// <summary>
    /// MySampleView
    /// </summary>
    public partial class MySampleView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\slidemenu APEXAZFFIXED Appplication\MySampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample.MySampleView MySampleViewInteractionWorksheet;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\slidemenu APEXAZFFIXED Appplication\MySampleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser zedApplicationLink;
        
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
            System.Uri resourceLocater = new System.Uri("/Genesyslab.Desktop.Modules.ExtensionSample;component/slidemenu%20apexazffixed%20" +
                    "appplication/mysampleview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\slidemenu APEXAZFFIXED Appplication\MySampleView.xaml"
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
            this.MySampleViewInteractionWorksheet = ((Genesyslab.Desktop.Modules.InteractionExtensionSample.MySample.MySampleView)(target));
            
            #line 6 "..\..\..\slidemenu APEXAZFFIXED Appplication\MySampleView.xaml"
            this.MySampleViewInteractionWorksheet.Loaded += new System.Windows.RoutedEventHandler(this.MySampleView_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.zedApplicationLink = ((System.Windows.Controls.WebBrowser)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

