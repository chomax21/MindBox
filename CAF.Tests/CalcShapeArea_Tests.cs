using Xunit;

namespace CAF.Tests
{
    public class CalcShapeArea_Tests 
    {
        [Fact]
        public void Calculated_Circle_Area()
        {
            //Arrange
            CalculatingAreaFigure caf = new();
            MyArguments arguments = new() { Radius = 8 };

            //Act
            double result = caf.ShapeType(EnumShape.Circle).SetArguments(arguments, out string figureType).Calculated();

            //Assert
            Assert.Equal(200.96, result);
            Assert.Equal("круг", figureType);
        }

        [Fact]
        public void Calculated_Circle_Area_NoSetFigureType()
        {
            //Arrange
            CalculatingAreaFigure caf = new();
            MyArguments arguments = new() { Radius = 8 };

            //Act
            double result = caf.SetArguments(arguments, out string figureType).Calculated();

            //Assert
            Assert.Equal(200.96, result);
            Assert.Equal("круг", figureType);
        }

        [Fact]
        public void Calculated_RightTriangle_Area()
        {
            //Arrange
            CalculatingAreaFigure caf = new();
            MyArguments arguments = new() { SideA = 3, SideB = 4, SideC = 5 };

            //Act
            double result = caf.ShapeType(EnumShape.Triangle).SetArguments(arguments, out string figureType).Calculated();

            //Assert
            Assert.Equal(6, result);
            Assert.Equal("прямоугольный треугольник", figureType);
        }

        [Fact]
        public void Calculated_Triangle_Area()
        {
            //Arrange
            CalculatingAreaFigure caf = new();
            MyArguments arguments = new() { SideA = 8, SideB = 6, SideC = 7 };

            //Act
            double result = caf.ShapeType(EnumShape.Triangle).SetArguments(arguments, out string figureType).Calculated();

            //Assert
            Assert.Equal(20.33, result);
            Assert.Equal("треугольник", figureType);
        }

        [Fact]
        public void Calculated_Triangle_Area_NoSetFigureType()
        {
            //Arrange
            CalculatingAreaFigure caf = new();
            MyArguments arguments = new() { SideA = 8, SideB = 6, SideC = 7 };

            //Act
            double result = caf.SetArguments(arguments, out string figureType).Calculated();

            //Assert
            Assert.Equal(20.33, result);
            Assert.Equal("треугольник", figureType);
        }
    }
}