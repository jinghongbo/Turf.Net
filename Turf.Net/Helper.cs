using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;

namespace Turf.Net
{
    public static partial class Turf
    {

        public static double EarthRadius = 6371008.8;

        public static Dictionary<Units, double> Factors = new Dictionary<Units, double>()
        {
            { Units.Centimeters, EarthRadius * 100},
            { Units.Degrees, EarthRadius / 111325},
            { Units.Feet, EarthRadius * 3.28084},
            { Units.Inches, EarthRadius * 39.37},
            { Units.Kilometers, EarthRadius / 1000},
            { Units.Meters, EarthRadius},
            { Units.Miles, EarthRadius / 1609.344},
            { Units.Millimeters, EarthRadius * 1000},
            { Units.Nauticalmiles, EarthRadius / 1852},
            { Units.Radians, 1},
            { Units.Yards, EarthRadius / 1.0936},
        };


        public static Dictionary<Units, double> UnitsFactors = new Dictionary<Units, double>()
        {
            { Units.Centimeters, 100},
            { Units.Degrees, 1 / 111325},
            { Units.Feet, 3.28084},
            { Units.Inches, 39.37},
            { Units.Kilometers, 1 / 1000},
            { Units.Meters, 1},
            { Units.Miles, 1 / 1609.344},
            { Units.Millimeters, 1000},
            { Units.Nauticalmiles, 1 / 1852},
            { Units.Radians, 1 / EarthRadius},
            { Units.Yards, 1 / 1.0936},

        };


        public static Dictionary<Units, double> AreaFactors = new Dictionary<Units, double>()
        {
             {Units.Acres, 0.000247105},
             {Units.Centimeters, 10000},
             {Units.Feet, 10.763910417},
             {Units.Hectares, 0.0001},
             {Units.Inches, 1550.003100006},
             {Units.Kilometers, 0.000001},
             {Units.Meters, 1},
             {Units.Miles, 3.86e-7},
             {Units.Millimeters, 1000000},
             {Units.Yards, 1.195990046},

        };
        public static double Round(double number, int precision = 0)
        {
            return Math.Round(number, precision);
        }

        public static double RadiansToLength(double radians, Units units = Units.Kilometers)
        {
            return radians * Factors[units];
        }

        public static double LengthToRadians(double length, Units units = Units.Kilometers)
        {
            return length / Factors[units];
        }

        public static double LengthToDegrees(double length, Units units = Units.Kilometers)
        {
            return RadiansToDegrees(LengthToRadians(length, units));
        }
        public static double BearingToAzimuth(double bearing)
        {
            var angle = bearing % 360;
            if (angle < 0)
            {
                angle += 360;
            }
            return angle;
        }

        public static double RadiansToDegrees(double radians)
        {
            return Radians.ToDegrees(radians);

        }

        public static double DegreesToRadians(double degrees)
        {
            return Degrees.ToRadians(degrees);
        }

        public static double ConvertLength(double length, Units originalUnits, Units finalUnits)
        {
            return RadiansToLength(LengthToRadians(length, originalUnits), finalUnits);
        }

        public static double ConvertArea(double area, Units originalUnits, Units finalUnits)
        {
            var startFactor = AreaFactors[originalUnits];
            var finalFactor = AreaFactors[finalUnits];
            return (area / startFactor) * finalFactor;
        }
    }

}
