using CrossCutting.EventBus.Abstractions;

namespace CrossCutting.Events.User
{
    public class Register: IEvent {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string GetFullName()
        {
            return Name + " " + Surname;
        }

        public Register(string username, string mail, string name, string surname)
        {
            Username = username;
            Mail = mail;
            Surname = surname;
        }

    }
}

