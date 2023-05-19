using Guardias_V2.Data;
using Guardias_V2.Model;
using Guardias_V2.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Guardias_V2.ViewModel
{
    public class RegistrarEmpleadosPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Nombre;
        string _Apellido1;
        string _Apellido2;
        string _Identificacion;
        string _Telefono;
        string _Correo;
        string _Direccion;

        #endregion
        #region CONSTRUCTOR
        public RegistrarEmpleadosPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string Apellido1
        {
            get
            {
                return _Apellido1;
            }
            set { SetValue(ref _Apellido1, value); }
        }
        public string Apellido2
        {
            get { return _Apellido2; }
            set { SetValue(ref _Apellido2, value); }
        }
        public string Identificacion
        {
            get { return _Identificacion; }
            set { SetValue(ref _Identificacion, value); }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { SetValue(ref _Telefono, value); }
        }
        public string Correo
        {
            get { return _Correo; }
            set { SetValue(ref _Correo, value); }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set {SetValue(ref _Direccion, value);}
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var parametros = new Empleado();
            parametros.NOMBRE = Nombre;
            parametros.APELLIDO1 = Apellido1;
            parametros.APELLIDO2 = Apellido2;
            parametros.IDENTIFICACION = Identificacion;
            parametros.TELEFONO = Telefono;
            parametros.CORREO = Correo;
            parametros.DIRECCION = Direccion;

            await GuardiasMetodos.AgregarEmpleados(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PushAsync(new ListaEmpleadosPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
