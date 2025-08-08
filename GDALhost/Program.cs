using System.Text.Json;
using OSGeo.OGR;
using OSGeo.GDAL;
using OSGeo.OSR;
using PipeHandler;

namespace GDALIPC
{
    class GDALclientApp
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GDALhost.log");
        private GDALhost _GDAL = null;

        static async Task Main(string[] args)
        {
            Log("Configuring OGR...");
            GdalConfiguration.ConfigureOgr();
            Log("OGR configured successfully.");

            Log("Registering OGR drivers...");
            Ogr.RegisterAll();
            Log("OGR drivers registered successfully.");

            string gdalVersion = Gdal.VersionInfo("RELEASE_NAME");

            // Create an instance of GDALclient to access non-static methods and fields
            var clientApp = new GDALclientApp();

            // Initialize the NamedPipeClient and command processor
            clientApp._GDAL = new GDALhost("GDALPipe", Log);

            Log($"GDAL Host (using OGR {gdalVersion})");

            try
            {
                //await Task.Delay(10000);
                await clientApp._GDAL.Connect();

                // Keep the client running to listen for messages
                while (true)
                {
                    await Task.Delay(100); // Prevent tight loop
                    if (!clientApp._GDAL.Connected)
                       break;
                }
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
            }
            finally
            {
                clientApp._GDAL?.Dispose();
            }
        }
        static void Log(string message)
        {
            string timestampedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [Client] {message}";
            Console.WriteLine(timestampedMessage);
        }
    }
}