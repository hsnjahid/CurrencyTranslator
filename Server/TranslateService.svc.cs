using Algorithm;
using System;
using System.ServiceModel;

namespace NumberToWord.Server
{
  /// <summary>
  /// Implemntation of the translate service. 
  /// </summary>
  public class TranslateService : ITranslateService
  {
    /// <summary>
    /// Translate the requested decimal number into words.
    /// </summary>
    public string ToWord(double number)
    {
      try
      {
        return CurrencyRepresenter.RepresentsToDollar(number);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }
  }
}
