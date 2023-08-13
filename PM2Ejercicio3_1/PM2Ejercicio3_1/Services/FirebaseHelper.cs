using Firebase.Database;
using PM2Ejercicio3_1.Models;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;

using Firebase.Database.Query;


namespace PM2Ejercicio3_1.Services
{
    public class FirebaseHelper
    {

        FirebaseClient firebase;

      //  FechaConverter fechaConver;

        public FirebaseHelper()
        {

            firebase = new FirebaseClient("https://pm2ejercicio3android-default-rtdb.firebaseio.com/");
         //   fechaConver = new FechaConverter();
        }

        public async Task<List<Alumnos>> GetAlumnos()
        {
            var queryResult = await firebase
             .Child("Alumnos")
             .OnceAsync<Alumnos>();

            var Alumnos = queryResult
                .Select(item => new Alumnos
                {
                    Id = item.Object.Id,
                    Nombres = item.Object.Nombres,
                    Apellidos = item.Object.Apellidos,
                    Sexo = item.Object.Sexo,
                    Direccion= item.Object.Direccion,
                    RutaImagenFile = item.Object.RutaImagenFile,
                    RutaImagenFileUri = new Uri(item.Object.RutaImagenFile)
                })
                .ToList();

            return Alumnos;

        }

        public async Task AddAlumnos(Alumnos _alumnos)
        {
            await firebase.Child("Alumnos").PostAsync(new Alumnos()
            {

                Id = Guid.NewGuid(),
                Nombres = _alumnos.Nombres,
                Apellidos = _alumnos.Apellidos,
                Sexo = _alumnos.Sexo,
                Direccion = _alumnos.Direccion,
                RutaImagenFile = _alumnos.RutaImagenFile,
                RutaImagenFileUri = _alumnos.RutaImagenFileUri

            });

        }

        public async Task UpdateAlumno(Alumnos _alumnos)
        {

            var toUpdateNota = (await firebase.Child("Alumnos")
                .OnceAsync<Alumnos>()).Where(a => a.Object.Id == _alumnos.Id).FirstOrDefault();

            await firebase.Child("Alumnos")
                .Child(toUpdateNota.Key)
                .PutAsync(new Alumnos()
                {
                    Id = _alumnos.Id,
                    Nombres = _alumnos.Nombres,
                    Apellidos = _alumnos.Apellidos,
                    Sexo = _alumnos.Sexo,
                    Direccion = _alumnos.Direccion,
                    RutaImagenFile = _alumnos.RutaImagenFile,
                    RutaImagenFileUri = _alumnos.RutaImagenFileUri
                });


        }

        public async Task DeleteNota(Guid IdAlumno)
        {
            var toDeleteNota = (await firebase.Child("Alumnos").OnceAsync<Alumnos>()).Where(a => a.Object.Id == IdAlumno).FirstOrDefault();

            await firebase.Child("Alumnos").Child(toDeleteNota.Key).DeleteAsync();

        }


    }
}
