using System;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
        private int[,] matriz; // Matriz 10x10

        public Form1()
        {
            InitializeComponent();


            TextBox txtNumero = new TextBox() { Top = 20, Left = 20, Width = 200 };
            Button btnBuscar = new Button() { Top = 60, Left = 20, Text = "Buscar en Matriz" };
            Label lblResultado = new Label() { Top = 100, Left = 20, Width = 400, Height = 200 };
            Label lblMatriz = new Label() { Top = 320, Left = 20, Width = 500, Height = 200 };

            this.Controls.Add(txtNumero);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(lblResultado);
            this.Controls.Add(lblMatriz);

     
            Random rnd = new Random();
            matriz = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    matriz[i, j] = rnd.Next(1, 101);
                }
            }

  
            string textoMatriz = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    textoMatriz += matriz[i, j].ToString("D2") + " ";
                }
                textoMatriz += "\n";
            }
            lblMatriz.Text = textoMatriz;


            btnBuscar.Click += (s, e) =>
            {
                try
                {
                    int numero = int.Parse(txtNumero.Text.Trim());
                    var posiciones = BuscarEnMatriz(matriz, numero);

                    if (posiciones.Count > 0)
                    {
                        string resultado = $"Número {numero} encontrado en las posiciones:\n";
                        foreach (var pos in posiciones)
                            resultado += $"Fila {pos.Item1}, Columna {pos.Item2}\n";

                        lblResultado.Text = resultado;
                    }
                    else
                    {
                        lblResultado.Text = $"Número {numero} no encontrado en la matriz.";
                    }
                }
                catch
                {
                    lblResultado.Text = "Error: ingresa un número válido";
                }
            };
        }


        private System.Collections.Generic.List<(int, int)> BuscarEnMatriz(int[,] matriz, int numero)
        {
            var posiciones = new System.Collections.Generic.List<(int, int)>();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == numero)
                        posiciones.Add((i, j));
                }
            }

            return posiciones;
        }
    }
}

