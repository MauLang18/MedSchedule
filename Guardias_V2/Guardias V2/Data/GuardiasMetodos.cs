using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Guardias_V2.Model;

namespace Guardias_V2.Data
{
    public class GuardiasMetodos
    {
        public static async Task<ObservableCollection<Empleado>> ObtenerEmpleados()
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/empleados/obtener");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_EMPLEADO = 0,
                        NOMBRE = "",
                        APELLIDO1 = "",
                        APELLIDO2 = "",
                        IDENTIFICACION = "",
                        TELEFONO = "",
                        CORREO = "",
                        DIRECCION = ""
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<Empleado>>(resultado);
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        public static async Task<string> AgregarEmpleados(Empleado e)
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/empleados/agregar");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_EMPLEADO = e.PK_TBL_GUA_EMPLEADO,
                        NOMBRE = e.NOMBRE,
                        APELLIDO1 = e.APELLIDO1,
                        APELLIDO2 = e.APELLIDO2,
                        IDENTIFICACION = e.IDENTIFICACION,
                        TELEFONO = e.TELEFONO,
                        CORREO = e.CORREO,
                        DIRECCION = e.DIRECCION
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return "Empleado agregado exitosamente.";
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        public static async Task<string> ModificarEmpleados(Empleado e)
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/empleados/modificar");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_EMPLEADO = e.PK_TBL_GUA_EMPLEADO,
                        NOMBRE = e.NOMBRE,
                        APELLIDO1 = e.APELLIDO1,
                        APELLIDO2 = e.APELLIDO2,
                        IDENTIFICACION = e.IDENTIFICACION,
                        TELEFONO = e.TELEFONO,
                        CORREO = e.CORREO,
                        DIRECCION = e.DIRECCION
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PutAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return "Empleado agregado exitosamente.";
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        public static async Task<ObservableCollection<Guardia>> ObtenerGuardias(Guardia e)
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/guardias/obtener");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_GUARDIA = 0,
                        NOMBRE_EMPLEADO = "",
                        APELLIDO1_EMPLEADO = "",
                        IDENTIFICACION_EMPLEADO = e.IDENTIFICACION_EMPLEADO,
                        FECHA = "",
                        FK_TBL_GUA_EMPELADO = 0
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<Guardia>>(resultado);
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        public static async Task<string> AgregarGuardia(Guardia e)
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/guardias/agregar");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_GUARDIA = e.PK_TBL_GUA_GUARDIA,
                        NOMBRE_EMPLEADO = e.NOMBRE_EMPLEADO,
                        APELLIDO1_EMPLEADO = e.APELLIDO1_EMPLEADO,
                        IDENTIFICACION_EMPLEADO = e.IDENTIFICACION_EMPLEADO,
                        FECHA = e.FECHA,
                        FK_TBL_GUA_EMPELADO = e.FK_TBL_GUA_EMPELADO
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return "Empleado agregado exitosamente.";
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        public static async Task<string> ModificarGuarida(Guardia e)
        {
            try
            {
                using (HttpClient client = new HttpClient(await GetInsecureHandler()))
                {
                    var uri = new Uri("https://guaridasapi.azurewebsites.net/api/guardias/modificar");

                    var json = JsonConvert.SerializeObject(new
                    {
                        OPCION = 0,
                        USUARIO = "",
                        PK_TBL_GUA_GUARDIA = e.PK_TBL_GUA_GUARDIA,
                        NOMBRE_EMPLEADO = e.NOMBRE_EMPLEADO,
                        APELLIDO1_EMPLEADO = e.APELLIDO1_EMPLEADO,
                        IDENTIFICACION_EMPLEADO = e.IDENTIFICACION_EMPLEADO,
                        FECHA = e.FECHA,
                        FK_TBL_GUA_EMPELADO = e.FK_TBL_GUA_EMPELADO
                    });

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                    HttpResponseMessage response = client.PutAsync(uri, content).Result;
                    Console.WriteLine(response.Content.ReadAsStringAsync());
                    string resultado = await response.Content.ReadAsStringAsync();
                    string mensaje = string.Empty;

                    if (response.IsSuccessStatusCode)
                    {
                        return "Empleado agregado exitosamente.";
                    }
                    else
                    {
                        mensaje = (JsonConvert.DeserializeObject<string>(resultado));
                        throw new ApplicationException(mensaje);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new ApplicationException("WEB_ERROR: [" + wex.Message + "]" + (wex.InnerException != null ? " INNER: [" + wex.InnerException.Message + "]" : ""));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo una excepción: {0}", ex.Message); throw new ApplicationException("ERROR: [" + ex.Message + "]" + (ex.InnerException != null ? " INNER: [" + ex.InnerException.Message + "]" : ""));
            }
        }

        private static async Task<HttpClientHandler> GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }


    }
}
