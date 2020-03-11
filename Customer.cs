using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using People;

namespace SimpleBank
{
    
    public class Customer:Person
    {
        private CreditAccount creditAcc;
        private DepositAccount depositAcc;

        // add in public properties
        public CreditAccount CreditAcc
        {
            get
            {
                return creditAcc;
            }
            set
            {
                creditAcc = value;
            }
        }

        public DepositAccount DepositAcc
        {
            get
            {
                return depositAcc;
            }
            set
            {
                depositAcc = value;
            }
        }
       
        // Constructor
        public Customer(string name)
            : base(name)
        {
            creditAcc = null;
            depositAcc = null;
        }

        /************************************
         * createCredit
         * used to allow a Customer to take out a credit account
         * parameters
         * decimal b - used to set the balance
         * decimal od - used to set the overdraft limit
         * 
         * ********************************/

        public void createCredit(decimal b, decimal od)
        {
            creditAcc = new CreditAccount(b, od);
        }

        public void createDeposit(decimal b, double rate)
        {
            depositAcc = new DepositAccount(b, rate);
        }

    }
}
