using PM2Ejercicio3_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2Ejercicio3_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlumnosView : ContentPage
    {
        public AlumnosView()
        {
            InitializeComponent();
            BindingContext = new AlumnosViewModel();
        }

    
        private void btnActualiarImagen_Clicked(object sender, EventArgs e)
        {

        }

        private void btnVerLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaAlumnos());
        }
    }
}