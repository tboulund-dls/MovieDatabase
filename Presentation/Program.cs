// See https://aka.ms/new-console-template for more information

while (true)
{
    Console.Write("Enter page number: ");

    int page;
    string input = "INVALID";
    while (!int.TryParse(input, out page))
    {
        input = Console.ReadLine() ?? string.Empty;
    }

    HttpClient http = new HttpClient();
    var response = http.Send(new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5215/Movie?page=" + page))).Content.ReadAsStream();
    var streamReader = new StreamReader(response);
    Console.WriteLine(streamReader.ReadToEnd());
}