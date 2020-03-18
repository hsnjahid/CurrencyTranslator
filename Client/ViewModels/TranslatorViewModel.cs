using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Windows.Input;

namespace NumberToWord.Client.ViewModels
{
  public class TranslatorViewModel : ViewModelBase, IDataErrorInfo
  {
    #region Fields
    private double? _givenNumber;
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
        if (_givenNumber.Equals(value) != true)
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
        string numberInwords = null;

        if (_givenNumber.HasValue)
        {
          if (_givenNumber.Value >= 0 && _givenNumber.Value <= 999999999.99) // input limit
          {
            try
            {
              var translateClient = new Translate.TranslateServiceClient();
              numberInwords = translateClient.ToWord(_givenNumber.Value);
            }
            // ignore format+overflow exception
            catch (FaultException e)
            {
              ErrorMessage = e.Message;
            }
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
        string result = "";

        if (columnName == nameof(GivenNumber))
        {
          if (_givenNumber.HasValue)
          {
            if (!(_givenNumber.Value > 0 && _givenNumber.Value <= 999999999.99))
            {
              result = "Number can be negative or greater than 999.999.999,99";
            }
          }
        }
        return result;
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
      return (arg as double?).HasValue;
    }

    /// <summary>
    /// On command clear
    /// </summary>
    private void ResetResults()
    {
      // clear input field
      GivenNumber = null; // string.Empty;
      // clear error message
      ErrorMessage = string.Empty;
    }
    #endregion
  }
}
