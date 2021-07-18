namespace JDege.EFQ.Web.Entities
{
    public partial class StoredQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseTableName { get; set; }
        public string StoredQueryJson { get; set; }
    }
}
