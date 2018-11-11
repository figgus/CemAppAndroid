using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CemAppAndroid.Clases.ClasesModelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string pnombre { get; set; }
        public string snombre { get; set; }
        public string appat { get; set; }
        public string apmat { get; set; }
        public string email { get; set; }
        public string fonoCelular { get; set; }
        public string fonoFijo { get; set; }
        public Nullable<int> tipoUsuario { get; set; }
        public Nullable<int> alumnoRegular { get; set; }
        public int idCarrera { get; set; }
        public int idInstitucion { get; set; }
        
    }
}