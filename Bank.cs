using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{

    public class Bank
    {
        List<Customer> customers;

        public Bank()
        {
            customers = new List<Customer>();
        }

        //should add customer to List customers
        public void addCustomer(Customer cus)
        {
            List<string> Customer = new List<string>();
            Customer.Add("Liam");
            Customer.Add("Jon");
            Customer.Add("David");
            Customer.Add("Harry");
        }

        //should return a string showing all of the customers
        public string listCustomers()
        {
            foreach (Customer c in customers)
            {
                return c.ToString();
            }
            return null;
        }

        public Customer findCustomer(string sname)
        {
            foreach (Customer c in customers)
            {
                if (c.Name == sname)
                    return c; //found
            }
            return null; //not found
        }

        public void populate ()
        {
            Customer fred = new Customer("Fred");
            fred.createCredit(500, 100);
            fred.CreditAcc.debit(300);
            fred.CreditAcc.debit(200);
            fred.CreditAcc.credit(100);

            Customer sam = new Customer("Sam");
            sam.createDeposit(700, 10);
            sam.DepositAcc.debit(300);
            sam.DepositAcc.debit(150);
            sam.DepositAcc.credit(100);

            Customer tim = new Customer("Tim");
            tim.createDeposit(200, 10);
            tim.DepositAcc.debit(100);
            tim.DepositAcc.credit(150);
            tim.DepositAcc.credit(100);

            customers.Add(sam);
            customers.Add(tim);
            customers.Add(fred);
        }
    }
}
