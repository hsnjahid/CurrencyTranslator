using System.ServiceModel;

namespace NumberToWord.Server
{
  [ServiceContract]
  public interface ITranslateService
  {
    [OperationContract]
    string ToWord(double number);
  }
}
