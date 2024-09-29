using IContract.Entities;
using System;


namespace IContract.Service
{
     class ContractService 
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract,int months)
        {
            double basicQuota = contract.TotalValue / months;
            for(int i =1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota,i);
                double fullquota = updatedQuota + _onlinePaymentService.payMentFree(updatedQuota);
                contract.AddInstallment(new Installment(date, fullquota));
            }
        }
    }
}
