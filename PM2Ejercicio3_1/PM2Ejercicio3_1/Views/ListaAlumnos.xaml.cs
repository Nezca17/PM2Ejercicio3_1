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
    public partial class ListaAlumnos : ContentPage
    {
        public ListaAlumnos()
        {
            InitializeComponent();
            BindingContext = new ListaAlumnosViewModel();
        }

        private async void AlumnosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Alumnos selectedItem)
            {
                await Navigation.PushAsync(new EditarView(selectedItem));
            }
        }
    }
}