using System.ServiceModel;

namespace NumberToWord.Server
{
  [ServiceContract]
  public interface ITranslateService
  {
    /// <summary>
    /// Translate the requested decimal number into words.
    /// </summary>
    [OperationContract]
    string ToWord(double number);
  }
}
