using System;
using System.Collections.Generic;

namespace GuardianPROWebServis.ModelDTO
{
    public partial class AuthorizationDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        
        public EmailDTO? EmailNavigation { get; set; } = new EmailDTO();
    }
}
