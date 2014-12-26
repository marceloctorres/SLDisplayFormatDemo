using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;


namespace SilverlightApplication1.Modelo
{
  
  public class Persona
  {
    [Display(Name="Identificacion")]
    public string Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:###0.00}")]
    public double Edad
    {
      get
      {
        if (this.FechaNacimiento != DateTime.MinValue)
        {
          return (DateTime.Today - this.FechaNacimiento).TotalDays / 365;
        }
        else
        {
          return -1;
        }
      }
    }

    [Display(Name="Fecha de Nacimiento"), DisplayFormat(DataFormatString="{0:d}")]
    public DateTime FechaNacimiento { get; set; }
  }
}
