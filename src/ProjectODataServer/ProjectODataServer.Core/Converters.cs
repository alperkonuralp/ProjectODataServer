using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectODataServer
{
  /// <summary>
  /// The Converter helper methods
  /// </summary>
  public static class Converters
  {
    /// <summary>
    /// Gets the boolean value
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Boolean? GetBoolean(object data)
    {
      if (data == null) return null;
      if (data is Boolean d) return d;
      if (Boolean.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the byte.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Byte? GetByte(object data)
    {
      if (data == null) return null;
      if (data is Byte d) return d;
      if (Byte.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the s byte.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static SByte? GetSByte(object data)
    {
      if (data == null) return null;
      if (data is SByte d) return d;
      if (SByte.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the int32.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Int32? GetInt32(object data)
    {
      if (data == null) return null;
      if (data is Int32 d) return d;
      if (Int32.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the u int32.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static UInt32? GetUInt32(object data)
    {
      if (data == null) return null;
      if (data is UInt32 d) return d;
      if (UInt32.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the int16.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Int16? GetInt16(object data)
    {
      if (data == null) return null;
      if (data is Int16 d) return d;
      if (Int16.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the u int16.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static UInt16? GetUInt16(object data)
    {
      if (data == null) return null;
      if (data is UInt16 d) return d;
      if (UInt16.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the int64.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Int64? GetInt64(object data)
    {
      if (data == null) return null;
      if (data is Int64 d) return d;
      if (Int64.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the u int64.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static UInt64? GetUInt64(object data)
    {
      if (data == null) return null;
      if (data is UInt64 d) return d;
      if (UInt64.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the single.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Single? GetSingle(object data)
    {
      if (data == null) return null;
      if (data is Single d) return d;
      if (Single.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the double.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Double? GetDouble(object data)
    {
      if (data == null) return null;
      if (data is Double d) return d;
      if (Double.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the decimal.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Decimal? GetDecimal(object data)
    {
      if (data == null) return null;
      if (data is Decimal d) return d;
      if (Decimal.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the date time.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static DateTime? GetDateTime(object data)
    {
      if (data == null) return null;
      if (data is DateTime d) return d;
      if (DateTime.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the date time offset.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static DateTimeOffset? GetDateTimeOffset(object data)
    {
      if (data == null) return null;
      if (data is DateTimeOffset d) return d;
      if (DateTimeOffset.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the time span.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static TimeSpan? GetTimeSpan(object data)
    {
      if (data == null) return null;
      if (data is TimeSpan d) return d;
      if (TimeSpan.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the GUID.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static Guid? GetGuid(object data)
    {
      if (data == null) return null;
      if (data is Guid d) return d;
      if (Guid.TryParse(data.ToString(), out d))
        return d;
      return null;
    }

    /// <summary>
    /// Gets the string.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static String GetString(object data)
    {
      if (data == null) return null;
      if (data is String d) return d;
      return data.ToString();
    }

    /// <summary>
    /// Gets the enum.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumData">The enum data.</param>
    /// <returns></returns>
    public static TEnum? GetEnum<TEnum>(object enumData)
      where TEnum : struct
    {
      if (enumData == null) return null;
      if (enumData is TEnum enumValue) return enumValue;
      if (Enum.TryParse(enumData.ToString(), out enumValue))
        return enumValue;
      return null;
    }

    /// <summary>
    /// Sets to the target if this is not null.
    /// </summary>
    /// <typeparam name="T">The generic type parameter for source and target type.</typeparam>
    /// <param name="nullable">The source nullable object.</param>
    /// <param name="target">The target object.</param>
    public static void SetToIfThisIsNotNull<T>(this T? nullable, ref T target)
      where T : struct
    {
      if (nullable.HasValue)
      {
        target = nullable.Value;
      }
    }

    /// <summary>
    /// Sets to the target if this is not null.
    /// </summary>
    /// <typeparam name="T">The generic type parameter for source and target type.</typeparam>
    /// <param name="nullable">The source nullable object.</param>
    /// <param name="target">The target object.</param>
    public static void SetToIfThisIsNotNull<T>(this T? nullable, ref T? target)
      where T : struct
    {
      if (nullable.HasValue)
      {
        target = nullable.Value;
      }
    }
  }
}
