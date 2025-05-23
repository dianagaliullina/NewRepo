using NUnit.Framework;
using ComplexNumberStruct;

namespace ComplexNumberStruct.UnitTests
{
    [TestFixture]
    public class ComplexNumberTests
    {
        [Test]
        public void ConstructorTest()
        {
            var cn = new ComplexNumber(2.5, -3.7);
            Assert.That(cn.Re, Is.EqualTo(2.5));
            Assert.That(cn.Im, Is.EqualTo(-3.7));
        }

        [TestCase(3.0, 4.0, 5.0)]
        [TestCase(-3.0, -4.0, 5.0)]
        [TestCase(0.0, 0.0, 0.0)]
        public void AbsTest(double re, double im, double expected)
        {
            var cn = new ComplexNumber(re, im);
            Assert.That(cn.Abs, Is.EqualTo(expected).Within(1e-13));
        }

        [TestCase(2.5, 3.7, "2.5 + 3.7i")]
        [TestCase(2.5, -3.7, "2.5 - 3.7i")]
        [TestCase(0.0, 1.0, "i")]
        [TestCase(0.0, -1.0, "-i")]
        [TestCase(0.0, 2.0, "2i")]
        [TestCase(3.0, 0.0, "3")]
        [TestCase(0.0, 0.0, "0")]
        [TestCase(-2.5, 1.0, "-2.5 + i")]
        [TestCase(-2.5, -1.0, "-2.5 - i")]
        public void ToStringTest(double re, double im, string expected)
        {
            var cn = new ComplexNumber(re, im);
            Assert.That(cn.ToString(), Is.EqualTo(expected));
        }

        [TestCase(2.5, 3.7, 2.5, 3.7, true)]
        [TestCase(2.5, 3.7, 2.5, 3.8, false)]
        [TestCase(2.5, 3.7, 2.6, 3.7, false)]
        public void Equals_TwoComplexNumbers_ExpectedResult(
            double re1, double im1, double re2, double im2, bool expected)
        {
            var cn1 = new ComplexNumber(re1, im1);
            var cn2 = new ComplexNumber(re2, im2);
            Assert.That(cn1.Equals(cn2), Is.EqualTo(expected));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var cn = new ComplexNumber();
            var obj = new object();
            Assert.That(() => cn.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new ComplexNumber(2.5, 3.7);
            var y = new ComplexNumber(2.5, 3.7);
            var z = new ComplexNumber(2.5, 3.8);
            
            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new ComplexNumber(2.5, 3.7);
            var y = new ComplexNumber(2.5, 3.7);
            var z = new ComplexNumber(2.5, 3.8);
            
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [TestCase(2.5, 3.7, 1.2, -4.3, 3.7, -0.6)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        [TestCase(-2.5, -3.7, 1.2, 4.3, -1.3, 0.6)]
        public void AdditionTest(
            double re1, double im1, double re2, double im2, 
            double expectedRe, double expectedIm)
        {
            var cn1 = new ComplexNumber(re1, im1);
            var cn2 = new ComplexNumber(re2, im2);
            var result = new ComplexNumber(expectedRe, expectedIm);
            
            Assert.That(cn1 + cn2, Is.EqualTo(result));
        }

        [TestCase(2.5, 3.7, 1.2, -4.3, 1.3, 8.0)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        [TestCase(-2.5, -3.7, 1.2, 4.3, -3.7, -8.0)]
        public void SubtractionTest(
            double re1, double im1, double re2, double im2, 
            double expectedRe, double expectedIm)
        {
            var cn1 = new ComplexNumber(re1, im1);
            var cn2 = new ComplexNumber(re2, im2);
            var result = new ComplexNumber(expectedRe, expectedIm);
            
            Assert.That(cn1 - cn2, Is.EqualTo(result));
        }
    }
}