using OSGeo.OSR;
using System.Text.Json;
using System.Reflection;

namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[<double pointX>, <double pointY>, <double pointZ>, <string toSrsWkt>, <string fromSrsWkt>]")]
        private async void TransformPoint(string id, double x, double y, double z, string toSrsWkt, string fromSrsWkt)
        {
            var commandName = nameof(TransformPoint);
            try
            {
                string toSrsWktCopy = toSrsWkt;
                string fromSrsWktCopy = fromSrsWkt;
                SpatialReference srcSrs = new SpatialReference("");
                SpatialReference dstSrs = new SpatialReference("");
                if (string.IsNullOrEmpty(fromSrsWkt))
                {
                    srcSrs.ImportFromEPSG(4326); // WGS84
                }
                else
                {
                    srcSrs.ImportFromWkt(ref fromSrsWktCopy);
                }
                if (string.IsNullOrEmpty(toSrsWkt))
                {
                    dstSrs.ImportFromEPSG(4326); // WGS84
                }
                else
                {
                    dstSrs.ImportFromWkt(ref toSrsWktCopy);
                }

                string srcSrsName = srcSrs.GetName().Replace("_", " ");
                string dstSrsName = dstSrs.GetName().Replace("_", " ");

                await SendCommandResponse(id, commandName, "success", $"{commandName} starting...\r\n\r\n{(string.IsNullOrEmpty(fromSrsWkt) ? $"NULL SOURCE SRS - USING" : "SOURCE SRS")}: {srcSrsName}\r\n{(string.IsNullOrEmpty(toSrsWkt) ? "NULL DESTINATION SRS - USING" : "DESTINATION SRS")}: {dstSrsName}");
                using (CoordinateTransformation transform = new CoordinateTransformation(srcSrs, dstSrs))
                {
                    double[] point = new double[] { x, y, z };
                    transform.TransformPoint(point);
                    await SendCommandResult(id, commandName, "success", point, $"Successfully transformed:\r\n\r\nSOURCE POINT [{x},{y},{z}] - {srcSrsName}\r\nDESITINATION POINT {JsonSerializer.Serialize(point)} - {dstSrsName}");
                }
            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", null, $"{commandName} error: {ex.Message}");
            }
        }
    }
}