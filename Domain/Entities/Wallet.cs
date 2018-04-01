namespace Domain.Entities
{
    public class Wallet
    {
        public Wallet()
        {
            WalletCoin = new Coin();
        }

        public int WalletId { get; set; }
        public string ApplicationUserId { get; set; }
        public string WalletAddress { get; set; }
        public Coin WalletCoin { get; set; }
        public double Amount { get; set; }
        public double Quote { get; set; }

        public virtual ApplicationUser WalletOwner { get; set; }
    }
}
