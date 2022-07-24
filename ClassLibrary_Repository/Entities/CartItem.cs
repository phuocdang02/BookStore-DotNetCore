using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Checkout> CheckList { get; set; }
    }
}
