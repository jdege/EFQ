using System.Collections.Generic;

namespace JDege.EFQ.Web.Models
{
    public class RunInvoiceQueryModel
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public string Context { get; set; }
        public string Description { get; set; }
        public string ReturnController { get; set; }
        public IList<InvoiceModel> InvoiceModels { get; set; }
    }
}