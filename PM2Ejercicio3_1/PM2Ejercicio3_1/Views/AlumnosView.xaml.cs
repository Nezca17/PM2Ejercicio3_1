using PM2Ejercicio3_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2Ejercicio3_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlumnosView : ContentPage
    {
        public AlumnosView()
        private string photoPath;
        public Alumnos()
        {
            InitializeComponent();
            BindingContext = new AlumnosViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        private async void SeleccionarImagen_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    photoPath = photo.FullPath;
                    ImagenPreview.Source = ImageSource.FromStream(() => photo.OpenReadAsync().Result);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo tomar la foto: {ex.Message}", "OK");
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