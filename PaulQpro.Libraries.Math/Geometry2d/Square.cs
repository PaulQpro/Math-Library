using static PaulQpro.Math.Measures;
using static System.Math;
namespace PaulQpro.Math
{
    public partial class Geometry2d
    {
        public class Square
        {
            public Length a { get; set; }
            /// <summary>
            /// Angle of square, equal to 90° or π/2 radians
            /// </summary>
            public RightAngle A { get; } = new();
            private Area Area { get; set; }
            public override string ToString()
            {
                return $"Square : {{Side = {a}, Angle = {A}, Area = {Area}}}";
            }
            public Area GetArea() => Area;
            private Square()
            {
                this.a = new(1,Units.Length.m);
                this.Area = new(Pow(1, 2), Units.Area.m2);
            }
            static public Square FromSide(Length a)
            {
                Square sq = new();
                sq.a = a;
                sq.Area = new(Pow(a.Value, 2),(Units.Area)(int)a.Unit);
                return sq;
            }
            static public Square FromArea(Area area)
            {
                Square sq = new();
                sq.Area = area;
                sq.a = new(Sqrt(Abs(area.Value)), (Units.Length)(int)area.Unit);
                return sq;
            }
        }
    }
}