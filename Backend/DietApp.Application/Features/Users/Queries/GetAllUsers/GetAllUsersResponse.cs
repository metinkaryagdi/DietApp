namespace DietApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public Guid Id { get; set; } // <-- Ekledik
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double TargetWeight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
