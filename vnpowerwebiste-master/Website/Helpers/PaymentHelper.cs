using Common;
using Entities.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Website.Helpers
{
    public class PaymentHelper
    {
        //public static PaymentModel CreateTransaction(GroupTypes type, string paymentName, decimal totalMoney, string controllerName, ApplicationUser user)
        //{
        //    var transaction = new TransactionPayment()
        //    {
        //        CreatedDate = DateTime.Now,
        //        PaymentForTypeId = GroupTypes.Radiography.GetHashCode(),
        //        Status = ApplicationStatus.InProgress.GetHashCode(),
        //        TotalMoney = totalMoney , // Fix tạm,
        //        Name = "AppointmentController",
        //        UpdatedDate = DateTime.Now,
        //        UserId = user.Id

        //    };
        //    var payment = new Payment()
        //    {
        //        CreatedDate = DateTime.Now,
        //        PaymentMethod = paymentName,
        //        Status = ApplicationStatus.InProgress.GetHashCode(),
        //        LastestUpDate = DateTime.Now,

        //    };
        //    var paymentResponse = new PaymentModel()
        //    {
        //        HISCode = user.HISCode,
        //        TotolMoney = transaction.TotalMoney
        //        ,
        //        Type = GroupTypes.Radiography.GetHashCode(),
        //        CallbackUrl = _urlPayment
        //    };
        //    using (TransactionScope scope = new TransactionScope())
        //    {

        //        var q = _radiographyRepository.InsertEntity(radiography);
        //        transaction.ObjectId = q.Id;
        //        var t = _transactionRepository.InsertEntity(transaction);
        //        payment.TransactionId = t.Id;
        //        var p = _paymentRepository.InsertEntity(payment);
        //        paymentResponse.TransactionId = t.Id;

        //        scope.Complete();
        //    }
        //}
    }
}
