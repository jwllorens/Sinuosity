using OSGeo.OGR;
using OSGeo.GDAL;
using OSGeo.OSR;
using PipeHandler;


namespace GDALIPC
{
    public partial class GDALhost
    {
        public async void ProcessCommand(CommandRequest request)
        {
            string command = request.Command.ToLower();
            string[] arguments = request.Arguments;

            // Validate command and arguments and return CommandResponse immediately
            switch (command)
            {
                case "vectorinfo":
                    VectorInfo_Validate(request.Id, request.Command, arguments);
                    break;

                case "transformpoint":
                    TransformPoint_Validate(request.Id, request.Command, arguments);
                    break;

                case "getpolygonfidbypoint":
                    GetPolygonFIDByPoint_Validate(request.Id, request.Command, arguments);
                    return;

                case "getattributesbyfid":
                    GetAttributesByFID_Validate(request.Id, request.Command, arguments);
                    break;

                case "getgeometrybyfid":
                    GetGeometryByFID_Validate(request.Id, request.Command, arguments);
                    break;

                default:
                    await SendCommandResponse(request.Id, request.Command, "error", $"Unknown command: {command}");
                    break;
            }
        }
        private async void VectorInfo_Validate(string id, string command, string[] arguments)
        {
            if (arguments.Length < 1)
                await SendCommandResponse(id, command, "error", "File path required");
            if (!File.Exists(arguments[0]))
                await SendCommandResponse(id, command, "error", $"File not found: {arguments[0]}");
            VectorInfo(id, arguments[0]);
        }
        private async void TransformPoint_Validate(string id, string command, string[] arguments)
        {
            if (arguments.Length < 4)
                await SendCommandResponse(id, command, "error", "Four arguments required");
            if (!double.TryParse(arguments[0], out double pointX))
                await SendCommandResponse(id, command, "error", "Invalid point");
            if (!double.TryParse(arguments[1], out double pointY))
                await SendCommandResponse(id, command, "error", "Invalid point");
            if (!double.TryParse(arguments[2], out double pointZ))
                await SendCommandResponse(id, command, "error", "Invalid point");
            string testCRS = arguments[3];
            var testSRS = new SpatialReference("");
            testSRS.ImportFromWkt(ref testCRS);
            if (string.IsNullOrEmpty(arguments[3]) || testSRS == null)
                await SendCommandResponse(id, command, "error", "Invalid destination CRS");
            TransformPoint(id, pointX, pointY, pointZ, arguments[3], (arguments.Length < 5) ? null : arguments[4]);
        }
        private async void GetPolygonFIDByPoint_Validate(string id, string command, string[] arguments)
        {
            if (arguments.Length < 4)
                await SendCommandResponse(id, command, "error", "Four arguments required");
            if (!double.TryParse(arguments[0], out double pointX))
                await SendCommandResponse(id, command, "error", "Invalid point");
            if (!double.TryParse(arguments[1], out double pointY))
                await SendCommandResponse(id, command, "error", "Invalid point");
            if (!File.Exists(arguments[2]))
                await SendCommandResponse(id, command, "error", $"File not found: {arguments[2]}");
            if (!int.TryParse(arguments[3], out int layerIndex))
                await SendCommandResponse(id, command, "error", "Invalid layer index");
            GetPolygonFIDByPoint(id, pointX, pointY, arguments[2], layerIndex);
        }
        private async void GetAttributesByFID_Validate(string id, string command, string[] arguments)
        {
            if (arguments.Length < 3)
                await SendCommandResponse(id, command, "error", "Three arguments required");
            if (!File.Exists(arguments[0]))
                await SendCommandResponse(id, command, "error", $"File not found: {arguments[0]}");
            if (!int.TryParse(arguments[1], out int layerIndex))
                await SendCommandResponse(id, command, "error", "Invalid layer index");
            if (!int.TryParse(arguments[2], out int fid))
                await SendCommandResponse(id, command, "error", "Invalid FID");
            GetAttributesByFID(id, arguments[0], layerIndex, fid);
        }
        private async void GetGeometryByFID_Validate(string id, string command, string[] arguments)
        {
            if (arguments.Length < 4)
                await SendCommandResponse(id, command, "error", "Four arguments required");
            if (!File.Exists(arguments[0]))
                await SendCommandResponse(id, command, "error", $"File not found: {arguments[0]}");
            if (!int.TryParse(arguments[1], out int layerIndex))
                await SendCommandResponse(id, command, "error", "Invalid layer index");
            if (!int.TryParse(arguments[2], out int fid))
                await SendCommandResponse(id, command, "error", "Invalid FID");
            if (!bool.TryParse(arguments[3], out bool repairGeometry))
                await SendCommandResponse(id, command, "error", "Invalid repairGeometry argument");
            GetGeometryByFID(id, arguments[0], layerIndex, fid, repairGeometry);
        }
    }
}