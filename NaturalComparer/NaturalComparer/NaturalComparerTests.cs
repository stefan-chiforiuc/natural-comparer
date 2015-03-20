using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NaturalComparer
{
    [TestClass]
    public class GivenNaturalComparer
    {
        private NaturalComparer<string> _sut;

        [TestInitialize]
        public void Initializer()
        {
            _sut = new NaturalComparer<string>();
        }

        [TestMethod]
        public void WhenLeftBelowRight_ThenReturnOne()
        {
            var compare = _sut.Compare("water 11", "water 2");
            Assert.AreEqual(compare, 1);
        }

        [TestMethod]
        public void WhenRightBelowLeft_ThenReturnMinusOne()
        {
            var compare = _sut.Compare("water 1", "water 2");
            Assert.AreEqual(compare, -1);
        }

        [TestMethod]
        public void WhenRightEqualLeft_ThenReturnZero()
        {
            var compare = _sut.Compare("water 1", "water 1");
            Assert.AreEqual(compare, 0);
        }

        [TestMethod]
        public void WhenLeftBelowRightUpperCaseIgnored_ThenReturnOne()
        {
            var compare = _sut.Compare("water 11", "Water 2");
            Assert.AreEqual(compare, 1);
        }

        [TestMethod]
        public void WhenLeftIsNull_ThenReturnMinusOne()
        {
            var compare = _sut.Compare(null, "Water 2");
            Assert.AreEqual(compare, -1);
        }

        [TestMethod]
        public void WhenRightIsNull_ThenReturnOne()
        {
            var compare = _sut.Compare("test", null);
            Assert.AreEqual(compare, 1);
        }

        [TestMethod]
        public void WhenRightIsNullAndLeftIsNull_ThenReturnZero()
        {
            var compare = _sut.Compare(null, null);
            Assert.AreEqual(compare, 0);
        }

        [TestMethod]
        public void WhenLeftBelowRightExampleClass_ThenReturnOne()
        {
            var sensorViewModelLeft =
                new ExampleClass { Name = "temperature sensor 11" };
            var sensorViewModelRight =
                new ExampleClass { Name = "temperature sensor 2" };
            var sut = new NaturalComparer<ExampleClass>();

            var compare = sut.Compare(sensorViewModelLeft, sensorViewModelRight);

            Assert.AreEqual(compare, 1);
        }

        [TestMethod]
        public void WhenLeftNullAndRightExampleClass_ThenRetunMinusOne()
        {
            var sensorViewModelRight =
                new ExampleClass { Name = "temperature sensor 2" };
            var sut = new NaturalComparer<ExampleClass>();

            var compare = sut.Compare(null, sensorViewModelRight);

            Assert.AreEqual(compare, -1);
        }

        [TestMethod]
        public void WhenCompareUnknownData_ThenThrowArgumentException()
        {
            var sut = new NaturalComparer<Object>();

            try
            {
                sut.Compare(null, null);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }
    }
}
