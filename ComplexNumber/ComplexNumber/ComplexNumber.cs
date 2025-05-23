using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ComplexNumberStruct
{
    public struct ComplexNumber
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public double Abs => Math.Sqrt(Re * Re + Im * Im);

        public ComplexNumber(double re, double im) : this()
        {
            Re = re;
            Im = im;
        }

        public override string ToString()
        {
            if (Re == 0 && Im == 0) return "0";

            if (Im == 0) return Re.ToString("G", CultureInfo.InvariantCulture);
            if (Re == 0) return FormatImaginaryPart(Im);

            string sign = Im > 0 ? " + " : " - ";
            return $"{Re.ToString("G", CultureInfo.InvariantCulture)}{sign}{FormatImaginaryPart(Math.Abs(Im))}";
        }

        private string FormatImaginaryPart(double value)
        {
            // Исправленная обработка случаев 1 и -1
            if (Math.Abs(value - 1) < 1e-13) return "i";
            if (Math.Abs(value + 1) < 1e-13) return "-i";
            return $"{value.ToString("G", CultureInfo.InvariantCulture)}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber other)
            {
                const double tolerance = 1e-13;
                return Math.Abs(Re - other.Re) < tolerance &&
                       Math.Abs(Im - other.Im) < tolerance;
            }
            throw new ArgumentException("Объект для сравнения не является комплексным числом");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int prime = 23;
                hash = hash * prime + Re.GetHashCode();
                hash = hash * prime + Im.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(ComplexNumber x, ComplexNumber y) => x.Equals(y);
        public static bool operator !=(ComplexNumber x, ComplexNumber y) => !x.Equals(y);

        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y) =>
            new ComplexNumber(x.Re + y.Re, x.Im + y.Im);

        public static ComplexNumber operator -(ComplexNumber x, ComplexNumber y) =>
            new ComplexNumber(x.Re - y.Re, x.Im - y.Im);
    }
}