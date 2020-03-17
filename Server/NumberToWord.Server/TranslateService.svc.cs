using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NumberToWord.Server
{
  public class TranslateService : ITranslateService
  {
    public string ToWord(double number)
    {
    return Algorithm.NumberTranslate.ConvertToWords(number);
    }
  }
}
