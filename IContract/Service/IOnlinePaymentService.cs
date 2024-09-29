namespace IContract.Service
{
    interface IOnlinePaymentService
    {
        double payMentFree(double amount);
        double Interest(double amount, int months);
    }
}
