//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace np_website.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ForumUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Homepage { get; set; }
        public string Interests { get; set; }
        public int PostsCount { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public bool Disabled { get; set; }
        public string ActivationCode { get; set; }
        public string AvatarFileName { get; set; }
        public string Signature { get; set; }
        public Nullable<System.DateTime> LastLogonDate { get; set; }
        public int ReputationCache { get; set; }
        public string OpenIdUserName { get; set; }
        public bool HidePresence { get; set; }
        public bool UseGravatar { get; set; }
        public string TwitterUserName { get; set; }
        public string FacebookID { get; set; }
    }
}
