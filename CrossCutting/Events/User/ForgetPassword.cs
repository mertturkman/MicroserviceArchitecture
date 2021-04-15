using CrossCutting.EventBus.Abstractions;

namespace CrossCutting.Events.User
{
    public class ForgetPassword : IEvent
    {
        public string Mail { get; set; }
        public string Token { get; set; }

        public ForgetPassword(string mail, string token)
        {
            Mail = mail;
            Token = token;
        }
    }
}
