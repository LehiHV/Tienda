using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using System.Text;

namespace Tienda
{
    public partial class Tienda : ContentPage
    {
        public Tienda()
        {
            InitializeComponent();

            // Realizar la solicitud HTTP para obtener los productos desde la nube
            ObtenerProductosDesdeLaNube();
            NombreUsuarioLabel.Text = VariablesGlobales.NombreUsuario;
            FotoUsuarioImage.Source = VariablesGlobales.Foto;
            Title = VariablesGlobales.NombreTienda;
        }
        //Clases
        public class Producto
        {
            public string Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioCosto { get; set; }
            public decimal PrecioVenta { get; set; }
            public string Foto { get; set; }
        }
        public class Usuario
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Foto { get; set; }
            public string Contrasena { get; set; }
        }
        //Conexiones Http's
        private async void ObtenerProductosDesdeLaNube()
        {
            try
            {
                // URL de la API que proporciona los datos de productos
                string apiUrl = "https://moviles5elehi.000webhostapp.com/APIS/GETS.php";

                // Crear un cliente HTTP
                HttpClient httpClient = new HttpClient();

                // Realizar una solicitud GET a la API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como una cadena JSON
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserializar el JSON en una lista de productos
                    List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);

                    // Enlazar la lista de productos al ListView
                    ListViewItems.ItemsSource = productos;
                }
                else
                {
                    // Manejar el caso en el que la solicitud no fue exitosa
                    // Puedes mostrar un mensaje de error o realizar otras acciones apropiadas.
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, como problemas de red, aquí.
            }
        }


        //Botones Menu
        private async void MainMenuButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tienda());
        }
        private async void ProductsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesProductos());
        }
        private async void UsersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesUsuario());
        }
    }
}