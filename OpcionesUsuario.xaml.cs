namespace Tienda;

public partial class OpcionesUsuario : ContentPage
{
	public OpcionesUsuario()
	{
		InitializeComponent();
	}
    private async void EliminarUsuario()
    {
        try
        {
            // URL de la API que proporciona los datos de productos
            string apiUrl = "https://moviles5elehi.000webhostapp.com/APIS/DELETE_U.php?Id="+VariablesGlobales.Id;

            // Crear un cliente HTTP
            HttpClient httpClient = new HttpClient();

            // Realizar una solicitud GET a la API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                VariablesGlobales.Id = 0;
                VariablesGlobales.NombreUsuario = "";
                VariablesGlobales.Direccion = "";
                VariablesGlobales.Telefono = "";
                VariablesGlobales.Correo = "";
                VariablesGlobales.Foto = "";
                VariablesGlobales.Contrasena = "";
                var cadenaResultante = response.Content.ReadAsStringAsync().Result;
                DisplayAlert("Usuario",cadenaResultante , "Ok");
                Navigation.PopToRootAsync();
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
    private async void EliminarCuenta_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Confirmación", "¿Seguro que deseas eliminar tu cuenta?", "Sí", "No");

        if (result)
        {
            EliminarUsuario();
        }
    }
    private async void CambiarInformacion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CambiarDatos_U());
    }
}