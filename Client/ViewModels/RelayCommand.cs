using System;
using System.Windows.Input;

namespace NumberToWord.Client.ViewModels
{
  /// <summary>
  /// This class represents a basic command that runs an action
  /// </summary>
  public class RelayCommand : ICommand
  {
    #region Fields
    private Action _action;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class.
    /// </summary>  
    public RelayCommand(Action action)
    {
      _action = action;
    }
    #endregion

    #region Event
    /// <summary>
    /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
    /// </summary>
    public event EventHandler CanExecuteChanged = (sender, e) => { };
    #endregion

    #region ICommand
    /// <summary>
    /// A relay command can always execute
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object parameter)
    {
      return true;
    }

    /// <summary>
    /// Executes the commands Action
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter)
    {
      _action();
    }
    #endregion
  }
}
