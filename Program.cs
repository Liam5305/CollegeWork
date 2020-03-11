
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            testCustomer();
        }

        private static void testCustomer()
        {
            //Customer fred = new Customer("Fred");
            //Console.WriteLine("Fred created" + fred);
            //fred.createCredit(500, 100);
            //fred.CreditAcc.debit(300);
            //fred.CreditAcc.debit(200);
            //fred.CreditAcc.credit(100);
            //Console.WriteLine("Freds statement");
            //Console.WriteLine(fred.CreditAcc.getStatement());

            //Customer sam = new Customer("Sam");
            //Console.WriteLine("Sam created" + sam);
            //Console.WriteLine("Sam created" + sam);
            //sam.createDeposit(700, 10);
            //sam.DepositAcc.debit(300);
            //sam.DepositAcc.debit(150);
            //sam.DepositAcc.credit(100);
            //Console.WriteLine("Sams statement");
            //Console.WriteLine(sam.DepositAcc.getStatement());

            Bank theBank = new Bank();
            theBank.populate();

            Console.WriteLine(theBank.listCustomers());

            Customer cus = theBank.findCustomer("Fred");
            Console.WriteLine(cus);
            Console.WriteLine(cus.CreditAcc.getStatement());
            cus = theBank.findCustomer("harry");
            if (cus == null)
                Console.WriteLine("nor harry!");
            else
                Console.WriteLine(cus);

            Console.ReadLine();
        }
    }
}
