namespace RequestApplication.Entities
{
    public class Request : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime EndDate { get; set; }
    }
}
