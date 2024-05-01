using System.Net.Http;

namespace FileStore.Paginas;

public partial class EliminarProductoPage : ContentPage
{
    private readonly HttpClient _httpClient;
    public EliminarProductoPage()
	{
		InitializeComponent();

        _httpClient = new HttpClient();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obtener el ID del producto que se desea eliminar
            int idProducto = ObtenerIdProductoSeleccionado();
            if (idProducto == 0)
            {
                await DisplayAlert("Error", "No se ha seleccionado ningún producto para eliminar", "OK");
                return;
            }

            // Construir la URL de la API con el ID del producto
            string apiUrl = ($"https://fakestoreapi.com/products/{idProducto}");

            // Enviar la solicitud DELETE a la API
            HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Mensaje", "El producto se ha eliminado correctamente", "OK");
            }
            else
            {
                // Mostrar mensaje de error si la solicitud falló
                await DisplayAlert("Error", "No se pudo eliminar el producto", "OK");
            }
        }
        catch (Exception ex)
        {
            // Capturar y mostrar cualquier excepción
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // Método para obtener el ID del producto seleccionado
    private int ObtenerIdProductoSeleccionado()
    {
        if (int.TryParse(EntryIdProducto.Text, out int id))
            return id;
        else
            return 0;
    }
}