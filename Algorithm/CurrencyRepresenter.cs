using System;
using System.Globalization;

namespace Algorithm
{
  /// <summary>
  /// This class represents a number to currency in words.
  /// </summary>
  public class CurrencyRepresenter
  {
    #region Fields
    // decimal point
    private const string _decimalPoint = ".";
    #endregion

    #region Static Methods
    /// <summary>
    /// Represents into verbal words from numbers.
    /// </summary>
    public static string RepresentsToDollar(double number)
    {
      // validation check
      if (!(number >= 0))
      {
        throw new InvalidOperationException("Currency can not be nagitive");
      }

      int wholeNumberPart = (int)number; // whole number part
      string wholeNumberPartToWord = NumberTranslator.Translate(wholeNumberPart);
      string decimalPartToWords = string.Empty;

      var cultureInfo = new CultureInfo("en-US", false);
      // covert force-fully
      string decimalNumbur = number.ToString(cultureInfo);

      // gets the index of decimal point
      int decimalPointIndex = decimalNumbur.IndexOf(_decimalPoint);

      if (decimalPointIndex > 0)
      {
        string decimalPart = decimalNumbur.Substring(decimalPointIndex);
        double.TryParse(decimalPart, out double decimalNumberPart);

        int decimalPartInteger = (int)(decimalNumberPart * 100);
        if (decimalPartInteger > 0)
        {
          decimalPartToWords = string.Format("and {0} {1}",
            NumberTranslator.Translate(decimalPartInteger),
            decimalPartInteger != 1 ? "cents" : "cent");
        }
      }

      string result = String.Format("{0} {1} {2}",
        wholeNumberPartToWord.Trim(),
        wholeNumberPart != 1 ? "dollars" : "dollar",
        decimalPartToWords.Trim());

      return result.Trim();
    }
    #endregion
  }
}
