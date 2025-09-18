namespace UnitTestingLib
{
    public class MathClass
    {
        public double AddFunc(double a, double b)
        {
            return a + b;
        }

        public double SubtractFunc(double a, double b)
        {
            return a - b;
        }

        public double MultiplyFunc(double a, double b)
        {
            return a * b;
        }

        public double DivideFunc(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            return a / b;
        }
        public double SquareFunc(double a)
        {
            return a * a;
        }

        public double SquareRootFunc(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Cannot compute square root of a negative number.");
            }
            return Math.Sqrt(a);
        }
    }
}
