using Guardias_V2.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Guardias_V2.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Password;
        string _Usuario;
        #endregion
        #region CONSTRUCTOR
        public LoginPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string Password
        {
            get { return _Password; }
            set { SetValue(ref _Password, value); }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { SetValue(ref _Usuario, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IrListaEmpleados()
        {
            await Navigation.PushAsync(new ListaEmpleadosPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand IrListaEmpleadosCommand => new Command(async () => await IrListaEmpleados());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
