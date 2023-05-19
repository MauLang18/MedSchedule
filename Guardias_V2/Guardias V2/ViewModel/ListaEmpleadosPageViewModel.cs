using Guardias_V2.Data;
using Guardias_V2.Model;
using Guardias_V2.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Guardias_V2.ViewModel
{
    public class ListaEmpleadosPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Empleado> _Listapokemon;
        #endregion
        #region CONSTRUCTOR
        public ListaEmpleadosPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarpokemon();
        }
        #endregion
        #region OBJETOS

        public ObservableCollection<Empleado> Listapokemon
        {
            get { return _Listapokemon; }
            set
            {
                SetValue(ref _Listapokemon, value);
                OnPropertyChanged();
            }
        }
        #endregion
        #region PROCESOS
        public async Task Mostrarpokemon()
        {
            Listapokemon = await GuardiasMetodos.ObtenerEmpleados();
            Console.WriteLine(Listapokemon);
        }



        public async Task Iraregistro()
        {
            await Navigation.PushAsync(new RegistroEmpleadoPage());
        }
        public async Task Iradetalle(Empleado parametros)
        {
            await Navigation.PushAsync(new DetallesEmpleadosPage(parametros));
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        #endregion
        #region COMANDOS
        public ICommand Iraregistrocommand => new Command(async () => await Iraregistro());
        public ICommand Iradetallecommand => new Command<Empleado>(async (p) => await Iradetalle(p));
        public ICommand VolverCommand => new Command(async () => await Volver());
        #endregion
    }
}
