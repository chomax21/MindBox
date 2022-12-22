namespace CAF.Figures
{
    internal class MyTriangle : Shape
    {
        /// <summary>
        /// Сторона A.
        /// </summary>
        double _sideA;
        /// <summary>
        /// Сторона B.
        /// </summary>
        double _sideB;
        /// <summary>
        /// Сторона C.
        /// </summary>
        double _sideC;

        public MyTriangle(MyArguments arguments)
        {
            _sideA = arguments.SideA;
            _sideB = arguments.SideB;
            _sideC = arguments.SideC;
        }

        internal override double GetArea()
        {
            var p = (_sideA + _sideB + _sideC) / 2;
            var S = Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
            return Math.Round(S,2);
        }
    }
}
