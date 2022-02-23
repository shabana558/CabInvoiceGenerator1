using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator1
{
    public class InvoiceGenerator
    {
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;
        private RideType rideType;

        public InvoiceGenerator(RideType type)
        {
            this.rideType = type;
            try
            {
                if(this.rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
                if(this.rideType.Equals(RideType.PREMIUM))
                {
                   this. MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDETYPE, "Invalid ride type");
            }
        }
        public double CalculateFare(double distance,int time)
        {
            double totalFare=0;
            try
            {
                if(distance<=0)
                {
                    try
                    {
                        throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                if(time<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;

            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex);

            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += CalculateFare(ride.distance,ride.time);
                }

            }
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no ridesfound");

                }
            }
            double res=Math.Max(totalFare, MINIMUM_FARE);
            return res;
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += CalculateFare(ride.distance,ride.time);
                }
            }
            catch(CabInvoiceException)
            {
                if(rides==null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides found");
                }
            }
            double res = Math.Max(totalFare, MINIMUM_FARE);

            return new InvoiceSummary(rides.Length, res);
        }
    }
}
