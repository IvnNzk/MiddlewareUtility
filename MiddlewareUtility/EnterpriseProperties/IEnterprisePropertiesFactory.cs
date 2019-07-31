namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Types;
    using System;
    using System.Collections.Generic;

    internal interface IEnterprisePropertiesFactory
    {
        bool CheckNumberPoint(IPoint point);

        bool CheckStringPoint(IPoint point);

        INumericPoint GetConcentration(string pointName, DateTime executionTime);

        INumericPoint GetConcentration(string pointName);

        INumericPoint GetDensity(string pointName, DateTime executionTime);

        INumericPoint GetDensity(string pointName);

        INumericPoint GetLevel(string pointName, DateTime executionTime);

        INumericPoint GetLevel(string pointName);

        INumericPoint GetMass(string pointName, DateTime executionTime);

        INumericPoint GetMass(string pointName);

        INumericPoint GetMassFlow(string pointName, DateTime executionTime);

        INumericPoint GetMassFlow(string pointName);

        INumericPoint GetPressure(string pointName, DateTime executionTime);

        INumericPoint GetPressure(string pointName);

        IStringPoint GetState(string pointName, List<string> badStates, DateTime executionTime);

        IStringPoint GetState(string pointName, List<string> badStates);

        INumericPoint GetTemperature(string pointName, DateTime executionTime);

        INumericPoint GetTemperature(string pointName);

        INumericPoint GetTolerance(string pointName, DateTime executionTime);

        INumericPoint GetTolerance(string pointName);

        INumericPoint GetVolume(string pointName, DateTime executionTime);

        INumericPoint GetVolume(string pointName);

        INumericPoint GetVolumeFlow(string pointName, DateTime executionTime);

        INumericPoint GetVolumeFlow(string pointName);
    }
}