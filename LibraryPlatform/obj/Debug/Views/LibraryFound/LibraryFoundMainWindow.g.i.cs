﻿#pragma checksum "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8F626819881D0163BC7A5D053B3AC0077C3DAA583190DF2AA7FD59C5C7C345A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LibraryPlatform.Views.LibraryFound;
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


namespace LibraryPlatform.Views.LibraryFound {
    
    
    /// <summary>
    /// LibraryFoundMainWindow
    /// </summary>
    public partial class LibraryFoundMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button publishersButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button booksButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button libraryCardButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bookCardButton;
        
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
            System.Uri resourceLocater = new System.Uri("/LibraryPlatform;component/views/libraryfound/libraryfoundmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
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
            this.publishersButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\..\Views\LibraryFound\LibraryFoundMainWindow.xaml"
            this.publishersButton.Click += new System.Windows.RoutedEventHandler(this.publishersButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.booksButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.libraryCardButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.bookCardButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

