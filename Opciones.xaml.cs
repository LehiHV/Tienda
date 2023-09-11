namespace Tienda;

public partial class Opciones : ContentPage
{
	public Opciones()
	{
		InitializeComponent();
	}
    private async void GuardarConfiguracion_Clicked(object sender, EventArgs e)
    {
        VariablesGlobales.NombreTienda = NombreTiendaEntry.Text;
        VariablesGlobales.ImagenTienda = UrlFotoEntry.Text;
        await DisplayAlert("Opciones", "Datos Guardados Correctamente", "OK");
        await Navigation.PopToRootAsync();
    }
}