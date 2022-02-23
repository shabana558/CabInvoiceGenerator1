using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator1
{
    public  class InvoiceSummary
    {
        public double totalFare;
        public double average;
        public int numberofRides;

        public InvoiceSummary(int numberOfRides,double totalFare)
        {
            this.numberofRides = numberOfRides;
            this.totalFare = totalFare;
            this.average = totalFare/numberofRides;
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!(obj is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary imputObject=(InvoiceSummary)obj;
            return this.numberofRides==imputObject.numberofRides && this.totalFare==imputObject.totalFare && this.average==imputObject.average;
        }
    }
}
