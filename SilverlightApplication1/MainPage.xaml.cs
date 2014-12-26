using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;

namespace SilverlightApplication1
{
  public partial class MainPage : UserControl
  {
    public MainPage()
    {
      InitializeComponent();
      List<Modelo.Persona> lista = new List<Modelo.Persona>();
      lista.Add(new Modelo.Persona { Id ="79414057", Apellidos="Torres Ortiz", Nombres="Marcelo Cesar Augusto", FechaNacimiento = new DateTime(1967, 4, 17)});
      lista.Add(new Modelo.Persona { Id = "98071457346", Apellidos = "Torres Mestra", Nombres = "Juan Camilo", FechaNacimiento = new DateTime(1998, 7, 14) });
      lista.Add(new Modelo.Persona { Id = "1001042044", Apellidos = "Torres Mestra", Nombres = "Laura Daniela", FechaNacimiento = new DateTime(2001, 1, 4) });
      lista.Add(new Modelo.Persona { Id = "1001051887", Apellidos = "Torres Mestra", Nombres = "Julián David", FechaNacimiento = new DateTime(2003, 6, 3) });

      this.GrillaDatos.AutoGeneratingColumn += (s, e) =>
      {
        var tipo = (s as DataGrid).ItemsSource.Cast<object>().FirstOrDefault().GetType();
        var formato = tipo.GetProperty(e.PropertyName).GetCustomAttributes(typeof(DisplayFormatAttribute),true).Cast<DisplayFormatAttribute>().FirstOrDefault();
        (e.Column as DataGridTextColumn).Binding.Converter = formato != null ? new DisplayFormatConverter(formato.DataFormatString) : null;
      };
      this.GrillaDatos.ItemsSource = lista;
    }
  }
}
