using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Barker.Calculator.Model;

namespace Barker.Calculator.Platform.UWP.ViewModels
{
    public class MainPageViewModel : MainPageViewModelBase
    {
        private Model.Calculator calculator;
        public MainPageViewModel()
        {
            calculator = new Model.Calculator();            
        }
        

        public string TxtResult
        {
            //get { return calculator.Result; }
            get { return calculator.Result; }
            set { calculator.Result = value;
                OnPropertyChanged("TxtResult");
            }
        }

        //public ICommand EqualsClicked
        //{
        //    get
        //    {
        //        return new DelegateCommand(CalculateResult)
        //    }
        //}

        public void CalculateResult()
        {

        }


    }
}
