﻿#pragma checksum "..\..\..\Sapper\Sapper.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0F07E4D70C00C45A53C8FC32101552A49F7D832B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WPF_LAUNCHER;


namespace WPF_LAUNCHER {
    
    
    /// <summary>
    /// SapperMain
    /// </summary>
    public partial class SapperMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WPF_LAUNCHER.SapperMain Сапёр;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Main_Grid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_easy;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_medium;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_hard;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_title;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_3;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Sapper\Sapper.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_4;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_LAUNCHER;component/sapper/sapper.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Sapper\Sapper.xaml"
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
            this.Сапёр = ((WPF_LAUNCHER.SapperMain)(target));
            return;
            case 2:
            this.Main_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.button_easy = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Sapper\Sapper.xaml"
            this.button_easy.Click += new System.Windows.RoutedEventHandler(this.Choise_difficulty);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_medium = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Sapper\Sapper.xaml"
            this.button_medium.Click += new System.Windows.RoutedEventHandler(this.Choise_difficulty);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_hard = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Sapper\Sapper.xaml"
            this.button_hard.Click += new System.Windows.RoutedEventHandler(this.Choise_difficulty);
            
            #line default
            #line hidden
            return;
            case 6:
            this.label_title = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.image_1 = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.image_2 = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.image_3 = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.image_4 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

