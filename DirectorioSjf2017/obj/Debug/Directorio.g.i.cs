﻿#pragma checksum "..\..\Directorio.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C88C317422890236CFEC0C29C95DB37"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36373
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DirectorioSjf2017.Converter;
using DirectorioSjf2017.Theme;
using PadronApi.Converter;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;
using UIControls;


namespace DirectorioSjf2017 {
    
    
    /// <summary>
    /// Directorio
    /// </summary>
    public partial class Directorio : Telerik.Windows.Controls.RadWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadBusyIndicator BusyIndicator;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRibbonButton InfoOrganismo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRibbonButton ModificaOrganismo;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRibbonButton BtnEncargadosTC;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UIControls.SearchTextBox TxtBusqueda;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTotales;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Directorio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView GOrganismos;
        
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
            System.Uri resourceLocater = new System.Uri("/DirectorioSjf2017;component/directorio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Directorio.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 13 "..\..\Directorio.xaml"
            ((DirectorioSjf2017.Directorio)(target)).Loaded += new System.Windows.RoutedEventHandler(this.RadWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BusyIndicator = ((Telerik.Windows.Controls.RadBusyIndicator)(target));
            return;
            case 3:
            this.InfoOrganismo = ((Telerik.Windows.Controls.RadRibbonButton)(target));
            
            #line 34 "..\..\Directorio.xaml"
            this.InfoOrganismo.Click += new System.Windows.RoutedEventHandler(this.InfoOrganismo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ModificaOrganismo = ((Telerik.Windows.Controls.RadRibbonButton)(target));
            
            #line 45 "..\..\Directorio.xaml"
            this.ModificaOrganismo.Click += new System.Windows.RoutedEventHandler(this.ModificaOrganismo_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnEncargadosTC = ((Telerik.Windows.Controls.RadRibbonButton)(target));
            
            #line 59 "..\..\Directorio.xaml"
            this.BtnEncargadosTC.Click += new System.Windows.RoutedEventHandler(this.BtnEncargadosTC_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TxtBusqueda = ((UIControls.SearchTextBox)(target));
            return;
            case 7:
            this.LblTotales = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.GOrganismos = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 104 "..\..\Directorio.xaml"
            this.GOrganismos.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.GOrganismos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

