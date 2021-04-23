using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;

namespace Console2Webapi {
    class Program {
        static async Task Main(string[] args) {
            await run();
        }
        static async Task run() {
            var http = new HttpClient();

            try {
                var res = await http.GetAsync("http://localhost:61383/api/users");
                res.EnsureSuccessStatusCode();
                var resbody = await res.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<User[]>(resbody);
                Console.WriteLine($"Result: {json}");
            } catch(HttpRequestException e) {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
    class User {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; } = "Train@MAX";
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool isReviewer { get; set; }
        public bool isAdmin { get; set; }
    }
}
