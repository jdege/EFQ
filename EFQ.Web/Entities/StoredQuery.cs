namespace EFQ.Web.Entities
{
    public partial class StoredQuery
    {
        public StoredQuery()
        {
        }

        public int StoredQueryId { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public string Description { get; set; }
        public string StoredQueryJson { get; set; }
    }
}
