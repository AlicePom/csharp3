namespace ToDoList.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(2, 2, 1)]
    public void Divide_withoutRemainder_Succeed(int dividend, int divisor, int expectedResult)
    {
        //Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Divide(dividend, divisor);

        // Assert
        Assert.Equal(expectedResult, result);
    }


    [Fact]
    public void DivideFloat_ByZero_ReturnsInfinity()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        //var divideAction = () => calculator.Divide(10, 0);
        //var divideAction = calculator.Divide(10, 0);

        // Assert
        //Assert.Equal(float.PositiveInfinity, divideAction);
        Assert.Equal(float.PositiveInfinity, calculator.Divide(10, 0));
    }

    [Fact]
    public void DivideInt_ByZero_ReturnsException()
    {
        // Arrange
        var calculatorInt = new CalculatorInt();

        // Act
        //var divideAction = () => calculatorInt.Divide(10, 0);

        // Assert
        Assert.Throws<DivideByZeroException>(() => calculatorInt.Divide(10, 0));
    }

// divide s floatem vrací nekonečno, s int vrací divide by null exception
}

public class Calculator
{
    public float Divide(float dividend, float divisor)
    {
        return dividend / divisor;
    }
}

public class CalculatorInt
{
    public int Divide(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}
