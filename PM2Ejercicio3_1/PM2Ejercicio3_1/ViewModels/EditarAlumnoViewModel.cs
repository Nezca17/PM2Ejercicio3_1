using GalaSoft.MvvmLight.Command;
using PM2Ejercicio3_1.Models;
using PM2Ejercicio3_1.Services;
using PM2Ejercicio3_1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace PM2Ejercicio3_1.ViewModels
{
    public class EditarAlumnoViewModel : BaseViewModel
    {

        FirebaseHelper _firebaseHelper = new FirebaseHelper();
        #region Attributes
        public Guid _Id;
        public string _Nombres;
        public string _Apellidos;
        public string _Sexo;
        public string _Direccion;
        public string _RutaImagenFile;
        public Uri _RutaImagenFileUri;
        public bool isRefreshing = false;
        public ObservableCollection<Alumnos> listViewSource1;
        #endregion

        #region Properties
        public Guid Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }

        }
        public ObservableCollection<Alumnos> ListViewSource
        {
            get { return this.listViewSource1; }
            set
            {
                SetValue(ref this.listViewSource1, value);
            }

        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref isRefreshing, value); }
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
        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(UpdateMethod);

            }

        }
        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteMethod);

            }

        }


        private async void UpdateMethod()
        {
            try
            {
              
                var Alumno = new Alumnos
                {
                    Id = Id,
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Sexo = Sexo,
                    Direccion = Direccion,
                    RutaImagenFile = RutaImagenFile
                };
                await _firebaseHelper.UpdateAlumno(Alumno);


                await App.Current.MainPage.DisplayAlert("aviso","Actualizado","ok");
                await App.Current.MainPage.Navigation.PushAsync(new ListaAlumnos());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"************************************{ex}");

            }

        }

        private async void DeleteMethod()
        {

            await _firebaseHelper.DeleteNota(Id);

            await App.Current.MainPage.DisplayAlert("aviso", "Eliminado", "ok");
            await App.Current.MainPage.Navigation.PushAsync(new ListaAlumnos());
        }

        #endregion

        #region Constructor
        public EditarAlumnoViewModel(Alumnos alumno)
        {
            Id = alumno.Id;
            Nombres = alumno.Nombres;
            Apellidos = alumno.Apellidos;
            Sexo = alumno.Sexo;
            Direccion = alumno.Direccion;
            RutaImagenFile = alumno.RutaImagenFile;

        }
        public EditarAlumnoViewModel()
        {

        }

        #endregion
    }
}
