namespace Barker.Calculator.Platform.UWP.ViewModels
{
    internal class DelegateCommand
    {
        private object calculateResult;

        public DelegateCommand(object calculateResult)
        {
            this.calculateResult = calculateResult;
        }
    }
}