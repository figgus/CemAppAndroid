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
        public UsuariosApi()
        {

        }

        public async Task<List<Usuario>> TraerTodo()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);

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
    }
}