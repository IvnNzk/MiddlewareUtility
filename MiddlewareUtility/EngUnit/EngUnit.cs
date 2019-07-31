namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    public delegate double ConvertFunction(double value);

    public delegate double RoundFunction(double value);

    public class EngUnit
    {
        private EngUnit _baseEngUnit;

        public EngUnit(ConvertFunction inputConvert, ConvertFunction outputConvert, RoundFunction roundFunction, EnterprisePropertyType type, string name)
        {
            InputConvertFunction = inputConvert;
            OutputConvertFunction = outputConvert;
            RoundFunction = roundFunction;
            Name = name;
            Type = type;
            _baseEngUnit = null;
            Restrictions = new List<Func<double, RestrictionCheckResult>>();
        }

        public EngUnit(ConvertFunction inputConvert, ConvertFunction outputConvert, RoundFunction roundFunction, EnterprisePropertyType type, string name, List<Func<double, RestrictionCheckResult>> restrictions)
        {
            InputConvertFunction = inputConvert;
            OutputConvertFunction = outputConvert;
            RoundFunction = roundFunction;
            Name = name;
            Type = type;
            _baseEngUnit = null;
            Restrictions = restrictions;
        }

        public EngUnit(ConvertFunction inputConvert, ConvertFunction outputConvert, RoundFunction roundFunction, EnterprisePropertyType type, string name, EngUnit baseEngUnit)
        {
            InputConvertFunction = inputConvert;
            OutputConvertFunction = outputConvert;
            RoundFunction = roundFunction;
            Name = name;
            Type = type;
            _baseEngUnit = baseEngUnit;
            Restrictions = new List<Func<double, RestrictionCheckResult>>();
        }

        public EngUnit(ConvertFunction inputConvert, ConvertFunction outputConvert, RoundFunction roundFunction, EnterprisePropertyType type, string name, EngUnit baseEngUnit, List<Func<double, RestrictionCheckResult>> restrictions)
        {
            InputConvertFunction = inputConvert;
            OutputConvertFunction = outputConvert;
            RoundFunction = roundFunction;
            Name = name;
            Type = type;
            _baseEngUnit = baseEngUnit;
            Restrictions = restrictions;
        }

        public EngUnit(EnterprisePropertyType type, string name, RoundFunction roundFunction, List<Func<double, RestrictionCheckResult>> restrictions)
        {
            InputConvertFunction = BaseEngUnitConvert;
            OutputConvertFunction = BaseEngUnitConvert;
            RoundFunction = roundFunction;
            Type = type;
            Name = name;
            Restrictions = restrictions;
        }

        public string BaseEngUnit
        {
            get
            {
                if (IsBase())
                {
                    return "Base EngUnit";
                }
                else
                {
                    return _baseEngUnit.Name;
                }
            }
        }

        public ConvertFunction InputConvertFunction { get; }
        public string Name { get; }
        public ConvertFunction OutputConvertFunction { get; }
        public List<Func<double, RestrictionCheckResult>> Restrictions { get; }
        public RoundFunction RoundFunction { get; }
        public EnterprisePropertyType Type { get; }

        public double CheckRestrictions(double value)
        {
            foreach (var restriction in Restrictions)
            {
                RestrictionCheckResult checkResult = restriction(value);
                if (!checkResult.IsGood)
                {
                    throw new EngUnitRestrictionException(checkResult.Message);
                }
            }

            return value;
        }

        public double InputConvert(double value)
        {
            return CheckRestrictions(InputConvertFunction(value));
        }

        public bool IsBase()
        {
            return null == _baseEngUnit;
        }

        public double OutputConvert(double value)
        {
            return RoundFunction(CheckRestrictions(OutputConvertFunction(value)));
        }

        private double BaseEngUnitConvert(double value)
        {
            return value;
        }
    }
}