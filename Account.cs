using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
  
    public class Account
    {
        //class attribute - note how can initialise
        static private long num = 0; 
        //instance variables
        protected long number;
        protected decimal balance;

        List<Transaction> transactions;

        //read only properties
        public long Number
        {
            get
            {
                return number;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        //constructors
        public Account(decimal amount)
        {
            balance = amount;
            number = ++num;
            transactions = new List<Transaction>();
        }
        public Account()
        {
            balance = 0;
            number = ++num;
            transactions = new List<Transaction>();
        }

        public virtual void debit(decimal amount)
        {
            balance = balance - amount;
            transactions.Add(new DebitTransaction(balance,amount));
        }

        public void credit(decimal amount)
        {
            balance = balance + amount;
            transactions.Add(new CreditTransaction(balance, amount));
        }

        public string getStatement()
        {
            transactions.Reverse();
            string strout = "Account: " + this.ToString()+"\n";
            foreach(Transaction t in transactions)
            {
                strout = strout + t + "\n";
            }     
            transactions.Reverse();
            return strout;
        }
        public override string ToString()
        {
            string strout;
            strout = string.Format("Account num: {0}",number);
            strout = strout + string.Format(" Balance: {0:c}",balance);
            return strout;
        }
        
    }
    
    public class CreditAccount : Account
    {
        private decimal ODLimit;

        public decimal Limit
        {
            get
            {
                return ODLimit;
            }
            set
            {
                ODLimit = value;
            }
        }
        /******************************
         * Constructors
         * ***************************/
        public CreditAccount(decimal amount):base(amount)
        {
            //the :base(amount) calls parent constructor
            //passes on parameter amount
            //so only need to initialise additional instance variables
            ODLimit = 100;
        }
        public CreditAccount():base()
        {
            ODLimit = 100;
        }

        public CreditAccount(decimal amount,decimal limit): base(amount)
        {
            //the :base(amount) calls parent constructor
            //passes on parameter amount
            //so only need to initialise additional instance variables
            ODLimit = limit;
        }
    
        public override string ToString()
        {
            string strout;
            strout = "Credit account    \n" + base.ToString();
            strout = strout + string.Format("\nOD Limit: {0:c}\n", ODLimit);
            return strout;
        }

        public override void debit(decimal amount)
        {
            if (amount > (Balance + ODLimit))
                throw new Exception("Insufficient funds: transaction cancelled");
            else
                base.debit(amount);
        }
    }
 
    public class DepositAccount:Account
    {
        private double rate;

        public double Rate
        {
            set
            {
                rate = value;
            }
            get
            {
                return rate;
            }
        }

        /***********************
         * Constructors
         * *********************/
        public  DepositAccount():base()
        {
            rate = 2.0;
        }

        public DepositAccount(decimal amount) : base(amount)
        {
            rate = 2.0;
        }

        public DepositAccount(decimal amount,double rt)   : base(amount)
        {
            rate = rt;
        }

        public override void debit(decimal amount)
        {
            if (amount > balance)
                throw new Exception("Insufficient Funds: transaction cancelled ");
            else
                balance = balance - amount;
        }

        public override string ToString()
        {
            string strout;
            strout = "Deposit account " + base.ToString();
            strout = strout + string.Format("\n Rate: {0:f2}", rate);
            return strout;
        }
    }
}
