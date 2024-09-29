using IContract.Entities;
using IContract.Service;
using System.Globalization;
using System;

namespace IContract
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (ddd/MM/yyyy): ");
            DateTime contratcDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contarctValue = double.Parse(Console.ReadLine());
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumber, contratcDate,contarctValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract,months);

            Console.WriteLine("Installments: ");
            foreach(Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
