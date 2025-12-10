using System;
using System.Windows.Forms;


namespace ComplexNumbers
{
    public class ComplexNumber
    {
        private double real;
        private double imaginary;

        public ComplexNumber()
        {
            real = 0;
            imaginary = 0;
        }
        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public void Input(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public string CreateStringNumber ()
        {
            if (imaginary >= 0)
                return $"z = {real} + {imaginary}i";
            else 
                return $"z = {real} - {Math.Abs(imaginary)}i";
        }

        public ComplexNumber Power(int n)
        {
            double r = Math.Sqrt(real * real + imaginary * imaginary);
            double phi = Math.Atan2(imaginary, real);

            double rPow = Math.Pow(r, n);
            double newPhi = n * phi;

            double newReal = rPow * Math.Cos(newPhi);
            double newImaginary = rPow * Math.Sin(newPhi);

            return new ComplexNumber(newReal, newImaginary);
        }

        public double Real
        {
            get { return real; }
            set {  real = value; }
        }

        public double Imaginary
        {
            get { return imaginary; }
            set { imaginary = value; }
        }
    }
}
