using System.Text.Json;

namespace Snackistwo.DAL
{
    public class CategoryManagerAPI
    {
        private static Uri BaseAdress = new Uri("https://categoryapi.azurewebsites.net/");

        public static async Task<List<Models.Category>> GetCategories()
        {
            List<Models.Category> categories = new List<Models.Category>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAdress;
                HttpResponseMessage response = await client.GetAsync("api/category");
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Models.Category>>(responseString);
                }
                return categories;
            }
        }


    }
}
