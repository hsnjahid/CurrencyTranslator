using NumberToWord.Client.Translate;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Input;

namespace NumberToWord.Client.ViewModels
{
  public class TranslatorViewModel : ViewModelBase
  {
    #region Fields
    private double? _givenNumber;
    private string _errorMessage;
    private TranslateServiceClient _translateClient;
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
    public double? GivenNumber
    {
      get => _givenNumber;
      set
      {
        if (_givenNumber != value)
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
        // clear error message
        _errorMessage = String.Empty;

        string numberInwords = null;

        if (_givenNumber.HasValue)
        {
          var number = _givenNumber.Value;

          if (number >= 0 && number <= 999999999.99) // input limit
          {
            numberInwords = ConvertAndLogError(number);
          }
          else
          {
            _errorMessage = @"Number can not be negative or greater than 999 999 999,99";
          }

          OnPropertyChanged(nameof(ErrorMessage));
        }

        return numberInwords;
      }
    }

    /// <summary>
    /// Gets the error message
    /// </summary>
    public string ErrorMessage => _errorMessage;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="TranslatorViewModel"/> class.
    /// </summary>  
    public TranslatorViewModel()
    {
      _translateClient = new TranslateServiceClient();
      // init command
      ResetCommand = new RelayCommand(ResetResults, CanReset);
    }
    #endregion

    #region Helpers

    /// <summary>
    /// Convert a number to words as well as log error message
    /// </summary>
    private string ConvertAndLogError(double number)
    {
      string words = null;
      string errorMessage = null;

      if (_translateClient != null)
      {
        try
        {
          words = _translateClient.ToWord(number);
        }
        catch (Exception e)
        {
          errorMessage = e.Message;
        }
      }
      else
      {
        errorMessage = "Server not found";
      }

      // log error
      if (!string.IsNullOrEmpty(errorMessage))
      {
        _errorMessage = errorMessage;
      }

      return words;
    }


    /// <summary>
    /// Can ResetCommand execute
    /// </summary>
    private bool CanReset(object arg)
    {
      return (arg as double?).HasValue;
    }

    /// <summary>
    /// On command clear
    /// </summary>
    private void ResetResults()
    {
      // clear input field  and error message
      GivenNumber = null;
      _errorMessage = null;
      OnPropertyChanged(nameof(ErrorMessage));
    }
    #endregion
  }
}
