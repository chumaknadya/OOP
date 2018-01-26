using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion
    }



    public class DelegateCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);
        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;
        public DelegateCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }
        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }



        #endregion

    }


    class MainViewModel : ViewModelBase
    {
        private DelegateCommand exitCommand;
        #region Constructor
        public HumansModel Humans { get; set; }
        public string HumanNameToAdd { get; set; }
        public string HumanSurnameToAdd { get; set; }
        public string HumanSexToAdd { get; set; }
        public int HumanAgeToAdd { get; set; }



        // Fields for editing an existing human.
        public string HumanNameToEdit { get; set; }
        public string HumanSurnameToEdit { get; set; }
        public string HumanSexToEdit { get; set; }
        public int HumanAgeToEdit { get; set; }
        private Human _selectedHuman;
        public Human SelectedHuman
        {
            get { return this._selectedHuman; }
            set
            {
                this._selectedHuman = value;
                OnPropertyChanged("SelectedTiger");
            }
        }
        public MainViewModel()
        {
            Humans = HumansModel.Current;
        }
        #endregion
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new DelegateCommand(Exit, CanExecuteCommand1);
                }
                return exitCommand;
            }
        }
        private void Exit(object parameter)
        {
            bool answ = MessageBox.Show("OK to close?", "Confirm",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            if (answ)
            {
               // Serialization fileManager = new Serialization();
                //fileManager.WriteToFileFromClass<Human>(Humans.ToList<Human>(), @"C:\Users\HomePC\human.json");
                Application.Current.Shutdown();

            }
        }
        public bool CanExecuteCommand1(object parameter)
        {
            return true;
        }
        private ICommand _AddHuman;
        public ICommand AddHuman
        {
            get
            {
                if (_AddHuman == null)
                {
                    _AddHuman = new DelegateCommand(AddingHuman, CanExecuteAdding);
                }
                return _AddHuman;
            }
        }
        public void AddingHuman(object parameter)
        {
            Humans.AddHuman(HumanNameToAdd, HumanSurnameToAdd, HumanSexToAdd, HumanAgeToAdd);
        }
        public bool checkNameOrSurname(string Input)
        {
            if (!string.IsNullOrEmpty(Input) && char.IsUpper(Input[0]))
            {
                return true;
            }
            return false;
        }
        public bool checkSex(string Sex)
        {
            if (!string.IsNullOrEmpty(Sex) && (Sex == "male" || Sex == "female"))
            {
                return true;
            }
            return false;
        }
        public bool checkAge(int Age)
        {
            if (Age > 0 && Age < 120)
            {
                return true;
            }
            return false;
        }
        public bool CanExecuteAdding(object parameter)
        {
            if (checkNameOrSurname(HumanNameToAdd) && checkNameOrSurname(HumanSurnameToAdd) && checkSex(HumanSexToAdd))
            {
                return true;
            }
            return false;
        }
        private ICommand _RemoveHuman;
        public ICommand RemoveHuman
        {
            get
            {
                if (_RemoveHuman == null)
                {
                    _RemoveHuman = new DelegateCommand(RemovingHuman, CanExecuteCommand1);
                }
                return _RemoveHuman;
            }
        }
        public void RemovingHuman(object parameter)
        {
            bool answ = MessageBox.Show("Are you sure?", "Delete",
             MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            if (answ)
            {
                Humans.RemoveHuman(SelectedHuman);
            }
        }
 

        public void EditingHuman(object humanObj)
        {
          
            // Remove the old human.
            Human oldHuman = (Human)humanObj;
            int index = Humans.GetHumanIndex(oldHuman);
            Humans.RemoveHuman(oldHuman);

            // Update the old human.
            Humans.AddHuman(HumanNameToEdit, HumanSurnameToEdit, HumanSexToEdit, HumanAgeToEdit);
          
        }
    }

}
