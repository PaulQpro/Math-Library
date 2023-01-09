using System;
using static System.Math;

namespace PaulQpro.Math
{
    public static class Measures
    {
        static public class Units
        {
            public enum Length
            {
                m,
                sm
            }
            public enum Angle
            {
                dg,
                rad
            }
            public enum Area
            {
                m2,
                sm2
            }
        }

        public sealed class Length
        {
            private Units.Length _unit = Units.Length.m;


            public double Value { get; set; } = 0;
            public Units.Length Unit
            {
                get => _unit;
                set
                {
                    if (_unit == Units.Length.m && value == Units.Length.sm) Value *= 100;
                    else if (_unit == Units.Length.sm && value == Units.Length.m) Value /= 100;
                    _unit = value;
                }
            }
            public override string ToString()
            {
                return $"{this.Value} {this.Unit}";
            }
            public Length() { }
            public Length(double value, Units.Length unit)
            {
                Value = value;
                _unit = unit;
                Unit = unit;
            }
            static public Length operator + (Length a, Length b)
            {
                if(a.Unit == Units.Length.sm && b.Unit == Units.Length.sm)
                {
                    return new(a.Value + b.Value, Units.Length.sm);
                }
                else{
                    a.Unit = Units.Length.m;
                    b.Unit = Units.Length.m;
                    return new(a.Value + b.Value, Units.Length.m);
                }
            }
            static public implicit operator Length (double value) => new(value, Units.Length.m);
            static public implicit operator double (Length value) => value.Value;
        }
        public sealed class Angle
        {
            private Units.Angle _unit = Units.Angle.dg;
            public double Value { get; set; } = 0;
            public Units.Angle Unit
            {
                get => _unit;
                set
                {
                    if (_unit == Units.Angle.dg && value == Units.Angle.rad) Value = Value * PI / 180;
                    else if (_unit == Units.Angle.rad && value == Units.Angle.dg) Value = Value * 180 / PI;
                    _unit = value;
                }
            }
            public override string ToString()
            {
                if (_unit == Units.Angle.dg) return $"{Round(this.Value, 5)}°";
                else return $"{Round(this.Value,5)} {this.Unit}";
            }
            public Angle() { }
            public Angle(double value, Units.Angle unit)
            {
                Value = value;
                _unit = unit;
                Unit = unit;
            }
            /*static public Angle operator + (Angle a, Angle b)
            {
                
            }*/
            static public implicit operator Angle(RightAngle a) => new(a.Value, a.Unit);
            static public implicit operator Angle(double a) => new(a, Units.Angle.dg);
        }
        public sealed class RightAngle
        {
            private Units.Angle _unit = Units.Angle.dg;
            public double Value { get; private set; } = 90;
            public Units.Angle Unit
            {
                get => _unit;
                set
                {
                    if (_unit == Units.Angle.dg && value == Units.Angle.rad) Value = Value * PI / 180;
                    else if (_unit == Units.Angle.rad && value == Units.Angle.dg) Value = Value * 180 / PI;
                    _unit = value;
                }
            }
            public override string ToString()
            {
                if (_unit == Units.Angle.dg) return $"90°";
                else return $"{Round(this.Value, 5)} {this.Unit}";
            }
        }
        public sealed class Area
        {
            private Units.Area _unit = Units.Area.m2;

            public double Value { get; set; } = 0;
            public Units.Area Unit { 
                get => _unit; 
                set 
                {
                    if (_unit == Units.Area.m2 && value == Units.Area.sm2) Value *= 10000;
                    else if (_unit == Units.Area.sm2 && value == Units.Area.m2) Value /= 10000;
                    _unit = value; 
                } 
            }
            public override string ToString()
            {
                return $"{this.Value} {this.Unit}";
            }

            public Area()
            {
            }
            public Area(double value, Units.Area unit)
            {
                Value = value;
                Unit = unit;
            }
        }
    }
}