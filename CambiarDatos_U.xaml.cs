namespace Tienda;

public partial class CambiarDatos_U : ContentPage
{
	public CambiarDatos_U()
	{
		InitializeComponent();
		NombreEntry.Text = VariablesGlobales.NombreUsuario;
		DireccionEntry.Text = VariablesGlobales.Direccion;
        TelefonoEntry.Text = VariablesGlobales.Telefono;
        CorreoEntry.Text = VariablesGlobales.Correo;
        FotoEntry.Text = VariablesGlobales.Foto;
        ContraseñaEntry.Text = VariablesGlobales.Contrasena;
    }
    private async void CambiarUsuario()
    {
        try
        {
            // URL de la API que proporciona los datos de productos
            string apiUrl = "https://moviles5elehi.000webhostapp.com/APIS/UPDATE_U.php?Id=" + VariablesGlobales.Id + "&Nombre=" +NombreEntry.Text + "&Direccion="+DireccionEntry.Text + "&Telefono=" + TelefonoEntry.Text +"&Correo=" +CorreoEntry.Text +"&Foto=" + FotoEntry.Text +"&Contrasena=" + ContraseñaEntry.Text;
            //await DisplayAlert("a", apiUrl, "lol");
            // Crear un cliente HTTP
            HttpClient httpClient = new HttpClient();

            // Realizar una solicitud GET a la API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var cadenaResultante = response.Content.ReadAsStringAsync().Result;
                VariablesGlobales.NombreUsuario = NombreEntry.Text;
                VariablesGlobales.Direccion = DireccionEntry.Text;
                VariablesGlobales.Telefono = TelefonoEntry.Text;
                VariablesGlobales.Correo = CorreoEntry.Text;
                VariablesGlobales.Foto = FotoEntry.Text;
                VariablesGlobales.Contrasena = ContraseñaEntry.Text;
                await DisplayAlert("Usuario", cadenaResultante, "Ok");
                await Navigation.PushAsync(new Tienda());
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
    private async void CambiarDatosButton_Clicked(object sender, EventArgs e)
	{

        CambiarUsuario();
    }

}