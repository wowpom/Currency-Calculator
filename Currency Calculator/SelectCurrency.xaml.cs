using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Thickness = Windows.UI.Xaml.Thickness;

namespace Currency_Calculator
{
    public sealed partial class SelectCurrency : Page
    {
        Currency[] Valuta = new Currency[2];
        MainPage mp = new MainPage();
        public Variables variables = new Variables();

        public SelectCurrency()
        {
            this.InitializeComponent();
            foreach (var val in mp.AllValuta)
            {
                var button = new Button();
                button.Width = 360;
                button.Height = 32;
                foreach (var valuta in mp.Valuta)
                {
                    if (valuta.Name == val.Name)
                        button.Content = button.Content + " (Выбрано)";
                    else
                        button.Content = val.Name;
                }
                button.Margin=new Thickness(0,10,0,0);
                
                button.HorizontalAlignment=HorizontalAlignment.Center;
                button.Click += ClickBut;
                SP.Children.Add(button);
            }
        }
        private void ClickBut(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            variables.NewValuta =Convert.ToString(bt.Content);
            this.Frame.Navigate(typeof(MainPage),variables);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            variables = (Variables)e.Parameter;
            base.OnNavigatedTo(e);
        }
    }
}
