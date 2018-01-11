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
            IApproverHandler jennifer = new Manager();
            IApproverHandler mitchell = new Director();
            IApproverHandler olivia = new GeneralManager();

            //Create the chain
            jennifer.Approver = mitchell;
            mitchell.Approver = olivia;

            //Create requests
            TransferMoney reqModel = new TransferMoney(850, "TR9045656456456464454642", "Caner Tosuner");
            jennifer.HandleApprover(reqModel);

            reqModel = new TransferMoney(1450, "TR9045656456456464454642", "Caner Tosuner");
            jennifer.HandleApprover(reqModel);

            reqModel = new TransferMoney(5550, "TR9045656456456464454642", "Caner Tosuner");
            jennifer.HandleApprover(reqModel);

            reqModel = new TransferMoney(9000, "TR9045656456456464454642", "Caner Tosuner");
            jennifer.HandleApprover(reqModel);


            Console.ReadKey();
        }
    }

    public class TransferMoney
    {
        public decimal Amount { get; private set; }
        public string ReceiverAccount { get; private set; }
        public string ReceiverFullName { get; private set; }
        public TransferMoney(decimal amount, string receiverAccount, string receiverFullName)
        {
            Amount = amount;
            ReceiverAccount = receiverAccount;
            ReceiverFullName = receiverFullName;
        }
    }
    public interface IApproverHandler
    {
        void HandleApprover(TransferMoney req);
        IApproverHandler Approver { get; set; }
    }

    public class Manager : IApproverHandler
    {
        public IApproverHandler Approver { get; set; }

        public void HandleApprover(TransferMoney transfer)
        {
            if (transfer.Amount < 1000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.HandleApprover(transfer);
            }
        }
    }

    public class Director : IApproverHandler
    {
        public IApproverHandler Approver { get; set; }
        public void HandleApprover(TransferMoney transfer)
        {
            if (transfer.Amount < 3000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.HandleApprover(transfer);
            }
        }
    }

    public class GeneralManager : IApproverHandler
    {
        public IApproverHandler Approver { get; set; }
        public void HandleApprover(TransferMoney transfer)
        {
            if (transfer.Amount < 7000)
            {
                Console.WriteLine("{0} approved transfer request #{1}",
                    this.GetType().Name, transfer.Amount);
            }
            else if (Approver != null)
            {
                Approver.HandleApprover(transfer);
            }
        }
    }
}
