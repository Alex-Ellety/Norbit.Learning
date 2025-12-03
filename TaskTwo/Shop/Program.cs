using static Shop.Program;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public int ProductId { get; set; }
            public string Category { get; set; }
            public double Price { get; private set; }
            public int Quantity { get; private set; }
        }

        public class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public double Price 
            {
                get
                {
                    return Price;
                }
                set
                {
                    Price = Product.Price;
                }
            }
            public bool ToBuy { get; set; }

            public CartItem(Product product, int quantity = 1)
            {
                Product = product;

                Quantity = quantity > 0 ? quantity : throw new ArgumentException("Количество товара должно быть больше 0");
            }

            public double GetTotalPrice() => Product.Price * Quantity;

            public void UpdateQuantity(int quantity)
            {
                if (quantity < 0)
                {
                    throw new ArgumentException("Количество товара должно быть больше 0");
                }

                Quantity = quantity;
            }

        }

        public class Cart
        {
            public double totalPrice;
            public double TotalPrice
            {
                get
                {
                    return totalPrice;
                }
                set
                {
                    totalPrice = value;
                }
            }

            public List<CartItem> itemsInCart = new List<CartItem>();

            public void AddItem(Product product, int quantity = 1)
            {
                itemsInCart.Add(new CartItem(product, quantity));
            }

            public void RemoveItem(Product product, int quantity = 1)
            {
                itemsInCart.Remove(new CartItem(product, quantity));
            }

            public double GetTotalPrice() => TotalPriceHelper.GetTotalPrice(itemsInCart);
        }
        class Order
        {
            public string OrderId { get; set; }
            public Customer Customer { get; set; }
            public DateTime OrderDate { get; set; }
            public List<CartItem> itemsInCart { get; set; }

            public double totalPrice;
            public double TotalPrice 
            {
                get
                {
                    return totalPrice;
                }
                set
                {
                    totalPrice = value;
                }
            }

            public double GetTotalPrice() => TotalPriceHelper.GetTotalPrice(itemsInCart);

            public List<CartItem> MarkItemsToBuy (List<CartItem> itemsInCart)
            {
                List<CartItem> result = new List<CartItem>();

                foreach (var item in itemsInCart)
                {
                    if (item.ToBuy)
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
        }

        class Payment
        {
            public string PaymentId { get; set; }
            public Customer Customer { get; set; }
            public double PaymentSum {  get; set; }
            public PaymentMethod Method { get; private set; }
            public PaymentStatus Status { get; private set; }
        }

        public enum PaymentStatus
        {
            /// <summary>
            /// В обработке
            /// </summary>
            Pending,
            /// <summary>
            /// Одобрен
            /// </summary>
            Approved,
            /// <summary>
            /// Отклонен
            /// </summary>
            Declined,
            /// <summary>
            /// Возврат средств
            /// </summary>
            Refunded
        }

        public enum PaymentMethod
        {
            /// <summary>
            /// Кредитной картой
            /// </summary>
            CreditCard,
            /// <summary>
            /// Наличными
            /// </summary>
            Cash,
            /// <summary>
            /// Банковским переводом
            /// </summary>
            BankTransfer
        }

        public static class TotalPriceHelper
        {
            public static double GetTotalPrice(List<CartItem> itemsInCart)
            {
                double totalPrice = 0;

                foreach (var item in itemsInCart)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                return totalPrice;
            }
        }
    }
}
