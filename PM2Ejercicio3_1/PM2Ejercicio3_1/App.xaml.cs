using PM2Ejercicio3_1.Models;
using PM2Ejercicio3_1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2Ejercicio3_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AlumnosView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
