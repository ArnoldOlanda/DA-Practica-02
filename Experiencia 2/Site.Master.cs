using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConversorDeTemperaturas
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                //Temperaturas.Items.Add("Centigrados");
                //Temperaturas.Items.Add("Fahrenheit");
                //Temperaturas.Items.Add("Kelvin");

                //Se asigna a cada elemento de la lista un Texto y su respectivo indice
                Temperaturas.Items.Add(new ListItem("Centigrados", "1"));
                Temperaturas.Items.Add(new ListItem("Fahrenheit", "2"));
                Temperaturas.Items.Add(new ListItem("Kelvin", "3"));

            }

        }
        protected void Convertir_ServerClick(Object sender, EventArgs e)
        {
            //decimal Fahrenheit = decimal.Parse(valor.Value);
            //decimal Centigrados = (Fahrenheit - 32) / (decimal)1.8;
            //Resultado.InnerText = Fahrenheit.ToString() + "° Fahrenheit = ";
            //Resultado.InnerText += Centigrados.ToString() + "° Centigrados";

            decimal Fahrenheit = decimal.Parse(valor.Value);
            decimal conversion = 0;
            //Obtenemos el indice seleccionado en el dropdownlist
            ListItem elemento = Temperaturas.Items[Temperaturas.SelectedIndex];
            if (elemento.Value == "1")
            {

                conversion = (Fahrenheit - 32) / (decimal)1.8;//Formula de conversion de F° a C°
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += conversion.ToString() + " Centigrados";
            }
            if (elemento.Value == "2")
            {
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += Fahrenheit.ToString() + " Fahrenheit";
            }
            if (elemento.Value == "3")
            {
                conversion = ((Fahrenheit - 32) / (decimal)1.8) + (decimal)273.15;//Formula de conversion de F° a K°
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += conversion.ToString() + " " + elemento.Text;
            }



        }
        protected void MostrarGrafico_ServerClick(Object sender, EventArgs e)
        {

        }

    }
}