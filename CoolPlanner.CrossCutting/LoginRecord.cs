using System.ComponentModel.DataAnnotations;

namespace CoolPlanner.CrossCutting
{
    public partial record AccessTokenResponse
    {

        public string TokenType { get; set; }

        
        public string AccessToken { get; set; }

        
        public long ExpiresIn { get; set; }

       
        public string RefreshToken { get; set; }

    }

   
    public partial record Family
    {
        
        public int Id { get; set; }

        
        public int IdUser { get; set; }

       
        public int IdGroup { get; set; }

       
        public System.Collections.Generic.ICollection<FamilyMember> Users { get; set; }

    }

   
    public partial record FamilyMember
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

       
        public string Role { get; set; }

       
        public string PhoneNumber { get; set; }

        
        public string Email { get; set; }

       
        public int? FamilyId { get; set; }

        
        public Family Family { get; set; }

       
        public System.Collections.Generic.ICollection<TaskUser> TaskUsers { get; set; }

    }

   
    public partial record ForgotPasswordRequest
    {
        
        public string Email { get; set; }

    }

   
    public partial record HttpValidationProblemDetails
    {
       
        public string Type { get; set; }

       
        public string Title { get; set; }

        public int? Status { get; set; }

        public string Detail { get; set; }

        public string Instance { get; set; }

        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<string>> Errors { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

   
    public partial record InfoRequest
    {
        public string NewEmail { get; set; }

        public string NewPassword { get; set; }

        public string OldPassword { get; set; }

    }

   
    public partial record InfoResponse
    {
        
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

    }

   
    public partial record LoginRequest
    {
        
        public string Email { get; set; }

        public string Password { get; set; }

        public string TwoFactorCode { get; set; }

        public string TwoFactorRecoveryCode { get; set; }

    }

   
    public partial record Mission
    {
        
        public int Id { get; set; }

       
        public string Title { get; set; }

        public string Body { get; set; }

        public bool Done { get; set; }

        public int DeadlineType { get; set; }

        public System.DateTimeOffset DeadlineDate { get; set; }

       
        public System.Collections.Generic.ICollection<TaskUser> TaskUsers { get; set; }

    }

   
    public partial record RefreshRequest
    {
       
        public string RefreshToken { get; set; }

    }

   
    public partial record RegisterRequest
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, ErrorMessage = "Le {0} doit être au moins {2} caractères de longueur.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

   
    public partial record ResendConfirmationEmailRequest
    {
        
        public string Email { get; set; }

    }

   
    public partial record ResetPasswordRequest
    {
        
        public string Email { get; set; }

        public string ResetCode { get; set; }

        public string NewPassword { get; set; }

    }

   
    public partial record TaskUser
    {
        
        public int Id { get; set; }

        
        public int IdUser { get; set; }

        public int IdTask { get; set; }

        public FamilyMember User { get; set; }

        public Mission Task { get; set; }

    }

   
    public partial record TwoFactorRequest
    {
        public bool? Enable { get; set; }

        public string TwoFactorCode { get; set; }

        public bool ResetSharedKey { get; set; }

        public bool ResetRecoveryCodes { get; set; }
        public bool ForgetMachine { get; set; }

    }

   
    public partial record TwoFactorResponse
    {
        public string SharedKey { get; set; }

        public int RecoveryCodesLeft { get; set; }

        public System.Collections.Generic.ICollection<string> RecoveryCodes { get; set; }

        public bool IsTwoFactorEnabled { get; set; }

        public bool IsMachineRemembered { get; set; }

    }

   
    public partial record UserModel
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
}
