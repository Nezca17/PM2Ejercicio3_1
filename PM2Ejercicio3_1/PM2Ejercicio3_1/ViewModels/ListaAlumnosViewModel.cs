using GalaSoft.MvvmLight.Command;
using PM2Ejercicio3_1.Models;
using PM2Ejercicio3_1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PM2Ejercicio3_1.ViewModels
{
    public class ListaAlumnosViewModel :BaseViewModel
    {
        FirebaseHelper _firebaseHelper = new FirebaseHelper();

        public ListaAlumnosViewModel()
        {
            LoadData();

        }

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
                    RutaImagenFile = "prueba"

                };


                await _firebaseHelper.AddAlumnos(alumno);


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"{ex}", "Ok");
            }

        }

        public async Task<ObservableCollection<Alumnos>> LoadData()
        {


            this.IsRefreshing = true;
            var alumnos = await _firebaseHelper.GetAlumnos();
            ListViewSource = new ObservableCollection<Alumnos>(alumnos);
            this.IsRefreshing = false;
            return ListViewSource;
        }

        #endregion
    }
}
