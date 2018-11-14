using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CemAppAndroid.Clases.ClasesModelo;
using Newtonsoft.Json;

namespace CemAppAndroid
{
    [Activity(Label = "PanelUsuarios")]
    public class PanelUsuarios : Activity
    {
      //  private string[] listaUsuarios;
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;
        private List<Usuario> lista;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layoutPanelUsuarios);
            lista= JsonConvert.DeserializeObject<List<Usuario>>(Intent.GetStringExtra("Usuarios"));
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new RecyclerAdapter(lista);
            mRecyclerView.SetAdapter(mAdapter);
        }


        private class RecyclerAdapter : RecyclerView.Adapter
        {
            private List<Usuario> lista;

            public RecyclerAdapter(List<Usuario> lista)
            {
                this.lista = lista;
            }

            public class MyView : RecyclerView.ViewHolder
            {
                public View mMainView { get; set; }
                public TextView txtUsername { get; set; }
                public TextView txtPassword { get; set; }
                public TextView txtEmail { get; set; }
                public TextView txtCelular { get; set; }

                public MyView(View view) : base(view)
                {
                    mMainView = view;
                }
            }

            

            public override int ItemCount { get { return lista.Count; } }
            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                MyView myHolder = holder as MyView;
                myHolder.txtUsername.Text = myHolder.txtUsername.Text + lista[position].username;
                myHolder.txtPassword.Text = myHolder.txtPassword.Text + lista[position].password;
                myHolder.txtEmail.Text = myHolder.txtEmail.Text + lista[position].email;
                myHolder.txtCelular.Text = myHolder.txtCelular.Text + lista[position].fonoCelular;
            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row,parent,false);
                TextView txtUsername = row.FindViewById<TextView>(Resource.Id.txtUsername);
                TextView txtPassword = row.FindViewById<TextView>(Resource.Id.txtPassword);
                TextView txtEmail = row.FindViewById<TextView>(Resource.Id.txtEmail);
                TextView txtCelular = row.FindViewById<TextView>(Resource.Id.txtCelular);
                MyView view = new MyView(row) { txtUsername=txtUsername,txtPassword=txtPassword,txtEmail=txtEmail,txtCelular=txtCelular };
                return view;

            }
        }


    }
}

