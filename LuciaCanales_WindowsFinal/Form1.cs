using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LuciaCanales_WindowsFinal
{
    public partial class Form1 : Form
    {

        string nombre, apellido, puesto;
        double sueldo;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            sueldo = Convert.ToDouble(txtSueldo.Text);
            puesto = txtPuesto.Text;
            if (!validarSueldo(sueldo) || !validarPuesto(puesto) || !validarTexto(nombre) || !validarTexto(apellido))
            {
                MessageBox.Show("Datos ingresados incorrectos", "Aviso");
            }
            else
                MessageBox.Show("Datos correctos. Bienvenido", "Aviso de bienvenida");
        }
         private void btnMostrar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            puesto = txtPuesto.Text;
            imprimir(nombre, apellido, puesto);
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            int cantDiasLaborables = 5, suma = 0, cantPorDia;
            double promedio;
            string diasCortos = "";

            for (int i = 0; i < cantDiasLaborables; i++)
            {
                cantPorDia = CantHorasDiarias(i);
                suma += cantPorDia;
                diasCortos += mediaJornada(cantPorDia, i) + " ";
            }
            promedio = promedioHoras(suma, cantDiasLaborables);
            MessageBox.Show("Total de horas trabajadas en la semana: " + suma + "hs. \nPromedio: " + promedio + "hs por dia.\nDias menores a Media Jornada (<4hs): " + diasCortos, "Horas de trabajo semanales");

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TextBox nombre = txtNombre;
            TextBox apellido = txtApellido;
            TextBox sueldo = txtSueldo;
            TextBox puesto = txtPuesto;

            clearBox(nombre);
            clearBox(apellido);
            clearBox(sueldo);
            clearBox(puesto);

        }

        #region Mis Métodos
        bool validarSueldo (double sueldo)
        {
            if (sueldo > 0)
                return true;
            else
                return false;
        }

        bool validarPuesto (string puesto)
        {
            if (puesto.ToUpper().Equals("SOPORTE TECNICO") || puesto.ToUpper().Equals("DBA") || puesto.ToUpper().Equals("DESARROLLADOR"))
                return true;
            else
                return false;
        }

        bool validarTexto (string nombreOApellido)
        {
            if (nombreOApellido.Length > 2 && nombreOApellido.Length < 50)
                return true;
            else
                return false;
        }

        void imprimir(string nombre, string apellido, string puesto)
        {
            string text = nombre.ToUpper() + " " + apellido.ToUpper() + ": " + puesto.ToUpper();
            MessageBox.Show(text, "Datos personales");
        }

        int CantHorasDiarias (int nroDia)
        {
            string dia = "Ingrese cantidad de horas trabajadas el dia" + diaDeLaSemana(nroDia);
            return Convert.ToInt32(Interaction.InputBox(dia));
        }
        
        string diaDeLaSemana (int nroDia)
        {
            string dia = "";
            switch (nroDia)
            {
                case 0: dia = "Lunes";
                    break;
                case 1: dia = "Martes";
                    break;
                case 2: dia = "Miercoles";
                    break;
                case 3: dia = "Jueves";
                    break;
                case 4: dia = "Viernes";
                    break;
            }
            return dia;
        }
       
        double promedioHoras (int suma, int cantDias)
        {
            return suma / cantDias;
        }

        string mediaJornada (int cantDelDia, int nroDia)
        {
            string dia = "";
            if (cantDelDia < 4)
               dia = diaDeLaSemana(nroDia);
            return dia;
        }
        void clearBox (TextBox boxText)
        {
            boxText.Clear();
        }
        #endregion


    }
}
