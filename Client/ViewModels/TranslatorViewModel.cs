using NumberToWord.Client.Translate;
using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NumberToWord.Client.ViewModels
{
  public class TranslatorViewModel : ViewModelBase
  {
    #region Fields
    private string _numberInWork;
    private string _errorMessage;
    private TranslateServiceClient _translateClient = new TranslateServiceClient();
    #endregion

    #region Commands
    /// <summary>
    /// The command to clear the window
    /// </summary>
    public ICommand ResetCommand { get; set; }

    public ICommand ConvertNumberCommand { get; set; }

    #endregion

    #region Properties
    public double? GivenNumber { get; set; }

    /// <summary>
    /// Gets the number as verbal represented words
    /// </summary>
    public string NumberInWordRepresentation => _numberInWork;
    //{
    //  get
    //  {
    //    // clear error message
    //    _errorMessage = String.Empty;

    //    string numberInwords = null;

    //    if (_givenNumber.HasValue)
    //    {
    //      var number = _givenNumber.Value;

    //      if (number >= 0 && number <= 999999999.99) // input limit
    //      {
    //        Task.Run(async ()=> await ConvertNumberAsync(number).Result));

    //        numberInwords = ConvertNumberAsync(number).Result;
    //      }
    //      else
    //      {
    //        _errorMessage = @"Number can not be negative or greater than 999 999 999,99";
    //      }

    //      OnPropertyChanged(nameof(ErrorMessage));
    //    }

    //    return numberInwords;
    //  }
    //}

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
      // init command
      ResetCommand = new RelayCommand(ResetResults, ()=> true);
      ConvertNumberCommand = new RelayCommand(() => ConvertNumberAsync());
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
    /// Convert a number to words as well as log error message
    /// </summary>
    private async Task ConvertNumberAsync()
    {
      string errorMsg = "Converting number failed";

      await Task.Run(() =>
      {
        try
        {
          _numberInWork = _translateClient.ToWord(GivenNumber.Value);
        }
        catch (Exception e)
        {
          throw new Exception(errorMsg, e);
        }
      });

      OnPropertyChanged(nameof(NumberInWordRepresentation));
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
