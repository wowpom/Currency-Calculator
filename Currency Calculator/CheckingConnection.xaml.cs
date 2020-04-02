using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Currency_Calculator
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class CheckingConnection : Page
    {
        public CheckingConnection()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try { 
                using (var client = new HttpClient())
                {
                 var response = client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js").GetAwaiter().GetResult();
                }
                this.Frame.Navigate(typeof(MainPage));
            }   
            catch {
                TB.Text = "Интернет всё ещё не работает! Проверьте интернет соединение и попробуйте ещё раз!";
            }

        }
    }
}
