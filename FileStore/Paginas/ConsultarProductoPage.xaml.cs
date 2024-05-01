using FileStore.Models;
using System.Text.Json;

namespace FileStore.Paginas;

public partial class ConsultarProductoPage : ContentPage
{
    public ConsultarProductoPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var idProducto = EntryCodigoProducto.Text;

        using (var http = new HttpClient())
        {

            var resp = await http.GetAsync($"https://fakestoreapi.com/products/{idProducto}");

            if (resp.IsSuccessStatusCode)
            {


                var resposeBody = await resp.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ResponseProduct>(resposeBody);

                if (product is not null)
                {

                    EntryTituloProducto.Text = product.Title;
                    EntryPrecioProducto.Text = product.Price.ToString();
                    EntryCategoriaProducto.Text = product.Category;
                    EntryDescripcionProducto.Text = product.Description;
                    Img.Source = product.Image;

                }

            }
            else
            {

                await DisplayAlert("Resultado", "No se ha encontrado un producto", "OK");

            }
        }
    }
}