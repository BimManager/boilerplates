using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace Mvvm.Commands {
  public class BaseCommand : ICommand {
    public event EventHandler CanExecuteChanged;
    
    public BaseCommand(Action<object> action)
    : this(action, null) {}
    
    public BaseCommand(Action<object> action, Predicate<object> canExecute) {
      _action = action;
      _canExecute = canExecute;
    }

    public bool CanExecute(object parameter) {
      return null == _canExecute ? true : _canExecute(parameter);
    }

    public void Execute(object parameter) {
      _action(parameter);
    }

    private void OnCanExecuteChanged() {
      if (CanExecuteChanged != null) CanExecuteChanged(this, null);
    }
    
    private readonly Action<object> _action;
    private readonly Predicate<object> _canExecute;
  }
}
