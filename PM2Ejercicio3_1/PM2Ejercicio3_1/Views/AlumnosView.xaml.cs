﻿using Firebase.Storage;
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

      //  private string photoPath;
        private MediaFile photo;
        private string filePath;
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
            try
            {
              /*  var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // Guardar la foto localmente
                    var fileName = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid()}.jpg");
                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(fileName))
                        await stream.CopyToAsync(newStream);

                    await DisplayAlert("Foto tomada", "La foto ha sido tomada y guardada localmente.", "OK");
                }*/

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

                    ImagenPreview.Source = ImageSource.FromFile(filePath);

                }
                var stream = photo.GetStream();

                
                lbRutaImagenFile.Text = await TomarFoto(stream, photo.OriginalFilename);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }


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