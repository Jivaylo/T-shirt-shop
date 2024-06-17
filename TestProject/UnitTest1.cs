using T_shirt.Data.Models;

namespace TestProject
{
    public class Tests
    {
      
        [Test]
        public void Can_Clear_Contents()
        {
   
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            target.Clear();

         
            Assert.IsEmpty(target.Lines);
        }
    }
}