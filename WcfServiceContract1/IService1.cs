using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {

        [OperationContract]
        double addNumbers(double number1, double number2);

        [OperationContract]
        double multiplyNumbers(double number1, double number2);

        [OperationContract]
        double substractNumbers(double number1, double number2);

        [OperationContract]
        double divideNumber(double number1, double number2);

        [OperationContract]
        double getSum(double numberToAdd);

        // TODO: Add your service operations here
    }

}
