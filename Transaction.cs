using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
   
    public abstract class Transaction
    {
        
        private DateTime date;
        private decimal amount;
        private decimal cbalance;

        /***********
         * add in public get properties
         * *********/
        public decimal Amount
        {
            get { return amount; }
        }
        public decimal Balance
        {
            get { return cbalance; }
        }
        public DateTime Date
        {
            get { return date; }
        }

        public Transaction(decimal b,decimal a)
        {
            amount = a;
            cbalance = b;
            date = DateTime.Now;
        }

        public override string ToString()
        {
            string strout = date.ToShortDateString( ) ;
            strout = strout + "\t" + date.ToShortTimeString( ) ;
            return strout; 
        }

    }
   
    public class CreditTransaction:Transaction
    {
        public CreditTransaction(decimal b, decimal a)
            : base(b, a)
        {
        }

        public override string ToString()
        {
            string strout;
            strout = base.ToString();
            strout = strout + string.Format("\t{0:c}\t\t{1:c}", Amount, Balance);
            return strout;
        }
    }
  
    public class DebitTransaction : Transaction
    {
        public DebitTransaction(decimal b, decimal a)
            : base(b, a)
        {
        }

        public override string ToString()
        {
            string strout;
            strout = base.ToString();
            strout = strout + string.Format("\t{0:c}\t\t{1:c}", Amount, Balance);
            return strout;
        }
    }
}
