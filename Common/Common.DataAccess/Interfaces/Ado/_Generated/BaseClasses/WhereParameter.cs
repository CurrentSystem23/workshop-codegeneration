using System;
using System.Collections.Generic;
using System.Data;

namespace WorkshopTestProject.Common.DataAccess.Interfaces.Ado.BaseClasses
{
  public class WhereParameters
  {
    public  WhereParameters()
    {
      Parameters = new List<IWhereParameter>();
    }
    public List<IWhereParameter> Parameters { get; }
  }
  public class WhereClause : WhereParameters
  {
    public  WhereClause()
    : base()
    {
    }
    public  WhereClause(string where)
    : this()
    {
      Where = where;
    }
    public string Where { get; set; }
  }
  public interface IWhereParameter
  {
    string ParameterName { get; }
    SqlDbType ParameterType { get; }
    object ParameterValue { get; }
  }
  public interface IWhereParameterTyped<T> : IWhereParameter
  {
    T ParameterValueTyped { get; }
  }
  public abstract class WhereBaseParameter<T> : IWhereParameterTyped<T>
  {
    public  WhereBaseParameter(string parameterName, T parameterValue)
    {
      ParameterName = parameterName.StartsWith("@") ? parameterName : $"@{ parameterName}";
      ParameterValueTyped = parameterValue;
    }
    public T ParameterValueTyped { get; }
    public string ParameterName { get; }
    public abstract SqlDbType ParameterType { get; }
    public object ParameterValue => ParameterValueTyped;
  }
  public class WhereBoolParameter : WhereBaseParameter<bool>
  {
    public  WhereBoolParameter(string parameterName, bool parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Bit;
  }
  public class WhereByteParameter : WhereBaseParameter<byte>
  {
    public  WhereByteParameter(string parameterName, byte parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.TinyInt;
  }
  public class WhereShortParameter : WhereBaseParameter<short>
  {
    public  WhereShortParameter(string parameterName, short parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.SmallInt;
  }
  public class WhereIntParameter : WhereBaseParameter<int>
  {
    public  WhereIntParameter(string parameterName, int parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Int;
  }
  public class WhereLongParameter : WhereBaseParameter<long>
  {
    public  WhereLongParameter(string parameterName, long parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.BigInt;
  }
  public class WhereFloatParameter : WhereBaseParameter<float>
  {
    public  WhereFloatParameter(string parameterName, float parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Real;
  }
  public class WhereDoubleParameter : WhereBaseParameter<double>
  {
    public  WhereDoubleParameter(string parameterName, double parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Float;
  }
  public class WhereDecimalParameter : WhereBaseParameter<decimal>
  {
    public  WhereDecimalParameter(string parameterName, decimal parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Decimal;
  }
  public class WhereCharParameter : WhereBaseParameter<char>
  {
    public  WhereCharParameter(string parameterName, char parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Char;
  }
  public class WhereNCharParameter : WhereBaseParameter<char>
  {
    public  WhereNCharParameter(string parameterName, char parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.NChar;
  }
  public class WhereVarcharParameter : WhereBaseParameter<string>
  {
    public  WhereVarcharParameter(string parameterName, string parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.VarChar;
  }
  public class WhereNVarcharParameter : WhereBaseParameter<string>
  {
    public  WhereNVarcharParameter(string parameterName, string parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.NVarChar;
  }
  public class WhereTextParameter : WhereBaseParameter<string>
  {
    public  WhereTextParameter(string parameterName, string parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Text;
  }
  public class WhereXmlParameter : WhereBaseParameter<string>
  {
    public  WhereXmlParameter(string parameterName, string parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Xml;
  }
  public class WhereDateTimeParameter : WhereBaseParameter<DateTime>
  {
    public  WhereDateTimeParameter(string parameterName, DateTime parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.DateTime;
  }
  public class WhereDateTime2Parameter : WhereBaseParameter<DateTime>
  {
    public  WhereDateTime2Parameter(string parameterName, DateTime parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.DateTime2;
  }
  public class WhereDateTimeOffsetParameter : WhereBaseParameter<DateTimeOffset>
  {
    public  WhereDateTimeOffsetParameter(string parameterName, DateTimeOffset parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.DateTimeOffset;
  }
  public class WhereDateParameter : WhereBaseParameter<DateTime>
  {
    public  WhereDateParameter(string parameterName, DateTime parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Date;
  }
  public class WhereVarBinaryParameter : WhereBaseParameter<byte[]>
  {
    public  WhereVarBinaryParameter(string parameterName, byte[] parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.VarBinary;
  }
  public class WhereImageParameter : WhereBaseParameter<byte[]>
  {
    public  WhereImageParameter(string parameterName, byte[] parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.Image;
  }
  public class WhereUniqueIdentifierParameter : WhereBaseParameter<Guid>
  {
    public  WhereUniqueIdentifierParameter(string parameterName, Guid parameterValue)
    : base(parameterName, parameterValue)
    {
    }
    public override SqlDbType ParameterType => SqlDbType.UniqueIdentifier;
  }
}


