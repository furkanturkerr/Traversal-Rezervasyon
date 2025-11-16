namespace Traversal_Rezervasyon.Areas.Admin.Models
{
    public class BookingExchenceViewModel2
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public BookingExchangeData data { get; set; }
    }

    public class BookingExchangeData
    {
        public string base_currency_date { get; set; }
        public string base_currency { get; set; }
        public List<Exchange_Rate> exchange_rates { get; set; }
    }

    public class Exchange_Rate
    {
        public string currency { get; set; }
        public string exchange_rate_buy { get; set; }
    }
}