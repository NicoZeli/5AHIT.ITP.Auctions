﻿namespace Model.Entity {
    [Table("BUY_AUCTION")]
    public class BuyAuction : Auction {
        [Required]
        [Decimal(8, 2)]
        public decimal MinimumPrice { get; set; }
    }
}
