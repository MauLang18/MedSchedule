using Guardias_V2.Model;
using Guardias_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Guardias_V2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetallesEmpleadosPage : ContentPage
	{
		public DetallesEmpleadosPage (Empleado parametros)
		{
			InitializeComponent ();
			BindingContext = new DetallesEmpleadosPageViewModel(Navigation,parametros);
		}
	}
}