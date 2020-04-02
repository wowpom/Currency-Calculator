using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Currency_Calculator
{
    public sealed partial class MainPage : Page
    {
        //public Currency[] Valuta = new Currency[2];
        //public Currency[] AllValuta = new Currency[0];
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
                if (char.IsDigit(Convert.ToChar(tb.Text.Substring(tb.Text.Length - 1, 1))) ||
                    (tb.Text.Substring(tb.Text.Length - 1, 1) == "," && !tb.Text.Substring(0, tb.Text.Length - 1).Contains(",")) && TextBoxSec.Text != "")
                {
                    if (tb.Name == "TextBoxOne")
                    {
                        double result = Convert.ToDouble(TextBoxOne.Text) * variables.Valuta[1].Nominal / variables.Valuta[1].Value * variables.Valuta[0].Value / variables.Valuta[0].Nominal;
                        TextBoxSec.Text = result.ToString("F2");
                    }
                    else
                    {
                        double result = Convert.ToDouble(TextBoxSec.Text) * variables.Valuta[0].Nominal / variables.Valuta[0].Value * variables.Valuta[1].Value / variables.Valuta[1].Nominal;
                        TextBoxOne.Text = result.ToString("F2");
                    }
                }
                else
                {
                    tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                    tb.SelectionStart = tb.Text.Length;
                }
            }
            else if (tb.Name == "TextBoxOne")
                TextBoxSec.Text = "";
            else
                TextBoxOne.Text = "";
        }

        private void Loaded(object sender, RoutedEventArgs e)
        {   
            if(CheckingConnectionBool == false)  
                this.Frame.Navigate(typeof(CheckingConnection));
            
        }
    }
}
