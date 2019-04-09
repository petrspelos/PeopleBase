using System;

namespace PeopleBase.Entities
{
    internal class Person
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Email { get; set; }
        internal DateTime DateOfBrith { get; set; }
        internal Gender Gender { get; set; }
    }
}
