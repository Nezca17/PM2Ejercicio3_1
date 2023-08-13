using PM2Ejercicio3_1.Models;
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
    public partial class EditarView : ContentPage
    {
        public EditarView()
        {
            InitializeComponent();
            BindingContext = new EditarAlumnoViewModel();
        }

        public EditarView(Alumnos _alumno)
        {
            InitializeComponent();
            BindingContext = new EditarAlumnoViewModel(_alumno);
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void Tomarfoto2_Clicked(object sender, EventArgs e)
        {

        }
    }
}