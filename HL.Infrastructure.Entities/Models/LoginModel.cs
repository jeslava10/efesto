using Dominus.Database.Attributes;

namespace WebApi.Models
{
    public class LoginModel
    {
        [DmsRequired("Login.UserName.Required")]
        public string UserName { get; set; }

        [DmsRequired("Login.Password.Required")]
        [DmsStringLength("Login.Password.Maxlength", 16)]
        public string Password { get; set; }

        public string TenantId { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

    }
}
