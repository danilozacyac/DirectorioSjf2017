﻿#pragma checksum "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08FEC1ABA71D1184D4FF6D969A9B7E2D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace DirectorioSjf2017.Formularios.Funcionarios {
    
    
    /// <summary>
    /// SeleccionaEncargados
    /// </summary>
    public partial class SeleccionaEncargados : Telerik.Windows.Controls.RadWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridBuscar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView GTitulares;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LstTipoObra;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox CbxFunciones;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSalir;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuardar;
        
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
            System.Uri resourceLocater = new System.Uri("/DirectorioSjf2017;component/formularios/funcionarios/seleccionaencargados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
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
            
            #line 11 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            ((DirectorioSjf2017.Formularios.Funcionarios.SeleccionaEncargados)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridBuscar = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 33 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            ((UIControls.SearchTextBox)(target)).Search += new System.Windows.RoutedEventHandler(this.SearchTextBox_Search);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GTitulares = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 56 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            this.GTitulares.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.GTitulares_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LstTipoObra = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.CbxFunciones = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 120 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            this.CbxFunciones.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbxFunciones_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            this.BtnSalir.Click += new System.Windows.RoutedEventHandler(this.BtnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            this.BtnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 144 "..\..\..\..\Formularios\Funcionarios\SeleccionaEncargados.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

