using GalaSoft.MvvmLight.Command;
using PM2Ejercicio3_1.Models;
using PM2Ejercicio3_1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM2Ejercicio3_1.ViewModels
{
    public class AlumnosViewModel : BaseViewModel
    {
        FirebaseHelper _firebaseHelper = new FirebaseHelper();

        public AlumnosViewModel()
        {


        }

        #region Attributes
        private Guid _Id;
        private string _Nombres;
        private string _Apellidos;
        private string _Sexo;
        private string _Direccion;
        private string _RutaImagenFile;
        private Uri _RutaImagenFileUri;

        #endregion

        #region Properties
        public Guid Id
        {
            get { return _Id; }

        }

        public string Nombres
        {
            get { return _Nombres; }
            set { SetValue(ref _Nombres, value); }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { SetValue(ref _Apellidos, value); }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { SetValue(ref _Sexo, value); }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { SetValue(ref _Direccion, value); }
        }
        public string RutaImagenFile
        {
            get { return _RutaImagenFile; }
            set { SetValue(ref _RutaImagenFile, value); }
        }
        public Uri RutaImagenFileUri
        {
            get { return _RutaImagenFileUri; }
            set { SetValue(ref _RutaImagenFileUri, value); }
        }
        #endregion

        #region Commands
        public ICommand insertCommand
        {
            get
            {
                return new RelayCommand(InsertMethod);

            }

        }

        #endregion

        #region Methods

        public async void InsertMethod()
        {
            try
            {
                var alumno = new Alumnos
                {
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Sexo = Sexo,
                    Direccion = Direccion,
                    RutaImagenFile = RutaImagenFile

                };


                await _firebaseHelper.AddAlumnos(alumno);
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error",$"{ex}","Ok");
            }

        }

        #endregion
    }
}
