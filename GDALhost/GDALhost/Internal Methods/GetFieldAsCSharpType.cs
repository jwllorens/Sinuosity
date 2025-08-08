using OSGeo.OGR;
using OSGeo.GDAL;
using OSGeo.OSR;
using System.Runtime.InteropServices;
using System.Reflection;


namespace GDALIPC
{
    public partial class GDALhost
    {
        private static object _getFieldAsCSharpType(Feature feature, int fieldIndex)
        {
            FieldDefn fieldDefn = feature.GetFieldDefnRef(fieldIndex);
            FieldType fieldType = fieldDefn.GetFieldType();

            switch (fieldType)
            {
                case FieldType.OFTInteger:
                    return feature.GetFieldAsInteger(fieldIndex);
                    break;
                case FieldType.OFTInteger64:
                    return feature.GetFieldAsInteger64(fieldIndex);
                case FieldType.OFTReal:
                    return feature.GetFieldAsDouble(fieldIndex);
                case FieldType.OFTString:
                    return feature.GetFieldAsString(fieldIndex);
                case FieldType.OFTDate:
                    feature.GetFieldAsDateTime(fieldIndex, out int year, out int month, out int day, out int hour, out int minute, out float second, out int tzFlag);
                    return new DateTime(year, month, day, hour, minute, (int)second);
                case FieldType.OFTTime:
                    feature.GetFieldAsDateTime(fieldIndex, out year, out month, out day, out hour, out minute, out second, out tzFlag);
                    return new DateTime(year, month, day, hour, minute, (int)second);
                case FieldType.OFTDateTime:
                    feature.GetFieldAsDateTime(fieldIndex, out year, out month, out day, out hour, out minute, out second, out tzFlag);
                    return new DateTime(year, month, day, hour, minute, (int)second);
                case FieldType.OFTIntegerList:
                    return feature.GetFieldAsIntegerList(fieldIndex, out int _);
                    break;
                case FieldType.OFTInteger64List:
                    return feature.GetFieldAsIntegerList(fieldIndex, out _);
                case FieldType.OFTRealList:
                    return feature.GetFieldAsDoubleList(fieldIndex, out _);
                case FieldType.OFTStringList:
                    return feature.GetFieldAsStringList(fieldIndex);
                default:
                    return feature.GetFieldAsString(fieldIndex);
            }
        }
    }
}