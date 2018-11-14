using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CemAppAndroid.Clases;
using CemAppAndroid.Clases.ClasesModelo;
using Newtonsoft.Json;

namespace CemAppAndroid
{
    [Activity(Label = "Login", MainLauncher =true)]
    public class Login : Activity
    {
        Button Ingresar;
        ProgressBar barra;
        EditText txtUsername;
        EditText txtPass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Loginlayout1);
            // Create your application here
            Ingresar=FindViewById<Button>(Resource.Id.btnIngresar);
            barra= FindViewById<ProgressBar>(Resource.Id.barra);
            txtUsername= FindViewById<EditText>(Resource.Id.txtUsername);
            txtPass= FindViewById<EditText>(Resource.Id.txtPassword);
            Ingresar.Click += Ingresar_Click;
        }

        private void Ingresar_Click(object sender, EventArgs e)
        {
            barra.Visibility = ViewStates.Visible;
            Ingresar.Enabled = false;
           
            this.InciarSesion();
        }

        public async void InciarSesion()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios");

            List<Usuario> datos = JsonConvert.DeserializeObject<List<Usuario>>(response);
            bool res = false;
            foreach (Usuario user in datos)
            {
                if (user.username == txtUsername.Text && user.password == txtPass.Text)
                {
                    res = true;
                }
            }
            if (res)
            {
                Intent intent = new Intent(this, typeof(PanelUsuarios));
                intent.PutExtra("Usuarios", JsonConvert.SerializeObject(datos));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Credenciales invalidas", ToastLength.Short).Show();
                Ingresar.Enabled = true;
                barra.Visibility = ViewStates.Invisible;
            }


        }
    }
}



