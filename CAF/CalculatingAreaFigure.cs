using CAF.Figures;

namespace CAF
{
    public class CalculatingAreaFigure
    {
        // Хранит вид фигуры.
        private EnumShape _enumFigure;

        // Хранит сам тип фигуры.
        private Shape? shape;

        /// <summary>
        /// Вызывается первым в цепочке. Определяется фигура для которой будет происходить расчет площади.
        /// </summary>
        /// <param name="enumFigure"></param>
        /// <returns>CalculatingAreaFigure</returns>
        public CalculatingAreaFigure ShapeType(EnumShape enumShape)
        {
            _enumFigure = enumShape;
            return this;
        }

        /// <summary>
        /// Вызывается вторым. Передаются параметры в отдельный класс оболочку MyArguments для расчета площади.
        /// В случае если пропущен первый этап и не выбран тип фигуры, метод попытается определить это по переданным параметрам.
        /// </summary>
        /// <param name="myArguments"></param>
        /// <param name="figureType"></param>
        /// <returns>CalculatingAreaFigure</returns>
        /// <exception cref="ArgumentException"></exception>
        public CalculatingAreaFigure SetArguments(MyArguments myArguments, out string figureType)
        {
            if (_enumFigure == 0)
            {
                if (myArguments.Radius > 0.0)
                    _enumFigure = EnumShape.Circle;

                if (myArguments.Radius == 0.0 && myArguments.SideA > 0.0 && myArguments.SideB > 0.0 && myArguments.SideC > 0.0)
                    _enumFigure = EnumShape.Triangle;
            }

            switch (_enumFigure)
            {
                case EnumShape.Circle:
                    if (myArguments.Radius == 0.0) throw new ArgumentException("invalid arguments!");

                    shape = new MyCircle(myArguments);
                    figureType = "круг";
                    return this;

                case EnumShape.Triangle:
                    if (myArguments.SideA == 0.0 || myArguments.SideB == 0.0 || myArguments.SideC == 0.0) throw new ArgumentException("invalid arguments!");

                    var powSideA = Math.Pow(myArguments.SideA, 2);
                    var powSideB = Math.Pow(myArguments.SideB, 2);
                    var powSideC = Math.Pow(myArguments.SideC, 2); 

                    if (powSideA + powSideB == powSideC || powSideA + powSideC == powSideB || powSideB + powSideC == powSideA)                   
                        figureType = "прямоугольный треугольник";                    
                    else
                        figureType = "треугольник";

                    shape = new MyTriangle(myArguments);
                    return this;   
                    
                default:
                    throw new ArgumentException("unknown figureType!");
            }
        }

        /// <summary>
        /// Финальный метод подсчета площади.
        /// </summary>
        /// <returns>double</returns>
        /// <exception cref="NullReferenceException"></exception>
        public double Calculated()
        {
            if (shape != null)
            {
                return shape.GetArea();
            }
            throw new NullReferenceException(message: "Lost figure type!");
        }
    }
}
