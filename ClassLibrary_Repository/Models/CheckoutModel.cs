using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Models
{
    public class CheckoutModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int Depositornumber { get; set; }
        [Required]
        public int Receivernumber { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public int AccountId { get; set; }

        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public int ShippingfeeId { get; set; }
        public int CartId { get; set; }
        public int CartItemId { get; set; }
    }
}
