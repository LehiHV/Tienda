using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda;

public partial class Registrar : ContentPage
{
	public Registrar()
	{
		InitializeComponent();
	}
    public async Task LlamadaGetAsync(string url)

    {

        //Creamos una instancia de HttpClient

        var client = new HttpClient();

        //Asignamos la URL

        client.BaseAddress = new Uri(url);

        //Llamada asíncrona al sitio

        var response = await client.GetAsync(client.BaseAddress);

        //Nos aseguramos de recibir una respuesta satisfactoria

        response.EnsureSuccessStatusCode();

        //Convertimos la respuesta a una variable string

        var cadenaResultante = response.Content.ReadAsStringAsync().Result;

        await DisplayAlert("Registro", cadenaResultante, "Ok");

        VariablesGlobales.NombreUsuario = NombreEntry.Text;
        VariablesGlobales.Direccion = DireccionEntry.Text;
        VariablesGlobales.Telefono = TelefonoEntry.Text;
        VariablesGlobales.Correo = CorreoEntry.Text;
        VariablesGlobales.Foto = FotoEntry.Text;
        VariablesGlobales.Contrasena = ContraseñaEntry.Text;
        Navigation.PushAsync(new Tienda());


    }
    private void RegistrarseButton_Clicked(object sender, EventArgs e)
	{
        _ = LlamadaGetAsync("https://moviles5elehi.000webhostapp.com/APIS/POST_U.php?Nombre=" + NombreEntry.Text + "&Contrasena=" + ContraseñaEntry.Text + "&Direccion=" + DireccionEntry.Text+ "&Correo=" + CorreoEntry.Text+ "&Telefono=" + TelefonoEntry.Text+ "&Foto=" + FotoEntry.Text);
    }
 }