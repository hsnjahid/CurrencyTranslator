using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTest
{
  [TestClass]
  public class NumberTranslateTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      var output = Algorithm.NumberTranslate.ConvertToWords(0);
      //Assert.AreEqual("zero", output, true);

      output = Algorithm.NumberTranslate.ConvertToWords(1);
      //Assert.AreEqual("one only", output, true);

      output = Algorithm.NumberTranslate.ConvertToWords(25.1);
      //Assert.AreEqual("zero", output, true);

      output = Algorithm.NumberTranslate.ConvertToWords(0.001);
      //Assert.AreEqual("zero", output, true);

      output = Algorithm.NumberTranslate.ConvertToWords(45100);
      //Assert.AreEqual("fourtyzero", output, true);

      output = Algorithm.NumberTranslate.ConvertToWords(999999999.99);
      Assert.AreEqual("zero", output, true);
    }
  }
}
