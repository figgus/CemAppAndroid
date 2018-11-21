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
using CemAppAndroid.Clases;
using CemAppAndroid.Clases.ClasesModelo;
using Newtonsoft.Json;

namespace CemAppAndroid
{
    [Activity(Label = "DetallesUsuario")]
    public class DetallesUsuario : Activity
    {
        private EditText txtIdUsuario;
        private EditText txtUsername;
        private EditText txtPassword;
        private EditText txtPnombre;
        private EditText txtSnombre;
        private EditText txtAppat;
        private EditText txtApmat;
        private EditText txtEmail;
        private EditText txtFonoCelular;
        private EditText txtFonoFijo;
        private EditText txtTipoUsuario;
        private EditText txtAlumnoRegular;
        private EditText txtIdCarrera;
        private EditText txtIdInstitucion;

        private Usuario user;//no inicializa
        private Button btnEliminar;
        private Button btnActualizar;
        int IDuser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetallesUsuariosLayout);
            // Create your application here
            btnEliminar= FindViewById<Button>(Resource.Id.btnEliminar);
            btnActualizar= FindViewById<Button>(Resource.Id.btnActualizar);
            btnEliminar.Click += BtnEliminar_Click;
            IDuser = Intent.GetIntExtra("UserSelected", 0);
            txtIdUsuario = FindViewById<EditText>(Resource.Id.txtIdUsuario);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtPnombre = FindViewById<EditText>(Resource.Id.txtPnombre);
            txtSnombre = FindViewById<EditText>(Resource.Id.txtSnombre);
            txtAppat = FindViewById<EditText>(Resource.Id.txtAppat);
            txtApmat = FindViewById<EditText>(Resource.Id.txtApmat);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtFonoCelular = FindViewById<EditText>(Resource.Id.FonoCelular);
            txtFonoFijo = FindViewById<EditText>(Resource.Id.txtFonoFijo);
            txtTipoUsuario = FindViewById<EditText>(Resource.Id.txtTipoUsuario);
            txtAlumnoRegular = FindViewById<EditText>(Resource.Id.txtAlumnoRegular);
            txtIdCarrera = FindViewById<EditText>(Resource.Id.txtIdCarrera);
            txtIdInstitucion = FindViewById<EditText>(Resource.Id.txtIdInstitucion);
            TraerDatosUsuario(IDuser);
            btnActualizar.Click += BtnActualizar_Click;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.ActualizarUsuario();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmacion");
            alert.SetMessage("¿Esta seguro que desea eliminar este usuario?");
            alert.SetPositiveButton("Borrar", (senderAlert, args) => {
                borrar();
            });

            alert.SetNegativeButton("Cancelar", (senderAlert, args) => {
                Toast.MakeText(this, "Cancelado!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public async void borrar()
        {
            UsuariosApi api = new UsuariosApi();
            Usuario usu = this.TraerListaUsuariosLocal().FirstOrDefault(p => p.idUsuario == IDuser);
            await api.EliminarUsuario(usu);

            Intent intent = new Intent(this, typeof(PanelUsuarios));
            StartActivity(intent);
        }

        public List<Usuario> TraerListaUsuariosLocal()
        {
            var users = Application.Context.GetSharedPreferences("Usuarios", FileCreationMode.Private);
            string json = users.GetString("ListaUsuarios", "vacio");
            var editarUsers = JsonConvert.DeserializeObject<List<Usuario>>(users.GetString("ListaUsuarios", "vacio"));
            return editarUsers.ToList();
        }


        private async void TraerDatosUsuario(int idUser)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://restapicem.somee.com/api/usuarios/"+idUser);

            user= JsonConvert.DeserializeObject<Usuario>(response);
            txtIdUsuario.Text = user.idUsuario.ToString();
            txtUsername.Text = user.username;
            txtPassword.Text = user.password;
            txtPnombre.Text = user.pnombre;
            txtSnombre.Text = user.snombre;
            txtAppat.Text = user.appat;
            txtApmat.Text = user.apmat;
            txtEmail.Text = user.email;
            txtFonoCelular.Text = user.fonoCelular;
            txtFonoFijo.Text = user.fonoFijo;
            txtTipoUsuario.Text = user.tipoUsuario.ToString();
            txtAlumnoRegular.Text = user.alumnoRegular.ToString();
            txtIdCarrera.Text = user.idCarrera.ToString();
            txtIdInstitucion.Text = user.idInstitucion.ToString();
        }


        private async void ActualizarUsuario()
        {
            UsuariosApi api = new UsuariosApi();
            Usuario userEdit = new Usuario();
            userEdit.idUsuario= int.Parse(txtIdUsuario.Text);
            userEdit.username = txtUsername.Text;
            userEdit.password = txtPassword.Text;
            userEdit.pnombre = txtPnombre.Text;
            userEdit.snombre = txtSnombre.Text;
            userEdit.appat = txtAppat.Text;
            userEdit.apmat = txtApmat.Text;
            userEdit.email = txtEmail.Text;
            userEdit.fonoCelular = txtFonoCelular.Text;
            userEdit.fonoFijo = txtFonoFijo.Text;
            userEdit.tipoUsuario = int.Parse( txtTipoUsuario.Text);
            userEdit.alumnoRegular = int.Parse( txtAlumnoRegular.Text);
            userEdit.idCarrera = int.Parse(txtIdCarrera.Text);
            userEdit.idInstitucion = int.Parse(txtIdInstitucion.Text);
            Task<bool> tarea = api.EditarUsuario(userEdit);
            await Task.WhenAll(tarea);
            if (tarea.Result)
            {
                Toast.MakeText(this, "¡Editado con exito!", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "¡Error al editar!", ToastLength.Short).Show();
            }
        }
    }
}