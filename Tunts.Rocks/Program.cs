using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Tunts.Rocks.Helpers;
using Tunts.Rocks.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Enter the sheet ID: ");
        string spreadsheetId = Console.ReadLine();

        Console.Write("Enter the path to you JSON credentials file: ");
        string jsonFilePath = Console.ReadLine();

        var credential = GetCredential(jsonFilePath);
        var service = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "TuntsRocks",
        });

        string range = "A1:G25";

        SpreadsheetsResource.ValuesResource.GetRequest request =
            service.Spreadsheets.Values.Get(spreadsheetId, range);

        var response = request.Execute();
        var values = response.Values;

        if (values != null && values.Count > 0)
        {
            foreach (var row in values)
            {
                foreach (var cell in row)
                {
                    Console.Write($"{cell} ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No data found.");
        }

        var asyncProcessor = new SheetsAPI(service, spreadsheetId);
        
        asyncProcessor.ProcessGrades();

        ConsoleEX.WriteLineWithColor("All done, press ANY key to exit.", ConsoleColor.DarkGreen);
    }


    static UserCredential GetCredential(string jsonFilePath)
    {
        using (var stream = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            return GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { SheetsService.Scope.Spreadsheets },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }
    }
}
