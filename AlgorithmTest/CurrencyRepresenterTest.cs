using Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgorithmTest
{
  [TestClass]
  public class CurrencyRepresenterTest
  {
    [TestMethod]
    public void TestRepresentsToDollar()
    {
      var output = CurrencyRepresenter.RepresentsToDollar(0);
      Assert.AreEqual("zero dollars", output, true);

      output = CurrencyRepresenter.RepresentsToDollar(1);
      Assert.AreEqual("one dollar", output, true);

      output = CurrencyRepresenter.RepresentsToDollar(25.1);
      Assert.AreEqual("twenty-five dollars and ten cents", output, true);

      output = CurrencyRepresenter.RepresentsToDollar(0.01);
      Assert.AreEqual("zero dollars and one cent", output, true);

      output = CurrencyRepresenter.RepresentsToDollar(45100);
      Assert.AreEqual("forty-five thousand one hundred dollars", output, true);

      output = CurrencyRepresenter.RepresentsToDollar(999999999.99);
      Assert.AreEqual("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents", output, true);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestInputValidation()
    {
      var output = CurrencyRepresenter.RepresentsToDollar(-20.0);
    }
  }
}
