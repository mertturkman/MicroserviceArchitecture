using CrossCutting.EventBus.Abstractions;

namespace CrossCutting.Events.User
{
    public class Register: IEvent {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string GetFullName()
        {
            return Name + " " + Surname;
        }

        public Register(string mail, string name, string surname)
        {
            Mail = mail;
            Name = name;
            Surname = surname;
        }

    }
}

