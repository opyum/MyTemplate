using System.ComponentModel.DataAnnotations;
using Template.CrossCutting;

namespace TemplateX.CrossCutting
{
    public class UserRecordModel
    {
        [Key] // Identifie Id comme clé primaire
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = nameof(ResourcesText.RequiredName), ErrorMessageResourceType = typeof(ResourcesText))]
        [StringLength(100, ErrorMessageResourceName = nameof(ResourcesText.StringLengthName), ErrorMessageResourceType = typeof(ResourcesText))]
        public string Name { get; set; }    
        
        [Required(ErrorMessageResourceName = nameof(ResourcesText.RequiredName), ErrorMessageResourceType = typeof(ResourcesText))]
        [StringLength(100, ErrorMessageResourceName = nameof(ResourcesText.StringLengthName), ErrorMessageResourceType = typeof(ResourcesText))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = nameof(ResourcesText.RequiredLogin), ErrorMessageResourceType = typeof(ResourcesText))]
        [StringLength(50, ErrorMessageResourceName = nameof(ResourcesText.StringLengthLogin), ErrorMessageResourceType = typeof(ResourcesText))]
        public string Login { get; set; }

        [StringLength(50, ErrorMessageResourceName = nameof(ResourcesText.StringLengthRole), ErrorMessageResourceType = typeof(ResourcesText))]
        public string Role { get; set; }

        [Required(ErrorMessageResourceName = nameof(ResourcesText.RequiredPassword), ErrorMessageResourceType = typeof(ResourcesText))]
        [DataType(DataType.Password)]
        [PasswordRequirements]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [PasswordsMatch("Password", ErrorMessageResourceName = nameof(ResourcesText.PasswordConfirmError), ErrorMessageResourceType = typeof(ResourcesText))]
        public string ConfirmPassword { get; set; }

        [Phone(ErrorMessageResourceName = nameof(ResourcesText.InvalidPhone), ErrorMessageResourceType = typeof(ResourcesText))]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = nameof(ResourcesText.RequiredEmail), ErrorMessageResourceType = typeof(ResourcesText))]
        [EmailAddress(ErrorMessageResourceName = nameof(ResourcesText.InvalidEmail), ErrorMessageResourceType = typeof(ResourcesText))]
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
        public DateTime? DeadlineDate { get; set; }
    }

    public class TaskUserModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdTask { get; set; }
    }
}
