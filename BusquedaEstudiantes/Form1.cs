using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
     
        private TextBox txtID;
        private Button btnBuscarID;
        private TextBox txtNombre;
        private Button btnBuscarNombre;
        private ListBox listBoxResultado;

  
        public class Estudiante
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return $"{Id} - {Nombre}";
            }
        }


        List<Estudiante> estudiantes;

        public Form1()
        {
            InitializeComponent();
            CrearControles(); 

            // Inicializar la lista de estudiantes aquí
            estudiantes = new List<Estudiante>()
            {
                new Estudiante {Id = 1, Nombre="Ana"},
                new Estudiante {Id = 2, Nombre="Brenda"},
                new Estudiante {Id = 3, Nombre="Carlos"},
                new Estudiante {Id = 4, Nombre="Daniel"},
                new Estudiante {Id = 5, Nombre="Elena"},
                new Estudiante {Id = 6, Nombre="Fernanda"},
                new Estudiante {Id = 7, Nombre="Gabriel"},
                new Estudiante {Id = 8, Nombre="Hector"},
                new Estudiante {Id = 9, Nombre="Isabel"},
                new Estudiante {Id = 10, Nombre="Juan"}
            };

            ActualizarLista();
        }


        void CrearControles()
        {

            Label lblID = new Label();
            lblID.Text = "Buscar por ID:";
            lblID.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(lblID);

   
            txtID = new TextBox();
            txtID.Location = new System.Drawing.Point(20, 45);
            txtID.Width = 120;
            this.Controls.Add(txtID);

   
            btnBuscarID = new Button();
            btnBuscarID.Text = "Buscar ID";
            btnBuscarID.Location = new System.Drawing.Point(150, 43);
            btnBuscarID.Click += btnBuscarID_Click;
            this.Controls.Add(btnBuscarID);

            // ----- Label Nombre -----
            Label lblNombre = new Label();
            lblNombre.Text = "Buscar por Nombre:";
            lblNombre.Location = new System.Drawing.Point(20, 90);
            this.Controls.Add(lblNombre);

     
            txtNombre = new TextBox();
            txtNombre.Location = new System.Drawing.Point(20, 115);
            txtNombre.Width = 120;
            this.Controls.Add(txtNombre);

        
            btnBuscarNombre = new Button();
            btnBuscarNombre.Text = "Buscar Nombre";
            btnBuscarNombre.Location = new System.Drawing.Point(150, 113);
            btnBuscarNombre.Click += btnBuscarNombre_Click;
            this.Controls.Add(btnBuscarNombre);

         
            listBoxResultado = new ListBox();
            listBoxResultado.Location = new System.Drawing.Point(20, 160);
            listBoxResultado.Size = new System.Drawing.Size(260, 200);
            this.Controls.Add(listBoxResultado);
        }


        void ActualizarLista()
        {
            listBoxResultado.Items.Clear();
            foreach (var est in estudiantes)
                listBoxResultado.Items.Add(est);
        }


        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int idBuscado))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            Estudiante encontrado = null;

            foreach (var est in estudiantes)
            {
                if (est.Id == idBuscado)
                {
                    encontrado = est;
                    break;
                }
            }

            listBoxResultado.Items.Clear();
            listBoxResultado.Items.Add(encontrado != null
                ? "Encontrado: " + encontrado
                : "No existe estudiante con ese ID");
        }


        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            string nombreBuscado = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombreBuscado))
            {
                MessageBox.Show("Ingrese un nombre.");
                return;
            }

            // Normalizar nombres a mayúsculas para comparación
            string nombreBuscadoNorm = nombreBuscado.ToUpperInvariant();
            var listaOrdenada = estudiantes.OrderBy(x => x.Nombre.ToUpperInvariant()).ToList();

            int inicio = 0;
            int fin = listaOrdenada.Count - 1;
            Estudiante encontrado = null;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                string medioNombre = listaOrdenada[medio].Nombre.ToUpperInvariant();
                int comp = string.Compare(medioNombre, nombreBuscadoNorm, StringComparison.Ordinal);

                if (comp == 0)
                {
                    encontrado = listaOrdenada[medio];
                    break;
                }
                else if (comp < 0)
                    inicio = medio + 1;
                else
                    fin = medio - 1;
            }

            listBoxResultado.Items.Clear();
            listBoxResultado.Items.Add(encontrado != null
                ? "Encontrado: " + encontrado
                : "No existe estudiante con ese nombre");
        }
    }
}
