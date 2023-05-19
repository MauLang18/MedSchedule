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
	public partial class ListaGuardiasPage : ContentPage
	{
		public ListaGuardiasPage (Empleado parametros)
		{
			InitializeComponent ();
			BindingContext = new ListaGuardiasPageViewModel(Navigation, parametros);
		}
	}
}