using System;
using System.Collections.Generic;

namespace COR
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Caner Tosuner", DateTime.Today, false, false);
            var product = new Product("ASUS PC", 1478.49m);

            var productDiscChain = new ProductDetailDiscountChain(customer, product);
            productDiscChain.CalculateDiscountPrice();
            Console.WriteLine("Price : " + product.Price + "\nDiscountPrice : " + product.DiscountedPrice);

            Console.ReadLine();
        }
    }

    public class ProductDetailDiscountChain
    {
        private readonly IList<IDiscount> _discounts = new List<IDiscount>();
        private readonly Customer _customer;
        private readonly Product _product;

        public ProductDetailDiscountChain(Customer customer, Product product)
        {
            _customer = customer;
            _product = product;

            _discounts.Add(new BirthdayDiscount(0.10m)); //%10
            _discounts.Add(new CompanyEmployeeDiscount(0.05m)); //&5
            _discounts.Add(new LoyalCustomerDiscount(0.06m)); //%6
        }

        public void CalculateDiscountPrice()
        {
            foreach (var discountItem in _discounts)
            {
                discountItem.Calculate(_customer, _product);
            }
        }
    }

    public interface IDiscount
    {
        void Calculate(Customer customer, Product product);
    }

    public class BirthdayDiscount : IDiscount
    {
        private readonly decimal _discountPercentage;
        public BirthdayDiscount(decimal discount)
        {
            _discountPercentage = discount;
        }

        public void Calculate(Customer customer, Product product)
        {
            if (customer.IsBirthday())
            {
                var newPrice = product.DiscountedPrice * _discountPercentage;
                product.DiscountedPrice = product.DiscountedPrice - newPrice;
            }
        }
    }

    public class CompanyEmployeeDiscount : IDiscount
    {
        private readonly decimal _discountPercentage;
        public CompanyEmployeeDiscount(decimal discount)
        {
            _discountPercentage = discount;
        }

        public void Calculate(Customer customer, Product product)
        {
            if (customer.IsCompanyEmployee)
            {
                var newPrice = product.DiscountedPrice * _discountPercentage;
                product.DiscountedPrice = product.DiscountedPrice - newPrice;
            }
        }
    }

    public class LoyalCustomerDiscount : IDiscount
    {
        private readonly decimal _discountPercentage;
        public LoyalCustomerDiscount(decimal discount)
        {
            _discountPercentage = discount;
        }

        public void Calculate(Customer customer, Product product)
        {
            if (customer.IsLoyalCustomer)
            {
                var newPrice = product.DiscountedPrice * _discountPercentage;
                product.DiscountedPrice = product.DiscountedPrice - newPrice;
            }
        }
    }
}
