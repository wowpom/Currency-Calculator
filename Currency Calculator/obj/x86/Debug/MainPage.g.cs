﻿#pragma checksum "C:\Users\Kialot\Desktop\Currency Calculator\Currency Calculator\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "321F0582F20DA9D16DF3AF3A5DBFD7E3054BE04D631C216CA90EE9ED4D41056E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Currency_Calculator
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 9 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.MainPageStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.TextBoxOne = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 13 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.TextBoxOne).KeyUp += this.TextBoxSec_KeyUp;
                    #line default
                }
                break;
            case 4:
                {
                    this.TextBoxSec = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 14 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.TextBoxSec).KeyUp += this.TextBoxSec_KeyUp;
                    #line default
                }
                break;
            case 5:
                {
                    this.TextBlockOne = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6:
                {
                    this.TextBlockSec = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.HyperButtonOne = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 17 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.HyperButtonOne).Click += this.HyperlinkButton_Click;
                    #line default
                }
                break;
            case 8:
                {
                    this.HyperButtonSec = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    #line 18 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.HyperButtonSec).Click += this.HyperlinkButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

