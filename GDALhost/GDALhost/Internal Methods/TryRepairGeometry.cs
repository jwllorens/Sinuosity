using OSGeo.OGR;

namespace GDALIPC
{
    public partial class GDALhost
    {
        private static int TryRepairGeometry(Geometry inputGeometry, out Geometry repairedGeometry)
        {
            repairedGeometry = null;

            // Check for null input
            if (inputGeometry == null)
            {
                return 2;
            }

            try
            {
                // Check if the geometry is already valid
                if (inputGeometry.IsValid())
                {
                    repairedGeometry = inputGeometry;
                    return 0;
                }

                // Attempt to repair the geometry
                using var repaired = inputGeometry.MakeValid(null);
                if (repaired != null && repaired.IsValid())
                {
                    repairedGeometry = repaired.Clone(); // Clone to avoid disposal issues
                    return 1;
                }

                // Repair failed or result is still invalid
                return 2;
            }
            catch (Exception)
            {
                // Handle any unexpected errors during validation or repair
                return 2;
            }
        }
    }
}