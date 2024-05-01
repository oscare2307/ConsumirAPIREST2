using FileStore.Models;
using FileStore.Paginas;
using System.Text.Json;

namespace FileStore
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           var product = new Product();
            product.Title = EntryTitulo.Text;
            product.Price = Convert.ToDecimal(EntryPrecio.Text);
            product.Description = EntryDescripcion.Text;
            product.Category = EntryCategoria.Text;

            //await DisplayAlert("Creado", "El producto se ha creado", "OK");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json);

            using (var client = new HttpClient())
            {
                var resp = await client.PostAsync("https://fakestoreapi.com/products", content);

                if (resp.IsSuccessStatusCode)
                {

                    var contentBody = await resp.Content.ReadAsStringAsync();
                    var productResult = JsonSerializer.Deserialize<IdProduct>(contentBody);

                    await DisplayAlert("Mensaje", $"El producto creado es {productResult.Id} ", "OK");
                }

            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarProductoPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarProductoPage());
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarProductoPage());
        }
    }
}


