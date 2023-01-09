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
            public override string ToString()
            {
                return $"Square : {{Side = {a}, Angle = {A}, Area = {GetArea()}}}";
            }
            public Area GetArea() => new Area(Pow(a, 2), (Units.Area)(int)a.Unit);
            private Square()
            {
                this.a = new(1,Units.Length.m);
            }
            static public Square FromSide(Length a)
            {
                Square sq = new();
                sq.a = a;
                return sq;
            }
            static public Square FromArea(Area area)
            {
                Square sq = new();
                sq.a = new(Sqrt(Abs(area.Value)), (Units.Length)(int)area.Unit);
                return sq;
            }
        }
    }
}