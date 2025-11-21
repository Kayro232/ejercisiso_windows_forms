using System;
using System.Linq;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
        private int[] lista; 

        public Form1()
        {
            InitializeComponent();

     
            TextBox txtNumeroBuscar = new TextBox() { Top = 20, Left = 20, Width = 200 };
            Button btnBuscar = new Button() { Top = 60, Left = 20, Text = "Buscar Número (Binaria)" };
            Label lblResultado = new Label() { Top = 100, Left = 20, Width = 500, Height = 200 };
            Label lblLista = new Label() { Top = 320, Left = 20, Width = 600, Height = 60 };

            this.Controls.Add(txtNumeroBuscar);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(lblResultado);
            this.Controls.Add(lblLista);

         
            Random rnd = new Random();
            lista = new int[30];
            for (int i = 0; i < lista.Length; i++)
                lista[i] = rnd.Next(1, 101);

       
            Array.Sort(lista);

        
            lblLista.Text = "Lista ordenada: " + string.Join(", ", lista);

            // Evento click
            btnBuscar.Click += (s, e) =>
            {
                try
                {
                    int numero = int.Parse(txtNumeroBuscar.Text.Trim());
                    string proceso = "";
                    int posicion = BusquedaBinaria(lista, numero, ref proceso);

                    lblResultado.Text = proceso + "\n";

                    if (posicion != -1)
                        lblResultado.Text += $"Número encontrado en la posición: {posicion}";
                    else
                        lblResultado.Text += "Número no encontrado en la lista";
                }
                catch
                {
                    lblResultado.Text = "Error: ingresa un número válido";
                }
            };
        }

        private int BusquedaBinaria(int[] arr, int num, ref string proceso)
        {
            int izquierda = 0;
            int derecha = arr.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                proceso += $"Revisando sublista [{izquierda}..{derecha}], mitad: {medio}, valor: {arr[medio]}\n";

                if (arr[medio] == num)
                    return medio; // Encontrado
                else if (arr[medio] < num)
                    izquierda = medio + 1; 
                else
                    derecha = medio - 1; 
            }

            return -1; 
        }
    }
}

