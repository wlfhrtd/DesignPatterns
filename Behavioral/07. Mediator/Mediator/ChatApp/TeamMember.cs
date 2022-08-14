using System;

namespace Mediator.ChatApp
{
    public abstract class TeamMember
    {
        private Chatroom chatroom;

        public string Name { get; }


        public TeamMember(string name)
        {
            Name = name;
        }


        internal void SetChatroom(Chatroom chat)
        {
            chatroom = chat;
        }

        public void Send(string message)
        {
            chatroom.Send(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"From {from}: '{message}'");
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            chatroom.SendTo<T>(Name, message);
        }
    }
}
