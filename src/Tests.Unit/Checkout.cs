using System.Globalization;

namespace Kata.ShoppingCart
{
    public class Checkout
    {
        private readonly IDiscounter _discounter;
        private readonly IPriceFinder _priceFinder;
        private int _total;

        public Checkout(IDiscounter discounter, IPriceFinder priceFinder)
        {
            _discounter = discounter;
            _priceFinder = priceFinder;
            _total = 0;
        }

        public int Total()
        {
            return _total;
        }

        public void Scan(string items)
        {
            foreach (var item in items.ToCharArray())
            {
                var discount = _discounter.DiscountFor(item.ToString(CultureInfo.InvariantCulture));
                _priceFinder.PriceFor(items);
                _total -= discount;
            }
        }
    }
}

