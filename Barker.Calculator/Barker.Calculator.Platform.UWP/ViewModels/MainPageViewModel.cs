using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model = Barker.Calculator.Model;

namespace Barker.Calculator.Platform.UWP.ViewModels
{
    public class MainPageViewModel : MainPageViewModelBase
    {
        #region instance vars
        private Model.Calculator calculator;
        
        private DelegateCommand _btnEqualsClicked;
        public DelegateCommand BtnEqualsClicked
        {
            get { return _btnEqualsClicked; }
            set { SetProperty(ref _btnEqualsClicked, value); }
        }

        private DelegateCommand _btnNumberClicked;
        public DelegateCommand BtnNumberClicked
        {
            get { return _btnNumberClicked; }
            set { SetProperty(ref _btnNumberClicked, value); }
        }

        private DelegateCommand _btnOperatorClicked;
        public DelegateCommand BtnOperatorClicked
        {
            get { return _btnOperatorClicked; }
            set { SetProperty(ref _btnOperatorClicked, value); }
        }

        private DelegateCommand _btnDeleteClicked;
        public DelegateCommand BtnDeleteClicked
        {
            get { return _btnDeleteClicked; }
            set { SetProperty(ref _btnDeleteClicked, value); }
        }

        #endregion

        public MainPageViewModel()
        {
            calculator = new Model.Calculator();
            BtnEqualsClicked = new DelegateCommand(ExecuteCalculateResult);
            BtnNumberClicked = new DelegateCommand(ExecuteAddNumber);
            BtnOperatorClicked = new DelegateCommand(ExecuteAddOperator);
            BtnDeleteClicked = new DelegateCommand(ExecuteDelete);
        }

        #region Button Execute Methods

        private void ExecuteDelete(object obj)
        {
            calculator.Delete();
            TxtResult = calculator.Result;
        }

        private void ExecuteAddOperator(object obj)
        {
            calculator.AddOperand((string) obj);
            TxtResult = calculator.Result;
        }
        
        private void ExecuteAddNumber(object obj)
        {
            calculator.AddNumber((string)obj);
            TxtResult = calculator.Result;
        }

        public void ExecuteCalculateResult(object obj)
        {
            TxtResult = calculator.CalculateExpression();
            
        }

        #endregion

        public string TxtResult
        {            
            get { return calculator.Result; }
            set { calculator.Result = value;
                OnPropertyChanged("TxtResult");
            }
        }
    }
}
