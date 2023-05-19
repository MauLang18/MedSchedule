using Guardias_V2.Data;
using Guardias_V2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Guardias_V2.ViewModel
{
    public class AsignarGuardiasPageViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        DateTime _Fecha;
        string _FechaActual;
        string _ResultadoFecha;
        public Empleado parametrosRecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public AsignarGuardiasPageViewModel(INavigation navigation, Empleado parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
            FechaActual = DateTime.Now.ToString("yyyy/MM/dd");
            Fecha = DateTime.Now;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string ResultadoFecha
        {
            get { return _ResultadoFecha; }
            set { SetValue(ref _ResultadoFecha, value); }
        }
        public string FechaActual
        {
            get { return _FechaActual; }
            set { SetValue(ref _FechaActual, value); }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set
            {
                SetValue( ref _Fecha, value);
                ResultadoFecha = _Fecha.ToString("yyyy/MM/dd");
            }
        }
        #endregion
        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public async Task Insertar()
        {
            var parametros = new Guardia();
            parametros.NOMBRE_EMPLEADO = parametrosRecibe.NOMBRE;
            parametros.APELLIDO1_EMPLEADO = parametrosRecibe.APELLIDO1;
            parametros.IDENTIFICACION_EMPLEADO = parametrosRecibe.IDENTIFICACION;
            parametros.FK_TBL_GUA_EMPELADO = parametrosRecibe.PK_TBL_GUA_EMPLEADO;
            parametros.FECHA = ResultadoFecha;

            Console.WriteLine(ResultadoFecha);
            await GuardiasMetodos.AgregarGuardia(parametros);
            await Volver();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
