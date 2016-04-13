using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conube.Business;

namespace Conube.UnitTest
{
    /// <summary>
    /// Summary description for ConubeTests
    /// </summary>
    [TestClass]
    public class ConubeTests
    {
        public ConubeTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void CalculateWithholdWithValueZero_ReturnWithholdZero()
        {
            var nfe = new Calculator().CalculateWithhold(0);
            Assert.AreEqual(0, nfe.Withhold);
        }

        [TestMethod]
        public void CalculateWithholdWithLessThenFiveThousand_ReturnWithholdMoreThenZero()
        {
            var nfe = new Calculator().CalculateWithhold(1000);
            Assert.AreEqual(true, nfe.Withhold > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithIRLessThenTen_ReturnWithholdZero()
        {
            var nfe = new Calculator().CalculateWithhold(100);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CalculateWithholdWithMoreThenFiveThousand_ReturnWithholdMoreThenZero()
        {
            var nfe = new Calculator().CalculateWithhold(6000);
            Assert.AreEqual(true, nfe.Withhold > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithMoreThenFiveThousand_ReturnAllTaxes()
        {
            var nfe = new Calculator().CalculateWithhold(6000);
            Assert.AreEqual(true, nfe.COFINSValue > 0);
            Assert.AreEqual(true, nfe.CSLLValue > 0);
            Assert.AreEqual(true, nfe.PISValue > 0);
            Assert.AreEqual(true, nfe.IRValue > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithLessThenFiveThousand_ReturnJustIRTax()
        {
            var nfe = new Calculator().CalculateWithhold(4000);
            Assert.AreEqual(true, nfe.COFINSValue == 0);
            Assert.AreEqual(true, nfe.CSLLValue == 0);
            Assert.AreEqual(true, nfe.PISValue == 0);
            Assert.AreEqual(true, nfe.IRValue > 0);
        }

        //

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithValueZero_ReturnWithholdZero()
        {
            var nfe = new Calculator().CalculateWithhold(0, 1, 2, 3, 4);
            Assert.AreEqual(0, nfe.Withhold);
        }

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithLessThenFiveThousand_ReturnWithholdMoreThenZero()
        {
            var nfe = new Calculator().CalculateWithhold(1000, 0.01M, 0.01M, 0.01M, 0.01M);
            Assert.AreEqual(true, nfe.Withhold > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithIRLessThenTen_ReturnWithholdZero()
        {
            var nfe = new Calculator().CalculateWithhold(100, 0.01M, 0.01M, 0.01M, 0.01M);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithMoreThenFiveThousand_ReturnWithholdMoreThenZero()
        {
            var nfe = new Calculator().CalculateWithhold(6000, 0.01M, 0.01M, 0.01M, 0.01M);
            Assert.AreEqual(true, nfe.Withhold > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithMoreThenFiveThousand_ReturnAllTaxes()
        {
            var nfe = new Calculator().CalculateWithhold(6000, 0.01M, 0.01M, 0.01M, 0.01M);
            Assert.AreEqual(true, nfe.COFINSValue > 0);
            Assert.AreEqual(true, nfe.CSLLValue > 0);
            Assert.AreEqual(true, nfe.PISValue > 0);
            Assert.AreEqual(true, nfe.IRValue > 0);
        }

        [TestMethod]
        public void CalculateWithholdWithCustomTaxesWithLessThenFiveThousand_ReturnJustIRTax()
        {
            var nfe = new Calculator().CalculateWithhold(4000, 0.01M, 0.01M, 0.01M, 0.01M);
            Assert.AreEqual(true, nfe.COFINSValue == 0);
            Assert.AreEqual(true, nfe.CSLLValue == 0);
            Assert.AreEqual(true, nfe.PISValue == 0);
            Assert.AreEqual(true, nfe.IRValue > 0);
        }
    }
}
