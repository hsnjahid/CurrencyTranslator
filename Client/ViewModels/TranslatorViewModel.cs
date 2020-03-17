using System;
using System.ComponentModel;
using System.Windows.Input;

namespace NumberToWord.Client.ViewModels
{
  public class TranslatorViewModel : ViewModelBase, IDataErrorInfo
  {
    #region Fields
    private string _givenNumber;
    private string _errorMsg;
    #endregion

    #region Commands
    /// <summary>
    /// The command to clear the window
    /// </summary>
    public ICommand ResetCommand { get; set; }
    #endregion

    #region Properties

    /// <summary>
    /// 
    /// </summary>
    public string GivenNumber
    {
      get => _givenNumber;
      set
      {
        if (_givenNumber == value)
        {
          return;
        }
        if (_givenNumber == null || (_givenNumber.Equals(value) != true))
        {
          _givenNumber = value;
          OnPropertyChanged(nameof(GivenNumber));
          OnPropertyChanged(nameof(ConvertedNumberInWord));
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ConvertedNumberInWord
    {
      get
      {
        string numberInwords = string.Empty;

        if (!string.IsNullOrEmpty(_givenNumber))
        {
          try
          {
            double.TryParse(_givenNumber, out var result);
            var translateClient = new Translate.TranslateServiceClient();
            numberInwords = translateClient.ToWord(result);
          }
          catch (Exception e)
          {
            _errorMsg = e.Message;
            OnPropertyChanged(nameof(ErrorMessage));
          }
        }

        return numberInwords;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ErrorMessage => _errorMsg;

    public string Error => throw new NotImplementedException();

    public string this[string columnName]
    {
      get
      {
        return "No valid";
      }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="TranslatorViewModel"/> class.
    /// </summary>  
    public TranslatorViewModel()
    {
      ResetCommand = new RelayCommand(OnResetClearData);
    }
    #endregion


    #region Private Helpers
    private void OnResetClearData()
    {
      GivenNumber = string.Empty;
    }
    #endregion
  }
}
