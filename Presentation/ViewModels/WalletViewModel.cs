namespace Presentation.ViewModels
{
    public class WalletViewModel
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string WalletAddress { get; set; }
        public string Name { get; set; }
        public string Algorithm { get; set; }
        public string Initials { get; set; }
        public double Amount { get; set; }
        public double Quote { get; set; }

        public UserViewModel WalletOwner { get; set; }
    }
}