using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CrossCutting.Events.User;
using User.Domain.SeedWork;

namespace User.Domain.AggregatesModel.UserAggregate
{
    public class UserToken : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public bool IsUsing { get; set; }

        public UserToken()
        { }
        
        public UserToken(Guid userId, string mail)
        {
            UserId = userId;
            Token = NewToken();

            AddIntegrationEvent(new ForgetPassword(mail, Token));
        }

        public void UseToken()
        {
            IsUsing = true;
        }

        private string NewToken()
        {
            int length = 32;
            byte[] bytes;
            string bytesBase64Url;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {

                bytes = new byte[length];
                rng.GetBytes(bytes);

                string base64 = Convert.ToBase64String(bytes);
                bytesBase64Url = base64.Replace('+', '-').Replace('/', '_');
            }

            return bytesBase64Url;
        }
    }
}