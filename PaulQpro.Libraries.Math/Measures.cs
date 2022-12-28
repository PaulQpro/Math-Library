using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulQpro.Math
{
    public static class Measures
    {
        static public class Units
        {
            public enum Length
            {
                meter,
                sMeter
            }
            public enum Angle
            {
                degree,
                radian
            }
            public enum Area
            {
                sq_meter,
                sq_sMeter
            }
        }

        public sealed class Length
        {
            public int Value { get; set; } = 0;
            public Units.Length Unit
            {
                get; set;
            } = Units.Length.meter;
            public override string ToString()
            {
                return $"{this.Value} {this.Unit}";
            }
        }
        public sealed class Angle
        {
            public int Value { get; set; } = 0;
            public Units.Angle Unit
            {
                get; set;
            } = Units.Angle.degree;
        }
    }
}
