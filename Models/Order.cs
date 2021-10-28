using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RocStudiosMVCProject.Resources;

namespace RocStudiosMVCProject.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string ServId { get; set; }
        [Required(ErrorMessageResourceName = "CustomerEmailErr", ErrorMessageResourceType = typeof(Lang))]
        [Display(Name = "CustomerEmail", ResourceType = typeof(Lang))]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessageResourceName = "NameErr", ErrorMessageResourceType = typeof(Lang))]
        [Display(Name = "Name", ResourceType = typeof(Lang))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = "CustomerPhoneNumErr", ErrorMessageResourceType = typeof(Lang))]
        [Display(Name = "CustomerPhoneNum", ResourceType = typeof(Lang))]
        public string CustomerPhoneNum { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }
        [Required]
        [Display(Name = "Order Case")]
        public string OrderCase { get; set; }

        public readonly string OrderCase1 = "تم ارسال الطلب";
        public readonly string OrderCase2 = "جاري تنفيذ الطلب";
        public readonly string OrderCase3 = "تم الانتهاء من الطلب";
        public readonly string OrderErrorAr = "لايمكنك ارسال طلب جديد لديك بالفعل طلبات لم يتم تنفيذها";
        public readonly string OrderErrorEng = "You Cannot Submit a New Request. You Already Have Unfulfilled Reqests.";
        public readonly string OrderSuccessAr = "تم ارسال طلبك بنجاح وسيتم التواصل معك بأسرع وقت ممكن";
        public readonly string OrderSuccessEnd = "Yor Order has been Sent And We Will Contact You Shortly";



    }
}