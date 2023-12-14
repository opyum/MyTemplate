namespace Plantoufle.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? FamilyId { get; set; }

    }

    public class FamilyModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdGroup { get; set; }

    }

    public class MissionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Done { get; set; }
        public int DeadlineType { get; set; }
        public DateTime DeadlineDate { get; set; }
    }

    public class TaskUserModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdTask { get; set; }
    }
}
