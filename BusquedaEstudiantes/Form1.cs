using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BusquedaEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            TextBox txtNumeros = new TextBox() { Top = 20, Left = 20, Width = 200 };
            Button btnBuscar = new Button() { Top = 60, Left = 20, Text = "Buscar Máx/Min" };
            Label lblResultado = new Label() { Top = 100, Left = 20, Width = 300, Height = 60 };

            this.Controls.Add(txtNumeros);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(lblResultado);


            btnBuscar.Click += (s, e) =>
            {
                try
                {

                    List<int> numeros = txtNumeros.Text.Split(',')
                                                      .Select(n => int.Parse(n.Trim()))
                                                      .ToList();

                    var resultado = BuscarMaxMin(numeros);


                    lblResultado.Text = $"Máximo: {resultado.max}\nMínimo: {resultado.min}\nIteraciones: {resultado.iteraciones}";
                }
                catch
                {
                    lblResultado.Text = "Error: ingresa números válidos separados por comas";
                }
            };
        }


        private (int max, int min, int iteraciones) BuscarMaxMin(List<int> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new ArgumentException("La lista no puede estar vacía");

            int max = lista[0];
            int min = lista[0];
            int iteraciones = 0;

            foreach (int num in lista)
            {
                iteraciones++;
                if (num > max) max = num;
                if (num < min) min = num;
            }

            return (max, min, iteraciones);
        }
    }
}
