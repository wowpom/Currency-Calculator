using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Currency_Calculator
{
    public sealed partial class MainPage : Page
    {
        public int NumberHyperLink;
        public Variables variables = new Variables();
        private Boolean CheckingConnectionBool = true;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hb = (HyperlinkButton)sender;
            if (hb.Name == "HyperButtonOne")
                variables.numb = 1;
            else
                variables.numb = 2;
            this.Frame.Navigate(typeof(SelectCurrency),variables);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            if(e.Parameter == "" || e.Parameter == null)
            {
                try
                {
                    variables.numb = 0;
                    variables.AllValuta = Currency.CreateValuta(variables.AllValuta);

                    foreach (var val in variables.AllValuta)
                    {
                        if (val.Name == "Российский рубль")
                            variables.Valuta[0] = val;
                        else if (val.Name == "Доллар США")
                            variables.Valuta[1] = val;
                    }
                }
                catch {
                    CheckingConnectionBool = false;
                    
                }
            }
            else 
            { 
               variables = (Variables)e.Parameter;

                foreach (var val in variables.AllValuta)
                {
                    if (val.Name == variables.NewValuta)
                    {
                        variables.Valuta[variables.numb - 1] = val;
                    }
                }
                TextBlockOne.Text = variables.Valuta[0].CharCode;
                TextBlockSec.Text = variables.Valuta[1].CharCode;
                CheckingConnectionBool = true;
            }
            base.OnNavigatedTo(e);
        }
        private void TextBoxSec_KeyUp(object sender, KeyRoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {
                
                if (tb.Name == "TextBoxOne")
                {
                    TextBoxSec.Text = variables.Сalculation(1, Convert.ToDouble(TextBoxOne.Text) , variables).ToString("F2");
                }
                else
                {
                    TextBoxOne.Text = variables.Сalculation(2, Convert.ToDouble(TextBoxSec.Text), variables).ToString("F2");
                }
               
            }
            else if(tb.Text == "0")
                tb.Text = tb.Text + ",";
            else
            {
                TextBoxSec.Text = "";
                TextBoxOne.Text = "";
            }
        }
        private void Loaded(object sender, RoutedEventArgs e)
        {   
            if(CheckingConnectionBool == false)  
                this.Frame.Navigate(typeof(CheckingConnection));
            
        }
        private void TextBoxOne_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!((int)e.Key >= 48 && (int)e.Key <= 57) && !((int)e.Key>= 96 && (int)e.Key <= 105))
                e.Handled = true;
            if (e.KeyStatus.ScanCode == 14)
                e.Handled = false;
            if (((int)e.Key == 188 || (int)e.Key == 110) && !(tb.Text.Contains(",")) && tb.Text != "") 
            { 
                tb.Text = tb.Text + ",";
                tb.SelectionStart = tb.Text.Length;
            }

        }
    }
}
