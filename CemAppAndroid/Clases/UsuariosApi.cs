using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CemAppAndroid.Clases.ClasesModelo;
using Newtonsoft.Json;

namespace CemAppAndroid.Clases
{
    class UsuariosApi
    {
        public  List<Usuario> listaUsuarios;
        public UsuariosApi()
        {
            
        }

        public async Task<List<Usuario>> TraerTodo()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");
            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            listaUsuarios = datos;
            return datos;
        }

        public bool ExisteUsuario(string name,string password)
        {
            foreach (Usuario user in this.TraerTodo().Result)
            {
                if (user.username==name && user.password==password)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> EliminarUsuario(Usuario userBorrar)
        {
            var json = JsonConvert.SerializeObject(userBorrar);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string url = string.Concat("http://restapicem.somee.com/api/usuarios/", userBorrar.idUsuario);
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public async Task<bool> EditarUsuario(Usuario userUpdate)
        {
            var json = JsonConvert.SerializeObject(userUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string urlServicio = string.Concat("http://restapicem.somee.com/api/usuarios/", userUpdate.idUsuario);
            var response = await client.PutAsync(string.Concat("http://restapicem.somee.com/api/usuarios/", userUpdate.idUsuario), content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}