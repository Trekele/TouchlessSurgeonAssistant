﻿#pragma checksum "..\..\winChecklist.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7849F58023CE3B8E6A0A5E251043A61B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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
using TouchlessSurgeonAssistant;


namespace TouchlessSurgeonAssistant {
    
    
    /// <summary>
    /// winChecklist
    /// </summary>
    public partial class winChecklist : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\winChecklist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\winChecklist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_Copy;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\winChecklist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_Copy1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\winChecklist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label procedureName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\winChecklist.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label procedureArea;
        
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
            System.Uri resourceLocater = new System.Uri("/TouchlessSurgeonAssistant;component/winchecklist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\winChecklist.xaml"
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
            this.checkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\winChecklist.xaml"
            this.checkBox.Checked += new System.Windows.RoutedEventHandler(this.checkBox_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.checkBox_Copy = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.checkBox_Copy1 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\winChecklist.xaml"
            this.checkBox_Copy1.Checked += new System.Windows.RoutedEventHandler(this.checkBox_Copy1_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.procedureName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.procedureArea = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

