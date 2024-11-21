using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;

class DayExtractor {
    int year;
    int day;
    string cookie;

    public DayExtractor(int year, int day){
        this.year = year;
        this.day = day;
        this.cookie = "53616c7465645f5f981d0c9793adcec5aafaa367cbb0d41cd52414433a21aef8247b5ade71ba0e209be70890f60d25d9f013cb15dd7cc5c4f64bb002b346b225";
    }

    public async Task extract(){
        var url = $"https://adventofcode.com/{this.year}/day/{this.day}/input";
        string folderPath = $"..\\{this.year}\\{this.day.ToString().PadLeft(2, '0')}\\input";
        Directory.CreateDirectory(folderPath);
        string filePath = Path.Combine(folderPath, "input.txt");
        using (HttpClient client = new HttpClient()){
            try
            {
                // Fai la richiesta GET per ottenere il contenuto
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");
                 request.Headers.Add("Cookie", $"session={this.cookie}");

                var response = await client.SendAsync(request);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await stream.CopyToAsync(fileStream);
                }
                
                Console.WriteLine("File salvato con successo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
        }
    }
}
