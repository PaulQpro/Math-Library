using static System.Math;
using PaulQpro.Math.Measures;

namespace PaulQpro.Math.Geometry2d
{
    public class Square
    {
        public Length Side { get; set; }
        /// <summary>
        /// Angle of square, equal to 90° or π/2 radians
        /// </summary>
        public RightAngle Angle { get; } = new();
        public override string ToString()
        {
            return $"Square : {{Side = {Side}, Angle = {Angle}, Area = {Area()}}}";
        }
        public Area Area() => new(Pow(Side, 2), (Units.Area)(int)Side.Unit);
        public Area Area(Units.Area unit) 
        { 
            Area area =  new(Pow(Side, 2), (Units.Area)(int)Side.Unit); 
            area.Unit = unit; return area;
        }
        private Square()
        {
            this.Side = new(1,Units.Length.m);
        }
        static public Square FromSide(Length a)
        {
            Square sq = new();
            sq.Side = a;
            return sq;
        }
        static public Square FromArea(Area area)
        {
            Square sq = new();
            sq.Side = new(Sqrt(Abs(area.Value)), (Units.Length)(int)area.Unit);
            return sq;
        }
    }
}