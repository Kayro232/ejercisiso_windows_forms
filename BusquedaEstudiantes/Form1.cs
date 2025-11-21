using System;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            TextBox txtParrafo = new TextBox() { Top = 20, Left = 20, Width = 400, Height = 80, Multiline = true, Text = "Escribe aquí un párrafo para buscar palabras." };
            TextBox txtPalabra = new TextBox() { Top = 110, Left = 20, Width = 200 };
            Button btnBuscar = new Button() { Top = 150, Left = 20, Text = "Buscar palabra" };
            Label lblResultado = new Label() { Top = 190, Left = 20, Width = 400, Height = 60 };

            this.Controls.Add(txtParrafo);
            this.Controls.Add(txtPalabra);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(lblResultado);

            btnBuscar.Click += (s, e) =>
            {
                string parrafo = txtParrafo.Text;
                string palabra = txtPalabra.Text;

                if (string.IsNullOrWhiteSpace(parrafo) || string.IsNullOrWhiteSpace(palabra))
                {
                    lblResultado.Text = "Ingresa un párrafo y una palabra válidos.";
                    return;
                }

                int cantidad = ContarPalabra(parrafo, palabra);
                lblResultado.Text = $"La palabra '{palabra}' aparece {cantidad} veces en el párrafo.";
            };
        }


        private int ContarPalabra(string parrafo, string palabra)
        {
            parrafo = parrafo.ToLower();
            palabra = palabra.ToLower();
            int contador = 0;

            for (int i = 0; i <= parrafo.Length - palabra.Length; i++)
            {
                bool coincide = true;
                for (int j = 0; j < palabra.Length; j++)
                {
                    if (parrafo[i + j] != palabra[j])
                    {
                        coincide = false;
                        break;
                    }
                }
                if (coincide) contador++;
            }

            return contador;
        }
    }
}

