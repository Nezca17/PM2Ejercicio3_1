using Firebase.Storage;
using Plugin.Media.Abstractions;
using Plugin.Media;
using PM2Ejercicio3_1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        private string photoPath;
     //   private MediaFile photo;
        public AlumnosView()
        {
            InitializeComponent();
            BindingContext = new AlumnosViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        private async void SeleccionarImagen_ClickedAsync(object sender, EventArgs e)
        {

            /*
            try
            {
                btnGuardar.IsEnabled = false;
                // Verificar si se otorgó el permiso de cámara
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Error", "La cámara no está disponible.", "OK");
                    return;
                }

                // Solicitar permisos para acceder a la cámara
                var status = await CrossMedia.Current.Initialize();
                if (!status)
                {
                    await DisplayAlert("Permiso denegado", "No se ha otorgado el permiso para acceder a la cámara.", "OK");
                    return;
                }

                // Tomar una foto
                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "CapturedPhotos",
                    Name = "capturedImage.jpg",
                    SaveToAlbum = true // Guardar la foto en el álbum de fotos del dispositivo (opcional)
                });

                if (photo != null)
                {
                    // Obtener la ruta de la foto capturada
                    filePath = photo.Path;

                    imageField.Source = ImageSource.FromFile(filePath);

                }
                var stream = photo.GetStream();

                //  NotasViewModel.StreamFoto = stream;
                lbRutaFirebase.Text = await TomarFoto(stream, photo.OriginalFilename);
                btnGuardar.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                await DisplayAlert("Error", $"Ha ocurrido un error: {ex.Message}", "OK");
            }

            */

        }
        private void btnVerLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaAlumnos());
        }
        public async Task<string> TomarFoto(Stream fotoFile, string nombre)
        {
            try
            {

                var photo = fotoFile;

                if (photo != null)
                {
                    var task = new FirebaseStorage("pm2ejercicio3android.appspot.com", new FirebaseStorageOptions
                    {

                        ThrowOnCancel = true

                    }).Child("Alumnos")
                    .Child(NombresEntry.Text)
                    .Child(nombre)
                    .PutAsync(photo);

                    task.Progress.ProgressChanged += (s, args) =>
                    {
                        progressBar.Progress = args.Percentage;
                    };

                    var dowloadlink = await task;

                    return dowloadlink;
                }
                else
                {
                    return "No se envio";
                }



            }
            catch (Exception e)
            {


                await App.Current.MainPage.DisplayAlert("Aviso", $"{e}", "Ok");
                return "N/A";
            }
        }
    }
}