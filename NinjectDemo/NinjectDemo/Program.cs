using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace NinjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            ninjectKernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam",50M); ;
            ninjectKernel.Bind<ShoppingCart>().To<LimitShoppingCart>().WithPropertyValue("ItemLimit",200M);
            ninjectKernel.Bind<IValueCalculator>().To<IterativeValueCalculator>().WhenInjectedInto<LimitShoppingCart>();
            ShoppingCart cart = ninjectKernel.Get<ShoppingCart>();
            Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());

            Console.ReadLine();
        }
    }
}
