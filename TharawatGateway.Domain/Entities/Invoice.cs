using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharawatGateway.Domain.Entities
{
    //  الفواتير
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
