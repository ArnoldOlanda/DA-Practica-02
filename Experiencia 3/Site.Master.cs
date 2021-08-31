using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConversorDeTemperturas
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                Temperaturas.Items.Add(new ListItem("Centigrados", "1"));
                Temperaturas.Items.Add(new ListItem("Fahrenheit", "2"));
                Temperaturas.Items.Add(new ListItem("Kelvin", "3"));
            }
            Grafico.Visible = false;
        }
        protected void Convertir_ServerClick(Object sender, EventArgs e)
        {
            decimal Fahrenheit = decimal.Parse(valor.Value);
            decimal conversion = 0;
            ListItem elemento = Temperaturas.Items[Temperaturas.SelectedIndex];
            if (elemento.Value == "1")
            {
                conversion = (Fahrenheit - 32) / (decimal)1.8;
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += conversion.ToString() + " Centigrados";
                if (Fahrenheit < 0)
                {
                    Resultado.Style["color"] = "Red";
                    Resultado.InnerText += " Ingreso una temperatura menor a cero";
                }
                else
                {
                    Resultado.Style["color"] = "Blue";
                }
            }
            if (elemento.Value == "2")
            {
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += Fahrenheit.ToString() + " Fahrenheit";
                if (Fahrenheit < 0)
                {
                    Resultado.Style["color"] = "Red";
                    Resultado.InnerText += " Ingreso una temperatura menor a cero";
                }
                else
                {
                    Resultado.Style["color"] = "Blue";
                }
            }
            if (elemento.Value == "3")
            {
                conversion = ((Fahrenheit - 32) / (decimal)1.8) + (decimal)273.15;
                Resultado.InnerText = Fahrenheit.ToString() + " Fahrenheit = ";
                Resultado.InnerText += conversion.ToString() + " " + elemento.Text;
                if (Fahrenheit < 0)
                {
                    Resultado.Style["color"] = "Red";
                    Resultado.InnerText += " Ingreso una temperatura menor a cero";
                }
                else
                {
                    Resultado.Style["color"] = "Blue";
                }
            }
        }
        protected void MostrarGrafico_ServerClick(Object sender, EventArgs e)
        {
            Grafico.Src = "figura" + Temperaturas.SelectedIndex.ToString() +
            ".jpg";
            Grafico.Alt = "Grafico Temperatura";
            Grafico.Visible = true;
        }
    }
}