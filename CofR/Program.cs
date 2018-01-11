using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofR
{
    class Program
    {
        static void Main(string[] args)
        {
            //create approvers
            IApprover manager = new Manager();
            IApprover director = new Director();
            IApprover gManager = new GeneralManager();

            //Create the chain
            manager.Approver = director;
            director.Approver = gManager;

            //Create requests
            MoneyTransfer reqModel = new MoneyTransfer(850, "TR9045656456456464454642", "Caner Tosuner");
            manager.RequestHandler(reqModel);

            reqModel = new MoneyTransfer(1450, "TR9045656456456464454642", "Caner Tosuner");
            manager.RequestHandler(reqModel);

            reqModel = new MoneyTransfer(5550, "TR9045656456456464454642", "Caner Tosuner");
            manager.RequestHandler(reqModel);

            reqModel = new MoneyTransfer(9000, "TR9045656456456464454642", "Caner Tosuner");
            manager.RequestHandler(reqModel);


            Console.ReadKey();
        }
    }

    public class MoneyTransfer
    {
        public decimal Amount { get; private set; }
        public string ReceiverAccount { get; private set; }
        public string ReceiverFullName { get; private set; }
        public MoneyTransfer(decimal amount, string receiverAccount, string receiverFullName)
        {
            Amount = amount;
            ReceiverAccount = receiverAccount;
            ReceiverFullName = receiverFullName;
        }
    }

    public interface IRequestHandler
    {
        void RequestHandler(MoneyTransfer transfer);
    }

    public interface IApprover : IRequestHandler
    {
        IApprover Approver { get; set; }
    }

    public class Manager : IApprover
    {
        public IApprover Approver { get; set; }

        public void RequestHandler(MoneyTransfer transfer)
        {
            if (transfer.Amount < 1000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.RequestHandler(transfer);
            }
        }
    }

    public class Director : IApprover
    {
        public IApprover Approver { get; set; }
        public void RequestHandler(MoneyTransfer transfer)
        {
            if (transfer.Amount < 3000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.RequestHandler(transfer);
            }
        }
    }

    public class GeneralManager : IApprover
    {
        public IApprover Approver { get; set; }
        public void RequestHandler(MoneyTransfer transfer)
        {
            if (transfer.Amount < 7000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.RequestHandler(transfer);
            }
        }
    }
}
