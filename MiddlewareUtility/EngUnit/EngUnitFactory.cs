namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class EngUnitFactory
    {
        private IUtilityLogger _logger;

        public EngUnitFactory()
        {
            _logger = new DefaultLogger();
        }

        public EngUnitFactory(IUtilityLogger logger)
        {
            _logger = logger;
        }

        public EngUnit GetEngUnit(EnterprisePropertyType type, string engUnitName)
        {
            switch (type)
            {
                case EnterprisePropertyType.DENSITY:
                    return GetDensityEU(engUnitName);

                case EnterprisePropertyType.LEVEL:
                    return GetLevelEU(engUnitName);

                case EnterprisePropertyType.MASSFLOW:
                    return GetMassFlowEU(engUnitName);

                case EnterprisePropertyType.PRESSURE:
                    return GetPressureEU(engUnitName);

                case EnterprisePropertyType.TEMPERATURE:
                    return GetTemperatureEU(engUnitName);

                case EnterprisePropertyType.VOLUMEFLOW:
                    return GetVolumeFlowEU(engUnitName);

                case EnterprisePropertyType.VOLUME:
                    return GetVolumeEU(engUnitName);

                case EnterprisePropertyType.MASS:
                    return GetMassEU(engUnitName);

                case EnterprisePropertyType.CONCENTRATION:
                    return GetConcentrationEU(engUnitName);

                case EnterprisePropertyType.TOLERANCE:
                    return GetToleranceEU();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static RestrictionCheckResult CheckLowestTemperature(double value)
        {
            if (value < -273)
            {
                return new RestrictionCheckResult("Temperature value cannot be lower than -273");
            }
            return new RestrictionCheckResult();
        }

        private static RestrictionCheckResult CheckZero(double value)
        {
            if (value < 0)
            {
                return new RestrictionCheckResult("Pressure value cannot be lower than zero");
            }
            return new RestrictionCheckResult();
        }

        #region Pressure

        private static Lazy<List<Func<double, RestrictionCheckResult>>> pressureRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _basePressureEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.PRESSURE, "Па", PressureRound, pressureRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetPressureEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "бар":
                    return InitBarEngUnit();

                case "атм":
                    return InitAtmEngUnit();

                case "кгс/м2":
                    return InitKgsM2EngUnit();

                case "кгс/мм2":
                    return InitKgsmm2EngUnit();

                case "кг/см2":
                case "кгс/cм2":
                    return InitKgsCm2EngUnit();

                case "па":
                    return _basePressureEU.Value;

                case "мпа":
                    return InitMPaEngUnit();

                case "кпа":
                    return InitKPaEngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitAtmEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 101325;

            ConvertFunction OutputConvert = (value) => value / 101325;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "атм", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitBarEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 100000;

            ConvertFunction OutputConvert = (value) => value * 0.00001;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "бар", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitKgsCm2EngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 98066.501248092347;

            ConvertFunction OutputConvert = (value) => value / 98066.501248092347;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "кгс/см2", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitKgsM2EngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 9.8066501248092344;

            ConvertFunction OutputConvert = (value) => value / 9.8066501248092344;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "кгс/м2", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitKgsmm2EngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 9806650.1248092353;

            ConvertFunction OutputConvert = (value) => value / 9806650.1248092353;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "кгс/мм2", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitKPaEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000;

            ConvertFunction OutputConvert = (value) => value / 1000;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "кПа", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static EngUnit InitMPaEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000000;

            ConvertFunction OutputConvert = (value) => value / 1000000;

            return new EngUnit(InputConvert, OutputConvert, PressureRound, EnterprisePropertyType.PRESSURE, "МПа", _basePressureEU.Value, pressureRestrictions.Value);
        }

        private static double PressureRound(double value) => Math.Round(value, 2);

        #endregion Pressure

        #region Temperature

        private static Lazy<List<Func<double, RestrictionCheckResult>>> temperatureRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () =>
            {
                return new List<Func<double, RestrictionCheckResult>>
                {
                    CheckLowestTemperature
                };
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseTemperatureEU =
            new Lazy<EngUnit>(
                () => new EngUnit(EnterprisePropertyType.TEMPERATURE, "С", TemperatureRound, temperatureRestrictions.Value)
                , LazyThreadSafetyMode.PublicationOnly);

        private static double TemperatureRound(double value) => Math.Round(value, 1);

        private EngUnit GetTemperatureEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "c":
                case "с":
                    return _baseTemperatureEU.Value;

                case "k":
                case "к":
                    return InitKEngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private EngUnit InitKEngUnit()
        {
            ConvertFunction InputConvert = (value) => value - 273.15;

            ConvertFunction OutputConvert = (value) => value + 273.15;

            return new EngUnit(InputConvert, OutputConvert, TemperatureRound, EnterprisePropertyType.TEMPERATURE, "К", _baseTemperatureEU.Value, temperatureRestrictions.Value);
        }

        #endregion Temperature

        #region VolumeFlow

        private static Lazy<List<Func<double, RestrictionCheckResult>>> volumeFlowRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseVolumeFlowEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.VOLUMEFLOW, "м3/ч", VolumeFlowRound, volumeFlowRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetVolumeFlowEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "м3":
                case "м3/ч":
                case "м3/час":
                    return _baseVolumeFlowEU.Value;

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static double VolumeFlowRound(double value) => Math.Round(value, 3);

        #endregion VolumeFlow

        #region MassFlow

        private static Lazy<List<Func<double, RestrictionCheckResult>>> massFlowRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseMassFlowEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.MASSFLOW, "т/ч", MassFlowRound, massFlowRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetMassFlowEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "т":
                case "т/ч":
                    return _baseMassFlowEU.Value;

                case "кг":
                case "кг/ч":
                    return InitKgHEngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitKgHEngUnit()
        {
            ConvertFunction InputConvert = (value) => value / 1000;

            ConvertFunction OutputConvert = (value) => value * 1000;

            return new EngUnit(InputConvert, OutputConvert, MassFlowRound, EnterprisePropertyType.MASSFLOW, "т/ч", _baseMassFlowEU.Value, massFlowRestrictions.Value);
        }

        private static double MassFlowRound(double value) => Math.Round(value, 3);

        #endregion MassFlow

        #region Level

        private static Lazy<List<Func<double, RestrictionCheckResult>>> levelRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseLevelEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.LEVEL, "мм", LevelRound, levelRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetLevelEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "%":
                case "мм":
                    return _baseLevelEU.Value;

                case "см":
                    return InitCmEngUnit();

                case "м":
                    return InitMEngUnit();

                case "км":
                    return InitKmEngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitCmEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 10;

            ConvertFunction OutputConvert = (value) => value / 10;

            return new EngUnit(InputConvert, OutputConvert, LevelRound, EnterprisePropertyType.LEVEL, "см", _baseLevelEU.Value, levelRestrictions.Value);
        }

        private static EngUnit InitKmEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000000;

            ConvertFunction OutputConvert = (value) => value / 1000000;

            return new EngUnit(InputConvert, OutputConvert, LevelRound, EnterprisePropertyType.LEVEL, "км", _baseLevelEU.Value, levelRestrictions.Value);
        }

        private static EngUnit InitMEngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000;

            ConvertFunction OutputConvert = (value) => value / 1000;

            return new EngUnit(InputConvert, OutputConvert, LevelRound, EnterprisePropertyType.LEVEL, "м", _baseLevelEU.Value, levelRestrictions.Value);
        }

        private static double LevelRound(double value) => Math.Round(value, 1);

        #endregion Level

        #region Density

        private static Lazy<List<Func<double, RestrictionCheckResult>>> densityRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseDensityEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.DENSITY, "кг/м3", DensityRound, densityRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static double DensityRound(double value) => Math.Round(value, 1);

        private static EngUnit GetDensityEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "кг/м3":
                    return _baseDensityEU.Value;

                case "г/см3":
                    return InitGCm3EngUnit();

                case "кг/см3":
                    return InitKgCm3EngUnit();

                case "г/м3":
                    return InitGM3EngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitGCm3EngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000;

            ConvertFunction OutputConvert = (value) => value / 1000;

            return new EngUnit(InputConvert, OutputConvert, DensityRound, EnterprisePropertyType.DENSITY, "г/см3", _baseDensityEU.Value, densityRestrictions.Value);
        }

        private static EngUnit InitGM3EngUnit()
        {
            ConvertFunction InputConvert = (value) => value / 1000;

            ConvertFunction OutputConvert = (value) => value * 1000;

            return new EngUnit(InputConvert, OutputConvert, DensityRound, EnterprisePropertyType.DENSITY, "г/м3", _baseDensityEU.Value, densityRestrictions.Value);
        }

        private static EngUnit InitKgCm3EngUnit()
        {
            ConvertFunction InputConvert = (value) => value * 1000000;

            ConvertFunction OutputConvert = (value) => value / 1000000;

            return new EngUnit(InputConvert, OutputConvert, DensityRound, EnterprisePropertyType.DENSITY, "кг/см3", _baseDensityEU.Value, densityRestrictions.Value);
        }

        #endregion Density

        #region Concentration

        private static Lazy<List<Func<double, RestrictionCheckResult>>> concentrationRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseConcentrationEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.CONCENTRATION, "%", ConcentrationRound, concentrationRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static double ConcentrationRound(double value) => Math.Round(value, 1);

        private static EngUnit GetConcentrationEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "%":
                    return _baseConcentrationEU.Value;

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        #endregion Concentration

        #region Volume

        private static Lazy<List<Func<double, RestrictionCheckResult>>> volumeRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseVolumeEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.VOLUME, "м3", VolumeRound, volumeRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetVolumeEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "м3":

                    return _baseVolumeEU.Value;

                case "см3":
                    return InitCm3EngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitCm3EngUnit()
        {
            ConvertFunction InputConvert = (value) => value / 1000000;

            ConvertFunction OutputConvert = (value) => value * 1000000;

            return new EngUnit(InputConvert, OutputConvert, VolumeRound, EnterprisePropertyType.VOLUME, "см3", _baseVolumeEU.Value, volumeRestrictions.Value);
        }

        private static double VolumeRound(double value) => Math.Round(value, 3);

        #endregion Volume

        #region Mass

        private static Lazy<List<Func<double, RestrictionCheckResult>>> massRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseMassEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.MASS, "т", MassRound, massRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetMassEU(string engUnitName)
        {
            switch (engUnitName.Trim().ToLower().RemoveSpecialCharacters())
            {
                case "т":
                    return _baseMassEU.Value;

                case "кг":
                    return InitKgEngUnit();

                case "г":
                    return InitGEngUnit();

                default:
                    throw new EngUnitNotFoundException();
            }
        }

        private static EngUnit InitGEngUnit()
        {
            ConvertFunction InputConvert = (value) => value / 1000000;

            ConvertFunction OutputConvert = (value) => value * 1000000;

            return new EngUnit(InputConvert, OutputConvert, MassRound, EnterprisePropertyType.MASS, "г", _baseMassEU.Value, massRestrictions.Value);
        }

        private static EngUnit InitKgEngUnit()
        {
            ConvertFunction InputConvert = (value) => value / 1000;

            ConvertFunction OutputConvert = (value) => value * 1000;

            return new EngUnit(InputConvert, OutputConvert, MassRound, EnterprisePropertyType.MASS, "кг", _baseMassEU.Value, massRestrictions.Value);
        }

        private static double MassRound(double value) => Math.Round(value, 3);

        #endregion Mass

        #region Tolerance

        private static Lazy<List<Func<double, RestrictionCheckResult>>> toleranceRestrictions = new Lazy<List<Func<double, RestrictionCheckResult>>>
        (
            () => new List<Func<double, RestrictionCheckResult>>
            {
                CheckZero
            }, LazyThreadSafetyMode.PublicationOnly
        );

        private static Lazy<EngUnit> _baseToleranceEU = new Lazy<EngUnit>(() => new EngUnit(EnterprisePropertyType.TOLERANCE, "", ToleranceRound, toleranceRestrictions.Value), LazyThreadSafetyMode.PublicationOnly);

        private static EngUnit GetToleranceEU()
        {
            return _baseToleranceEU.Value;
        }

        private static double ToleranceRound(double value) => Math.Round(value, 3);

        #endregion Tolerance
    }
}