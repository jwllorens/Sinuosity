using SinuosityCore.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinuosity
{
    public static class DefaultConfiguration
    {
        public static IReadOnlyDictionary<string, object> Values = new Dictionary<string, object>
        {
                {Resources.Config_ShapeFile_Path_State, "C:\\Users\\john\\Documents\\SinuosityResources\\cb_2018_us_state_500k.shp"},
                {Resources.Config_ShapeFile_Field_State, "NAME"},
                {Resources.Config_ShapeFile_Path_County, "C:\\Users\\john\\Documents\\SinuosityResources\\cb_2018_us_county_500k.shp"},
                {Resources.Config_ShapeFile_Field_County, "NAME"},
                {Resources.Config_ShapeFile_Path_L4Ecoregion, "C:\\Users\\john\\Documents\\SinuosityResources\\us_eco_l4_no_st.shp"},
                {Resources.Config_ShapeFile_Field_L4Ecoregion, "US_L4NAME"},
                {Resources.Config_ShapeFile_Path_L3Ecoregion, "C:\\Users\\john\\Documents\\SinuosityResources\\us_eco_l4_no_st.shp"},
                {Resources.Config_ShapeFile_Field_L3Ecoregion, "US_L3NAME"},
                {Resources.Config_ShapeFile_Path_EcoregionCode, "C:\\Users\\john\\Documents\\SinuosityResources\\us_eco_l4_no_st.shp"},
                {Resources.Config_ShapeFile_Field_EcoregionCode, "US_L4CODE"},
                {Resources.Config_ShapeFile_Path_HUCWatershedName, "C:\\Users\\john\\Documents\\SinuosityResources\\HUC8_US.shp"},
                {Resources.Config_ShapeFile_Field_HUCWatershedName, "NAME"},
                {Resources.Config_ShapeFile_Path_HUCWatershedCode, "C:\\Users\\john\\Documents\\SinuosityResources\\HUC8_US.shp"},
                {Resources.Config_ShapeFile_Field_HUCWatershedCode, "HUC8"},
                {"/GeoProperty/Reference Reach Database Path", "C:\\Users\\john\\Documents\\SinuosityResources\\ReferenceReaches.csv"}
        };
    }
}
