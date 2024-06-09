using T_shirt.Data.Models;

namespace TestProject
{
    public class Tests
    {
        [Test]
        public void Can_Add_New_Lines()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equals(2, results.Length);
            Assert.Equals(p1, results[0].Product);
            Assert.Equals(p2, results[1].Product);
        }

        [Test]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines
            .OrderBy(c => c.Product.ProductID).ToArray();

            // Assert
            Assert.Equals(2, results.Length);
            Assert.Equals(11, results[0].Quantity);
            Assert.Equals(1, results[1].Quantity);
        }

        [Test]
        public void Can_Remove_Line()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.IsEmpty(target.Lines.Where(c => c.Product == p2));
            Assert.Equals(2, target.Lines.Count());
        }

        [Test]
        public void Calculate_Cart_Total()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            // Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.Equals(450M, result);
        }

        [Test]
        public void Can_Clear_Contents()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            // Act
            target.Clear();

            // Assert
            Assert.IsEmpty(target.Lines);
        }
    }
}