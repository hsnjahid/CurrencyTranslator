using System;

namespace Algorithm
{
  public static class NumberTranslate
  {
    // decimal point
    private const string _decimalPoint = ".";

    public static string ConvertToWords(double number)
    {
      string input = number.ToString();

      string result = ConvertToWords(input);

      return result;
    }

    #region Helpers

    #endregion

    private static string ConvertOnes(string ones)
    {
      string onesToWords = string.Empty;

      Int32.TryParse(ones, out var output);
      switch (output)
      {
        case 1:
          onesToWords = "one";
          break;
        case 2:
          onesToWords = "two";
          break;
        case 3:
          onesToWords = "three";
          break;
        case 4:
          onesToWords = "four";
          break;
        case 5:
          onesToWords = "five";
          break;
        case 6:
          onesToWords = "six";
          break;
        case 7:
          onesToWords = "seven";
          break;
        case 8:
          onesToWords = "eight";
          break;
        case 9:
          onesToWords = "nine";
          break;
      }
      return onesToWords;
    }

    private static string ConvertTens(string tens)
    {
      string tensToWords = string.Empty;
      Int32.TryParse(tens, out var output);

      switch (output)
      {
        case 10:
          tensToWords = "ten";
          break;
        case 11:
          tensToWords = "eleven";
          break;
        case 12:
          tensToWords = "twelve";
          break;
        case 13:
          tensToWords = "thirteen";
          break;
        case 14:
          tensToWords = "fourteen";
          break;
        case 15:
          tensToWords = "fifteen";
          break;
        case 16:
          tensToWords = "sixteen";
          break;
        case 17:
          tensToWords = "seventeen";
          break;
        case 18:
          tensToWords = "eighteen";
          break;
        case 19:
          tensToWords = "nineteen";
          break;
        case 20:
          tensToWords = "twenty";
          break;
        case 30:
          tensToWords = "thirty";
          break;
        case 40:
          tensToWords = "fourty";
          break;
        case 50:
          tensToWords = "fifty";
          break;
        case 60:
          tensToWords = "sixty";
          break;
        case 70:
          tensToWords = "seventy";
          break;
        case 80:
          tensToWords = "eighty";
          break;
        case 90:
          tensToWords = "ninety";
          break;
        default:
          if (output > 0)
          {
            string tensStr = tens.ToString();

            tensToWords = ConvertTens(tensStr.Substring(0, 1) + "0") + "-" + ConvertOnes(tens.Substring(1));
          }
          break;
      }
      return tensToWords;
    }

    private static string ConvertWholeNumber(string Number)
    {
      string word = "";
      try
      {
        bool beginsZero = false;//tests for 0XX    
        bool isDone = false;//test if already translated    
        double dblAmt = (Convert.ToDouble(Number));
        //if ((dblAmt > 0) && number.StartsWith("0"))    
        if (dblAmt > 0)
        {//test for zero or digit zero in a nuemric    
          beginsZero = Number.StartsWith("0");

          int numDigits = Number.Length;
          int pos = 0;//store digit grouping    
          String place = "";//digit grouping name:hundres,thousand,etc...    
          switch (numDigits)
          {
            // ones
            case 1:
              word = ConvertOnes(Number);
              isDone = true;
              break;
            // tens
            case 2:
              word = ConvertTens(Number);
              isDone = true;
              break;
            // hundreds
            case 3:
              pos = (numDigits % 3) + 1;
              place = " hundred ";
              break;
            // thousands
            case 4:
            case 5:
            case 6:
              pos = (numDigits % 4) + 1;
              place = " thousand ";
              break;
            // millions
            case 7:
            case 8:
            case 9:
              pos = (numDigits % 7) + 1;
              place = " million ";
              break;
            case 10:
            case 11:
            case 12:
              pos = (numDigits % 10) + 1;
              place = " Billion ";
              break;
            //add extra case options for anything above Billion...    
            default:
              isDone = true;
              break;
          }
          if (!isDone)
          {//if transalation is not done, continue...(Recursion comes in now!!)    
            if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
            {
              try
              {
                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
              }
              catch { }
            }
            else
            {
              word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
            }

            //check for trailing zeros    
            //if (beginsZero) word = " and " + word.Trim();    
          }
          //ignore digit grouping names    
          if (word.Trim().Equals(place.Trim())) word = "";
        }
      }
      catch { }
      return word.Trim();
    }

    /// <summary>
    /// 
    /// </summary>
    private static string ConvertDecimalPart(string decimalPart)
    {
      string cd = "", digit = "", engOne = "";
      for (int i = 0; i < decimalPart.Length; i++)
      {
        digit = decimalPart[i].ToString();
        if (digit.Equals("0"))
        {
          engOne = "Zero";
        }
        else
        {
          engOne = ConvertOnes(digit);
        }
        cd += " " + engOne;
      }
      return cd;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbuer"></param>
    private static string ConvertToWords(string decimalNumbur)
    {
      string wholeNumberPart = decimalNumbur;
      string decimalPart = string.Empty;

      string decimalNumburToWords = string.Empty;
      string wholeNumberPartToWords = string.Empty;
      string decimalPartToWords = string.Empty;

      string and = string.Empty;
      string cent = string.Empty;
      try
      {
        // gets the index of decimal point
        int decimalPointIndex = decimalNumbur.IndexOf(_decimalPoint);

        if (decimalPointIndex > 0)
        {
          wholeNumberPart = decimalNumbur.Substring(0, decimalPointIndex);
          decimalPart = decimalNumbur.Substring(decimalPointIndex + 1);

          Int32.TryParse(decimalPart, out var decimalResult);

          if (decimalResult > 0)
          {
            and = "and";
            cent = decimalResult == 1 ? "cent" : "cents ";
            decimalPartToWords = ConvertTens(decimalPart);
          }
        }

        Int32.TryParse(wholeNumberPart, out var wholeNumberResult);

        string dollar = wholeNumberResult == 1 ? "dollar" : "dollars";

        wholeNumberPartToWords = ConvertWholeNumber(wholeNumberPart).Trim();

        decimalNumburToWords = String.Format("{0} {1} {2} {3} {4}", wholeNumberPartToWords, dollar, and, decimalPartToWords, cent);
      }
      catch { }
      return decimalNumburToWords.Trim();
    }
  }

}
