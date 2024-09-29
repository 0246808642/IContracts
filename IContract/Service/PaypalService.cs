namespace IContract.Service
{
     class PaypalService : IOnlinePaymentService
    {
        private const double FreePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(double amount, int months)
        {
            return amount * FreePercentage * months;
        }
        public double payMentFree(double amount)
        {
            return amount * FreePercentage;
        }
    }
}
