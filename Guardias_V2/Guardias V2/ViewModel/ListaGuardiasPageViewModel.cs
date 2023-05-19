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
    public class ListaGuardiasPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Guardia> _Listapokemon;
        public Empleado parametrosRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public ListaGuardiasPageViewModel(INavigation navigation, Empleado parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
            Mostrarpokemon(parametrosRecibe);
        }
        #endregion
        #region OBJETOS

        public ObservableCollection<Guardia> Listapokemon
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
        public async Task Mostrarpokemon(Empleado empleado)
        {
            var parametros = new Guardia();
            parametros.IDENTIFICACION_EMPLEADO = empleado.IDENTIFICACION;
            Listapokemon = await GuardiasMetodos.ObtenerGuardias(parametros);
            Console.WriteLine(Listapokemon);
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        #endregion
        #region COMANDOS
        public ICommand VolverCommand => new Command(async () => await Volver());
        #endregion
    }
}
