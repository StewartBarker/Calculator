namespace Barker.Calculator.Forms.ViewModels
{
    public class MainPageViewModel : MainPageViewModelBase
    {
        #region instance vars
        private readonly Model.Calculator calculator;
        
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
