using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsReturn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    }

}
