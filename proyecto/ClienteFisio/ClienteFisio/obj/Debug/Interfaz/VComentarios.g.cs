﻿#pragma checksum "..\..\..\Interfaz\VComentarios.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "813134BC66C5A3E55B523573459CADD0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace ClienteFisio.Interfaz {
    
    
    /// <summary>
    /// VComentarios
    /// </summary>
    public partial class VComentarios : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Interfaz\VComentarios.xaml"
        internal System.Windows.Controls.ListView listViewComs;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Interfaz\VComentarios.xaml"
        internal System.Windows.Controls.TextBox textBox1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Interfaz\VComentarios.xaml"
        internal System.Windows.Controls.Button btnVolver;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Interfaz\VComentarios.xaml"
        internal Microsoft.Windows.Controls.Calendar calendar1;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Interfaz\VComentarios.xaml"
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Interfaz\VComentarios.xaml"
        internal System.Windows.Controls.Label lblAvisos;
        
        #line default
        #line hidden
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteFisio;component/interfaz/vcomentarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Interfaz\VComentarios.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\Interfaz\VComentarios.xaml"
            ((ClienteFisio.Interfaz.VComentarios)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\Interfaz\VComentarios.xaml"
            ((ClienteFisio.Interfaz.VComentarios)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listViewComs = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\Interfaz\VComentarios.xaml"
            this.listViewComs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewPac_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnVolver = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Interfaz\VComentarios.xaml"
            this.btnVolver.Click += new System.Windows.RoutedEventHandler(this.btnVolver_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.calendar1 = ((Microsoft.Windows.Controls.Calendar)(target));
            return;
            case 6:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\Interfaz\VComentarios.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.btnEliminar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblAvisos = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
