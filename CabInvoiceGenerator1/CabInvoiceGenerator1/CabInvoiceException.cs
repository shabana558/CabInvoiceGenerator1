using System;
using System.Runtime.Serialization;

namespace CabInvoiceGenerator1
{
    ///<summary>
    ///Custom Exception for cab Invoice Program
    ///</summary>
    ///<see cref="System.Exception"/>
    public class CabInvoiceException:Exception
    {
        ///<summary>
        ///Enum for defining different type of custom exception
        ///</summary>
        ///public ExceptionType type;
        public CabInvoiceException(ExceptionType type,string message)
        {
            throw new Exception(message);
            //this.type=type
        }
        public enum ExceptionType
        {
            INVALID_DISTANCE,INVALID_TIME,NULL_RIDES,INVALID_USER_ID,INVALID_RIDE_TYPE,
            INVALID_RIDETYPE
        }
    }
}