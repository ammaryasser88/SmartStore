using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Domain.Entities
{
    public class Safe
    {
        public int SafeId { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public decimal Balance { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<SafeTransaction> SafeTransactions { get; set; }= new List<SafeTransaction>();
    }

}
