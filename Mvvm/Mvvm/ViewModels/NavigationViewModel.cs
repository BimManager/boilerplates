using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; // INotifyPropertyChanged
using System.Windows.Input; // ICommand

namespace Mvvm.ViewModels {
  public class NavigationViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;
    
    public ICommand EmpCommand { get; private set; }
    public ICommand DeptCommand { get; private set; }
    
    public object SelectedViewModel { get { return _selectedViewModel; }
      set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); } }

    public NavigationViewModel() {
      EmpCommand = new Commands.BaseCommand(OpenEmp);
      DeptCommand = new Commands.BaseCommand(OpenDept);
    }

    private void OpenEmp(object obj) {
      SelectedViewModel = new Views.EmployeeView();
    }

    private void OpenDept(object obj) {
      SelectedViewModel = new Views.DepartmentView();
    }

    private void OnPropertyChanged(string propName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    
    private object _selectedViewModel;
  }
}
