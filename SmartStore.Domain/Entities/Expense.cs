using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public TransactionType TransactionType { get; set; }
    }

}
