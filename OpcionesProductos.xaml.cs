namespace Tienda;

public partial class OpcionesProductos : ContentPage
{
	public OpcionesProductos()
	{
		InitializeComponent();
	}

    private async void EliminarProducto()
    {
        try
        {
            string productoAEliminar = await DisplayPromptAsync("Eliminar Producto", "Ingrese el número del producto a eliminar:", "Eliminar", "Cancelar", maxLength: 3, keyboard: Keyboard.Numeric);
            // URL de la API que proporciona los datos de productos
            string apiUrl = "https://moviles5elehi.000webhostapp.com/APIS/DELETE.php?Id=" + productoAEliminar;

            // Crear un cliente HTTP
            HttpClient httpClient = new HttpClient();

            // Realizar una solicitud GET a la API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var cadenaResultante = response.Content.ReadAsStringAsync().Result;
                DisplayAlert("Producto", cadenaResultante, "Ok");
                Navigation.PushAsync(new Tienda());
            }
            else
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones, como problemas de red, aquí.
        }
    }
    private async void CambiarInformacion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CambiarDatos_P());
    }
    private async void EliminarProducto_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Confirmación", "¿Seguro que deseas eliminar un Producto?", "Sí", "No");

        if (result)
            EliminarProducto();
    }

    private async void AgregarProducto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Agregar_Producto());
    }
}