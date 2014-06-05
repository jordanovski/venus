namespace Venus.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Venus.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Venus.Data.VenusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Venus.Data.VenusContext context)
        {
            var tables = new List<Tables>
            {
                new Tables { TableNumber = "1" },
                new Tables { TableNumber = "2" },
                new Tables { TableNumber = "3" },
                new Tables { TableNumber = "4" },
                new Tables { TableNumber = "5" },
                new Tables { TableNumber = "6" },
                new Tables { TableNumber = "7" },
                new Tables { TableNumber = "8" }
            };
            tables.ForEach(s => context.Tables.AddOrUpdate(p => p.TableNumber, s));
            context.SaveChanges();

            var products = new List<Products>
            {
                new Products { Name = "Скопско", UnitPrice = 70, UnitsInStock = 3, },
                new Products { Name = "Златен даб", UnitPrice = 60, UnitsInStock = 3, },
                new Products { Name = "Кока кола", UnitPrice = 40, UnitsInStock = 3, },
                new Products { Name = "Пепси", UnitPrice = 40, UnitsInStock = 4, },
                new Products { Name = "Шопска салата", UnitPrice = 50, UnitsInStock = 4, },
                new Products { Name = "Сирење", UnitPrice = 100, UnitsInStock = 3, },
                new Products { Name = "Скара", UnitPrice = 200, UnitsInStock = 4, }
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var orders = new List<Orders>
            {
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "1").Id, OrderDate =new DateTime(2014,6,3) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "1").Id, OrderDate =new DateTime(2014,6,3) },                            
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "2").Id, OrderDate =new DateTime(2014,6,3) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "1").Id, OrderDate =new DateTime(2014,6,4) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "1").Id, OrderDate =new DateTime(2014,6,4) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "2").Id, OrderDate =new DateTime(2014,6,4) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "2").Id, OrderDate =new DateTime(2014,6,4) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "3").Id, OrderDate =new DateTime(2014,6,4) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "1").Id, OrderDate =new DateTime(2014,6,5) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "2").Id, OrderDate =new DateTime(2014,6,5) },
                new Orders { EmployeeId = 1, TableId = tables.Single(c => c.TableNumber== "3").Id, OrderDate =new DateTime(2014,6,5) }
            };

            orders.ForEach(s => context.Orders.AddOrUpdate(p => p.TableId, s));
            context.SaveChanges();

            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails { OrderId = 1, ProductId = products.Single(c => c.Name== "Скопско").Id, Quantity = 1 },
                new OrderDetails { OrderId = 1, ProductId = products.Single(c => c.Name== "Скара").Id, Quantity = 1 },                            
                new OrderDetails { OrderId = 2, ProductId = products.Single(c => c.Name== "Скопско").Id, Quantity = 1 },
                new OrderDetails { OrderId = 3, ProductId = products.Single(c => c.Name== "Златен даб").Id, Quantity = 1 },
                new OrderDetails { OrderId = 4, ProductId = products.Single(c => c.Name== "Кока кола").Id, Quantity = 1 },
                new OrderDetails { OrderId = 5, ProductId = products.Single(c => c.Name== "Пепси").Id, Quantity = 1 },
                new OrderDetails { OrderId = 6, ProductId = products.Single(c => c.Name== "Шопска салата").Id, Quantity = 3 },
                new OrderDetails { OrderId = 7, ProductId = products.Single(c => c.Name== "Сирење").Id, Quantity = 1 },
                new OrderDetails { OrderId = 8, ProductId = products.Single(c => c.Name== "Скара").Id, Quantity = 2 },
                new OrderDetails { OrderId = 9, ProductId = products.Single(c => c.Name== "Скопско").Id, Quantity = 1 },
                new OrderDetails { OrderId = 9, ProductId = products.Single(c => c.Name== "Скара").Id, Quantity = 1 }
            };
            orderDetails.ForEach(s => context.OrderDetails.AddOrUpdate(p => p.ProductId, s));
            context.SaveChanges();
        }
    }
}
