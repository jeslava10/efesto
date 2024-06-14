using HL.Infrastructure.Entities;

namespace WebApi.Models
{
    public class TokenModel
    {
        public string Token { get; set; }

        public Account Account { get; set; }

        public string TenantId { get; set; }

        public List<int> AssignedProfiles { get; set; }
        public List<string> Errors { get; set; }


    }
}
