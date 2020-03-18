using System;
using System.ComponentModel;
using System.ServiceModel;
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
    /// Sets or gets the given number to convert into words
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
          OnPropertyChanged(nameof(NumberInWordRepresentation));
          ResetCommand.CanExecute(value);
        }
      }
    }

    /// <summary>
    /// Gets the number as verbal represented words
    /// </summary>
    public string NumberInWordRepresentation
    {
      get
      {
        string numberInwords = string.Empty;

        if (!string.IsNullOrEmpty(_givenNumber))
        {
          try
          {
            var result = double.Parse(_givenNumber);
            var translateClient = new Translate.TranslateServiceClient();
            numberInwords = translateClient.ToWord(result);
          }
          // ignore format+overflow exception
          catch (FaultException e)
          {
            ErrorMessage = e.Message;
          }
        }

        return numberInwords;
      }
    }

    /// <summary>
    /// Gets or sets the error message
    /// </summary>
    public string ErrorMessage { get; set; }

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
      // init command
      ResetCommand = new RelayCommand(ResetResults, CanReset);
    }
    #endregion

    #region Helpers
    /// <summary>
    /// Can ResetCommand execute
    /// </summary>
    private bool CanReset(object arg)
    {
      return !string.IsNullOrEmpty(arg?.ToString());
    }

    /// <summary>
    /// On command clear
    /// </summary>
    private void ResetResults()
    {
      // clear input field
      GivenNumber = string.Empty;
      // clear error message
      ErrorMessage = string.Empty;
    }
    #endregion
  }
}
