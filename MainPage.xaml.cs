using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tienda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Foto { get; set; }
            public string Contrasena { get; set; }
        }

        private async void EntrarButton_Clicked(object sender, EventArgs e)
        {

            string nombreUsuario = UsuarioEntry.Text;
            string c = ContraseñaEntry.Text;

            // Realizar una solicitud HTTP para verificar si el usuario existe
            Dictionary<string, string> camposUsuario = await ObtenerUsuarioAsync(nombreUsuario, c);

            if (camposUsuario != null)
            {
                VariablesGlobales.Id = Convert.ToInt32(camposUsuario["Id"]);
                VariablesGlobales.NombreUsuario = camposUsuario["Nombre"];
                VariablesGlobales.Direccion = camposUsuario["Direccion"];
                VariablesGlobales.Correo = camposUsuario["Correo"];
                VariablesGlobales.Telefono = camposUsuario["Telefono"];
                VariablesGlobales.Foto = camposUsuario["Foto"];
                VariablesGlobales.Contrasena = camposUsuario["Contrasena"];
                await DisplayAlert("Usuario Encontrado", "Bienvenido", "OK");
                
                if (VariablesGlobales.NombreTienda == string.Empty)
                {
                    VariablesGlobales.NombreTienda = "Tienda";
                    await Navigation.PushAsync(new Tienda());
                }
                else
                {
                    await Navigation.PushAsync(new SplashPage());
                    await Task.Delay(1000);
                    await Navigation.PushAsync(new Tienda());
                }
            }
            else
            {
                // El usuario no existe
                await DisplayAlert("Usuario no encontrado", "El usuario no existe en la base de datos", "OK");
            }
        }


        private async Task<Dictionary<string, string>> ObtenerUsuarioAsync(string usuario, string con)
        {
            try
            {
                // URL de tu API para obtener el usuario
                string apiUrl = $"https://moviles5elehi.000webhostapp.com/APIS/GET_U.php?Nombre=" + usuario + "&Contrasena=" + con;

                // Crear un cliente HTTP
                using (HttpClient httpClient = new HttpClient())
                {
                    // Realizar una solicitud GET a la API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta JSON de la API
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserializar el JSON en un diccionario de campos del usuario
                        Dictionary<string, string> camposUsuario = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                        return camposUsuario;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, como problemas de red, aquí.
            }

            // Si hubo un error o el usuario no existe, devuelve null
            return null;
        }

        private async void RegistrateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
        private async void ImagenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Opciones());
        }
    }
}
