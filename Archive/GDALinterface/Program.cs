

namespace GDALinterface
{
    class GDALserverApp
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GDALserver.log");
        private GDALserver _server;

        static async Task Main(string[] args)
        {
            var serverApp = new GDALserverApp();
            await serverApp.Run();
        }

        string shapefile = @"C:\Users\john\Documents\SinuosityResources\cb_2018_us_state_500k.shp";
        string GUID1 = "";
        string GUID2 = "";
        string GUID3 = "";
        string GUID4 = "";
        string GUID5 = "";
        string proj = "";
        double[] transpoint = new double[3];
        string fid = "";

        private async Task Run()
        {
            try
            {
                string _hostPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GDALPipe");
                _hostPath = @"C:\Users\john\Documents\Sinuosity\GDALhost\bin\Debug\net8.0\GDALhost.exe";
                // Initialize NamedPipeServer
                _server = new GDALserver("GDALPipe", _hostPath, Log);

                // Attach a lambda expression to the ClientReadyToProcess event
                _server.ClientReadyToProcess += async (sender, e) => {await _server.SendCommandRequest(Guid.NewGuid().ToString(), "ListCommands", null); };
                _server.ListCommands_ResultReceived += async (sender, e) => 
                {
                    GUID1 = Guid.NewGuid().ToString();
                    await _server.SendCommandRequest(GUID1, "VectorInfo", new string[] { shapefile });
                };
                _server.VectorInfo_ResultReceived += async (sender, e) => 
                {
                    if (e.Message.Id == GUID1)
                    {
                        proj = e.Message.Result.Layers[0].Projection;
                        GUID2 = Guid.NewGuid().ToString();
                        await _server.SendCommandRequest(GUID2, "TransformPoint", new string[] { "-87", "35", "0", proj });
                    }
                };
                _server.TransformPoint_ResultReceived += async (sender, e) =>
                {
                    if (e.Message.Id == GUID2)
                    {
                        transpoint = e.Message.Result;
                        GUID3 = Guid.NewGuid().ToString();
                        await _server.SendCommandRequest(GUID3, "GetPolygonFIDByPoint", new string[] { transpoint[0].ToString(), transpoint[1].ToString(), shapefile, "0" });
                    }
                };
                _server.GetPolygonFIDByPoint_ResultReceived += async (sender, e) => 
                {
                    if (e.Message.Id == GUID3)
                    {
                        fid = e.Message.Result.ToString();
                        GUID4 = Guid.NewGuid().ToString();
                        await _server.SendCommandRequest(GUID4, "GetAttributesByFID", new string[] { shapefile, "0", fid.ToString() });
                    }
                };
                _server.GetAttributesByFID_ResultReceived += async (sender, e) =>
                {
                    if (e.Message.Id == GUID4)
                    {
                        var attributes = e.Message.Result;
                        // Process the attributes as needed
                        foreach (var attribute in attributes)
                        {
                            Console.WriteLine(attribute);
                        }
                        Console.WriteLine("\r\n");
                        GUID5 = Guid.NewGuid().ToString();
                        await _server.SendCommandRequest(GUID5, "GetGeometryByFID", new string[] { shapefile, "0", fid.ToString(), "true" });
                    }
                };
                _server.GetGeometryByFID_ResultReceived += async (sender, e) =>
                {
                    if (e.Message.Id == GUID5)
                    {
                        var geometry = e.Message.Result;
                        // Process the geometry as needed
                        Console.WriteLine("\r\n");
                        Console.WriteLine("All commands executed successfully.");
                    }
                };

                // Start the server
                await _server.Start();
                while (true)
                    await Task.Delay(100);

            }
            catch (Exception ex)
            {
                if (!(Log == null)) Log($"Error: {ex.Message}");
            }
            finally
            {
                _server?.Dispose();
            }
        }

        private static void Log(string message)
        {
            string timestampedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [Server] {message}";
            Console.WriteLine(timestampedMessage);
        }
        
    }
}