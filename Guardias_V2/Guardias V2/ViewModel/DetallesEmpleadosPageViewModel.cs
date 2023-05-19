using Guardias_V2.Model;
using Guardias_V2.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Guardias_V2.ViewModel
{
    public class DetallesEmpleadosPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public Empleado parametrosRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public DetallesEmpleadosPageViewModel(INavigation navigation, Empleado parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public async Task AsignarGuardias()
        {
            await Navigation.PushAsync(new AsignarGuaridasPage(parametrosRecibe));
        }
        public async Task VerGuardias()
        {
            await Navigation.PushAsync(new ListaGuardiasPage(parametrosRecibe));
            Console.WriteLine(parametrosRecibe.IDENTIFICACION);
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand AsignarGuardiasCommand => new Command(async () => await AsignarGuardias());
        public ICommand ListaGuardiasCommand => new Command(async () => await VerGuardias());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
