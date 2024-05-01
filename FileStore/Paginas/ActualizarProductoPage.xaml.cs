using FileStore.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FileStore.Paginas
{
    public partial class ActualizarProductoPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public ActualizarProductoPage()
        {
            InitializeComponent();

            _httpClient = new HttpClient();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var product = new Product();
                product.Title = EntryTitulo.Text;
                product.Price = Convert.ToDecimal(EntryPrecio.Text);
                product.Description = EntryDescripcion.Text;
                product.Category = EntryCategoria.Text;

                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Obtener el ID del producto que se desea actualizar
                int idProduct = ObtenerIdProductoSeleccionado();
                if (idProduct == 0)
                {
                    await DisplayAlert("Error", "No se ha seleccionado ningún producto para actualizar", "OK");
                    return;
                }

                // Construir la URL de la API con el ID del producto
                string apiUrl = $"https://fakestoreapi.com/products/{idProduct}";

                // Enviar la solicitud PUT a la API
                var response = await _httpClient.PutAsync(apiUrl, content);

                // Verificar la respuesta de la API
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "El producto se ha actualizado correctamente", "OK");
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    var errorMessage = JsonSerializer.Deserialize<ErrorResponse>(errorResponse);
                    await DisplayAlert("Error", errorMessage.Error, "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // Método para obtener el ID del producto seleccionado
        private int ObtenerIdProductoSeleccionado()
        {
            // Implementa este método para obtener el ID del producto seleccionado
            // Puedes obtener el ID desde tu interfaz de usuario o de alguna fuente de datos
            return 0;
        }
    }
}

