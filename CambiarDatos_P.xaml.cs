using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;

namespace Tienda;

public partial class CambiarDatos_P : ContentPage
{
	public CambiarDatos_P()
	{
		InitializeComponent();
	}
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

    private async void CambiarProductos()
    {
        try
        {
            if (IdEntry.Text != "" || !string.IsNullOrWhiteSpace(IdEntry.Text))
            {
                // URL de la API que proporciona los datos de productos
                string apiUrl = "https://moviles5elehi.000webhostapp.com/APIS/UPDATE_P.php?Id=" + IdEntry.Text + "&Nombre=" + NombreEntry.Text + "&Descripcion=" + DescripcionEntry.Text + "&Cantidad=" + CantidadEntry.Text + "&PrecioCosto=" + PrecioCostoEntry.Text + "&Foto=" + FotoEntry.Text + "&PrecioVenta=" + PrecioVentaEntry.Text;
                //await DisplayAlert("a", apiUrl, "lol");
                // Crear un cliente HTTP
                HttpClient httpClient = new HttpClient();

                // Realizar una solicitud GET a la API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var cadenaResultante = response.Content.ReadAsStringAsync().Result;
                    await DisplayAlert("Productos", cadenaResultante, "Ok");
                    await Navigation.PushAsync(new Tienda());
                }
                else
                {

                    var cadenaResultante = response.Content.ReadAsStringAsync().Result;
                    await DisplayAlert("Productos", cadenaResultante, "Ok");
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones, como problemas de red, aquí.
        }
    }

    private async void BuscarButton_Clicked(object sender, EventArgs e)
    {
        // Obtén el valor del Entry de ID
        string id = IdEntry.Text;

        if (string.IsNullOrWhiteSpace(id))
        {
            await DisplayAlert("Error", "Por favor, ingrese un valor de ID válido.", "OK");
            return;
        }

        // Realiza una solicitud HTTP para buscar el producto por su ID
        string apiUrl = $"https://moviles5elehi.000webhostapp.com/APIS/GET_P.php?Id={id}";

        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta JSON de la API
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserializar el JSON y mostrar los datos en los Entry correspondientes
                    // Supongamos que tienes una clase Producto para deserializar el JSON
                    Producto producto = JsonConvert.DeserializeObject<Producto>(jsonResponse);

                    // Actualiza los Entry con los datos del producto
                    NombreEntry.Text = producto.Nombre;
                    DescripcionEntry.Text = producto.Descripcion;
                    CantidadEntry.Text = producto.Cantidad.ToString();
                    PrecioCostoEntry.Text = producto.PrecioCosto.ToString();
                    PrecioVentaEntry.Text = producto.PrecioVenta.ToString();
                    FotoEntry.Text = producto.Foto;
                }
                else
                {
                    await DisplayAlert("Error", "Producto no encontrado.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error de red: {ex.Message}", "OK");
        }
    }
    private async void GuardarButton_Clicked(object sender, EventArgs e)
    {
        CambiarProductos();
    }
}