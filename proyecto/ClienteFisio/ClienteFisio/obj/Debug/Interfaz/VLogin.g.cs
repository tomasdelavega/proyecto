﻿#pragma checksum "..\..\..\Interfaz\VLogin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A16CDC6189397825EBDFB2069B0E7F7A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// VLogin
    /// </summary>
    public partial class VLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Label lblUsu;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.TextBox txtUsu;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Label lblPass;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.PasswordBox txtPass;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Canvas canvas2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Button btnEntrar;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Interfaz\VLogin.xaml"
        internal System.Windows.Controls.Label lblAviso;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteFisio;component/interfaz/vlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Interfaz\VLogin.xaml"
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
            
            #line 5 "..\..\..\Interfaz\VLogin.xaml"
            ((ClienteFisio.Interfaz.VLogin)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.lblUsu = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtUsu = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lblPass = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 13 "..\..\..\Interfaz\VLogin.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.canvas2 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.btnEntrar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Interfaz\VLogin.xaml"
            this.btnEntrar.Click += new System.Windows.RoutedEventHandler(this.btnEntrar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 25 "..\..\..\Interfaz\VLogin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.lblAviso = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
