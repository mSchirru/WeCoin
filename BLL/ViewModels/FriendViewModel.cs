using System;
using System.ComponentModel;

namespace WebTest.ViewModels
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        [DisplayName("Best friends 4eva?")]
        public bool IsBestFriend { get; set; }
    }
}