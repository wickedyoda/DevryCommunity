using System;

namespace DevryBot.Discord.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InteractionNameAttribute : Attribute
    {
        public string Name { get; }

        public InteractionNameAttribute(string name)
        {
            Name = name;
        }
    }
}