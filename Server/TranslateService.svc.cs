using Algorithm;

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
      return NumberTranslate.ConvertToWords(number);
    }
  }
}
