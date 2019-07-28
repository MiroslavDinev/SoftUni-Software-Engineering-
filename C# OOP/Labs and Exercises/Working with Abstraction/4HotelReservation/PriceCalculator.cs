namespace _4HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator(decimal pricePerDay, int days, Season season, DiscountType discountType)
        {
            this.PricePerDay = pricePerDay;
            this.Days = days;
            this.Season = season;
            this.Discount = discountType;
        }

        public decimal PricePerDay { get; set; }

        public int Days { get; set; }

        public Season Season { get; set; }

        public DiscountType Discount { get; set; }

        public decimal CalculatePrice()
        {
            int multiplier = (int)this.Season;
            decimal discount = (decimal)this.Discount/100;

            decimal initialPrice = this.PricePerDay * this.Days * multiplier;
            decimal discountPrice = initialPrice * discount;
            decimal finalPrice = initialPrice - discountPrice;
            return finalPrice;
        }
    }
}
