using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class FriendViewModelClone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Best friends 4eva?")]
        public bool IsBestFriend { get; set; }
    }
}
