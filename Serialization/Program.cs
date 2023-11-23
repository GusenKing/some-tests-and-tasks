using System.Text.Json;

var client = new HttpClient();
var responce = await client.GetAsync(new Uri("https://jsonplaceholder.typicode.com/posts"));
var contentArray = JsonSerializer.Deserialize<Temp>(responce.Content.ReadAsStringAsync().Result);

var serialized = JsonSerializer.Serialize<Temp>(contentArray);


class Temp
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}
