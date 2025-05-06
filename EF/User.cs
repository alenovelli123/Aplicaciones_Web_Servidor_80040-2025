namespace WebAppClase08.EF
{
    public partial class User
    {
        public long UserId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Dni { get; set; }
        public bool IsDeleted { get; set; }
    }
}