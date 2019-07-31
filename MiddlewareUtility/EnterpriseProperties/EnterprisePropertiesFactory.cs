namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Tools;
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    public class EnterprisePropertiesFactory : IEnterprisePropertiesFactory, IPointFactory
    {
        protected IUtilityLogger _logger;
        private static string MessageForNotImplementedException = "U should use implemented";
        private EngUnitFactory _engUnitFactory;

        protected EnterprisePropertiesFactory()
        {
            _logger = new DefaultLogger();
            this._engUnitFactory = new EngUnitFactory(_logger);
        }

        protected EnterprisePropertiesFactory(IUtilityLogger logger)
        {
            _logger = logger;
            this._engUnitFactory = new EngUnitFactory(_logger);
        }

        public bool CheckNumberPoint(IPoint point)
        {
            return point.PointValueType == typeof(double);
        }

        public bool CheckStringPoint(IPoint point)
        {
            return point.PointValueType == typeof(string);
        }

        public INumericPoint GetConcentration(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.CONCENTRATION, point.EngUnit), EnterprisePropertyType.CONCENTRATION, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetConcentration(string pointName)
        {
            return GetConcentration(pointName, DateTime.Now);
        }

        public INumericPoint GetDensity(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.DENSITY, point.EngUnit), EnterprisePropertyType.DENSITY, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetDensity(string pointName)
        {
            return GetDensity(pointName, DateTime.Now);
        }

        public INumericPoint GetLevel(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.LEVEL, point.EngUnit), EnterprisePropertyType.LEVEL, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetLevel(string pointName)
        {
            return GetLevel(pointName, DateTime.Now);
        }

        public INumericPoint GetMass(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.MASS, point.EngUnit), EnterprisePropertyType.MASS, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetMass(string pointName)
        {
            return GetMass(pointName, DateTime.Now);
        }

        public INumericPoint GetMassFlow(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.MASSFLOW, point.EngUnit), EnterprisePropertyType.MASSFLOW, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetMassFlow(string pointName)
        {
            return GetMassFlow(pointName, DateTime.Now);
        }

        public virtual IPoint GetPoint(string name)
        {
            throw new NotImplementedException();
        }

        public INumericPoint GetPressure(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.PRESSURE, point.EngUnit), EnterprisePropertyType.PRESSURE, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetPressure(string pointName)
        {
            return GetPressure(pointName, DateTime.Now);
        }

        public IStringPoint GetState(string pointName, List<string> badStates, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckStringPoint(point))
            {
                return new StateProperty(point, EnterprisePropertyType.STATE, executionTime, badStates);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public IStringPoint GetState(string pointName, List<string> badStates)
        {
            return GetState(pointName, badStates, DateTime.Now);
        }

        public INumericPoint GetTemperature(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.TEMPERATURE, point.EngUnit), EnterprisePropertyType.TEMPERATURE, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetTemperature(string pointName)
        {
            return GetTemperature(pointName, DateTime.Now);
        }

        public INumericPoint GetTolerance(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.TOLERANCE, point.EngUnit), EnterprisePropertyType.TOLERANCE, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetTolerance(string pointName)
        {
            return GetTolerance(pointName, DateTime.Now);
        }

        public INumericPoint GetVolume(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.VOLUME, point.EngUnit), EnterprisePropertyType.VOLUME, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetVolume(string pointName)
        {
            return GetVolume(pointName, DateTime.Now);
        }

        public INumericPoint GetVolumeFlow(string pointName, DateTime executionTime)
        {
            var point = GetPoint(pointName);

            if (CheckNumberPoint(point))
            {
                return new PhysicalProperty(point, _engUnitFactory.GetEngUnit(EnterprisePropertyType.VOLUMEFLOW, point.EngUnit), EnterprisePropertyType.VOLUMEFLOW, executionTime);
            }
            else
            {
                throw new PointValueTypeException();
            }
        }

        public INumericPoint GetVolumeFlow(string pointName)
        {
            return GetVolumeFlow(pointName, DateTime.Now);
        }
    }
}