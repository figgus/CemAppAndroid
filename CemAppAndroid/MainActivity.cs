using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CemAppAndroid.Clases.ClasesModelo;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CemAppAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        Button btnUsuarios;
        private List<Usuario> lista;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            lista = JsonConvert.DeserializeObject<List<Usuario>>(Intent.GetStringExtra("Usuarios"));
            textMessage = FindViewById<TextView>(Resource.Id.message);
            btnUsuarios = FindViewById<Button>(Resource.Id.btnUsuarios);
            btnUsuarios.Click += BtnUsuarios_Click;
        }

        private void BtnUsuarios_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PanelUsuarios));
            intent.PutExtra("Usuarios", JsonConvert.SerializeObject(lista));
            StartActivity(intent);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }
    }
}

