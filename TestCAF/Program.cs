using CAF;


CalculatingAreaFigure caf = new();
var param = new MyArguments
{
       SideA = 3, SideB = 4, SideC = 6
};
var result = caf.FigureType(EnumFigure.Circle).SetArguments(param, out string figureType)
                .Calculated();
Console.WriteLine($"Тип фигуры: {figureType}. Площадь равна {result}!");