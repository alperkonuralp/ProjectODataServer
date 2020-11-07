using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjectODataServer.Tests
{
  public class ConvertersTests
  {
    public static IEnumerable<object[]> GetValuesForCheckBooleanValues()
    {
      yield return new object[] { null, null };
      yield return new object[] { 0, null };
      yield return new object[] { true, true };
      yield return new object[] { false, false };
      yield return new object[] { "true", true };
      yield return new object[] { "false", false };
    }


    [Theory]
    [MemberData(nameof(GetValuesForCheckBooleanValues))]
    public void GetBoolean_CheckTheValues(object request, bool? expected)
    {
      // act
      var result = Converters.GetBoolean(request);

      // Assert
      result.ShouldBe(expected);
    }


    public static IEnumerable<object[]> GetValuesForNullResponseForBoolean()
    {
      yield return new object[] { null };
      yield return new object[] { 0 };
      yield return new object[] { 1 };
      yield return new object[] { "" };
      yield return new object[] { " " };
      yield return new object[] { DateTime.Now };
      yield return new object[] { Guid.Empty };
    }

    public static IEnumerable<object[]> GetValuesForTrueResponseForBoolean()
    {
      yield return new object[] { true };
      yield return new object[] { "True" };
      yield return new object[] { "true" };
      yield return new object[] { "tRue" };
    }

    public static IEnumerable<object[]> GetValuesForFalseResponseForBoolean()
    {
      yield return new object[] { false };
      yield return new object[] { "False" };
      yield return new object[] { "false" };
      yield return new object[] { "fAlse" };
    }

    public static IEnumerable<object[]> GetValuesForNullResponseForInt32()
    {
      yield return new object[] { null };
      yield return new object[] { "" };
      yield return new object[] { " " };
      yield return new object[] { DateTime.Now };
      yield return new object[] { Guid.Empty };
    }

    [Theory]
    [MemberData(nameof(GetValuesForNullResponseForBoolean))]
    public void GetBoolean_Parameter_NullResponse(object o)
    {
      var a = Converters.GetBoolean(o);

      a.ShouldBeNull();
    }

    [Theory]
    [MemberData(nameof(GetValuesForTrueResponseForBoolean))]
    public void GetBoolean_Parameter_TrueResponse(object o)
    {
      var a = Converters.GetBoolean(o);

      a.ShouldBe(true);
    }

    [Theory]
    [MemberData(nameof(GetValuesForFalseResponseForBoolean))]
    public void GetBoolean_Parameter_FalseResponse(object o)
    {
      var a = Converters.GetBoolean(o);

      a.ShouldBe(false);
    }

    [Theory]
    [MemberData(nameof(GetValuesForNullResponseForInt32))]
    public void GetInt32_Parameter_NullResponse(object o)
    {
      var a = Converters.GetInt32(o);

      a.ShouldBeNull();
    }
  }
}