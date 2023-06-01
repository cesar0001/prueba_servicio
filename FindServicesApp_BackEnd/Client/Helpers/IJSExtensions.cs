using Microsoft.JSInterop;

namespace FindServicesApp_BackEnd.Client.Helpers
{
    //otra forma de importar en js

    //https://www.youtube.com/watch?v=ftDNzD8MGAY&list=PL0kIvpOlieSNdIPZbn-mO15YIjRHY2wI9&index=43&ab_channel=gavilanch2
    public static class IJSExtensions
    {
        public static ValueTask<object> GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            //se coloca object para indicar que no retorna nada la funcion saveAsFile
            return js.InvokeAsync<object>("saveAsFile",
                nombreArchivo,
                Convert.ToBase64String(archivo));
        }

        public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);
        }

        public static ValueTask<object> MostrarMensaje(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            return js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipoMensajeSweetAlert.ToString());
        }

        public async static ValueTask<bool> Confirm(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje, tipoMensajeSweetAlert.ToString());
        }

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
   => js.InvokeAsync<object>(
       "localStorage.setItem",
       key, content
       );

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "localStorage.getItem",
                key
                );

        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "localStorage.removeItem",
                key);


        public static ValueTask<object> prueba(this IJSRuntime js)
        {
            return js.InvokeAsync<object>("SetFocusByElementId", "txtNombrePersona");
        }

        public static ValueTask<bool> mono(this IJSRuntime js)
        {
            return js.InvokeAsync<bool>("focusById", "txtNombrePersona");
        }
    }

    public enum TipoMensajeSweetAlert
    {
        question, warning, error, success, info
    }
}
