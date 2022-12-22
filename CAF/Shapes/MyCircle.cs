namespace CAF.Figures
{
    public class MyCircle : Shape
    {
        const double Pi = 3.14;
        double _radius;
        internal MyCircle(MyArguments arguments)
        {
            _radius = arguments.Radius;
        }

        internal override double GetArea()
        {
            var result = Math.Round(Math.Pow(_radius, 2) * Pi,2);
            return result;
        }
    }
}
