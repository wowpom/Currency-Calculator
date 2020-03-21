using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Currency_Calculator
{
    public sealed partial class MainPage : Page
    {
        public Currency[] Valuta = new Currency[2];
        public Currency[] AllValuta = new Currency[0];
        public int NumberHyperLink;
        public Variables variables = new Variables();

        public MainPage()
        {
            this.InitializeComponent();
            variables.Valuta = Valuta;
            variables.numb = 0;
            AllValuta=Currency.CreateValuta(AllValuta);

            foreach (var val in AllValuta)
            {
                if (val.Name == "Российский рубль")
                    Valuta[0] = val;
                else if (val.Name == "Доллар США")
                    Valuta[1] = val;
            }
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
        {   if(e.Parameter == "")
            {
                Variables variables = new Variables();
            }
            else 
            { 
               variables = (Variables)e.Parameter;

                foreach (var val in AllValuta)
                {
                    if (val.Name == variables.NewValuta)
                    {
                        Valuta[variables.numb - 1] = val;
                    }
                }
                TextBlockOne.Text = Valuta[0].CharCode;
                TextBlockSec.Text = Valuta[1].CharCode;
            }
            base.OnNavigatedTo(e);
        }
        private void TextBoxSec_KeyUp(object sender, KeyRoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {
                if (char.IsDigit(Convert.ToChar(tb.Text.Substring(tb.Text.Length - 1, 1))) ||
                    (tb.Text.Substring(tb.Text.Length - 1, 1) == "," && !tb.Text.Substring(0, tb.Text.Length - 1).Contains(",")))
                {
                    if (tb.Name == "TextBoxOne")
                    {
                        double result = Valuta[0].Value / Valuta[1].Value * Convert.ToDouble(TextBoxOne.Text);
                        TextBoxSec.Text = result.ToString("F2");
                    }
                    else
                    {
                        double result = Valuta[1].Value / Valuta[0].Value * Convert.ToDouble(TextBoxSec.Text);
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


        
    }
}
