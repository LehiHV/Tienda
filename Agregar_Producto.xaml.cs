namespace Tienda;

public partial class Agregar_Producto : ContentPage
{
	public Agregar_Producto()
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

        await Navigation.PushAsync(new Tienda());


    }

    private async void AgregarButton_Clicked(object sender, EventArgs e)
	{

        _ = LlamadaGetAsync("https://moviles5elehi.000webhostapp.com/APIS/POST.php?Nombre=" + NombreEntry.Text + "&Descripcion=" + DescripcionEntry.Text + "&Cantidad=" + CantidadEntry.Text + "&PrecioCosto=" + PrecioCostoEntry.Text + "&PrecioVenta=" + PrecioVentaEntry.Text + "&Foto=" + FotoEntry.Text);
    }
}