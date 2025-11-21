using System;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
        private int[] arreglo; 

        public Form1()
        {
            InitializeComponent();

      
            TextBox txtNumeroBuscar = new TextBox() { Top = 20, Left = 20, Width = 200 };
            Button btnBuscar = new Button() { Top = 60, Left = 20, Text = "Buscar Número" };
            Label lblResultado = new Label() { Top = 100, Left = 20, Width = 300, Height = 60 };
            Label lblArreglo = new Label() { Top = 180, Left = 20, Width = 400, Height = 60 };

            this.Controls.Add(txtNumeroBuscar);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(lblResultado);
            this.Controls.Add(lblArreglo);

            
            Random rnd = new Random();
            arreglo = new int[20];
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = rnd.Next(1, 101);
            }

           
            lblArreglo.Text = "Arreglo: " + string.Join(", ", arreglo);

 
            btnBuscar.Click += (s, e) =>
            {
                try
                {
                    int numero = int.Parse(txtNumeroBuscar.Text.Trim());
                    int posicion = BusquedaLineal(arreglo, numero);

                    if (posicion != -1)
                        lblResultado.Text = $"Número encontrado en la posición: {posicion}";
                    else
                        lblResultado.Text = "Número no encontrado en el arreglo";
                }
                catch
                {
                    lblResultado.Text = "Error: ingresa un número válido";
                }
            };
        }


        private int BusquedaLineal(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                    return i;
            }
            return -1; // Retorna -1 si no lo encuentra
        }
    }
}
