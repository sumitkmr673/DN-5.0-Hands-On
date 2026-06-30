using Microsoft.EntityFrameworkCore;
using System.Linq;
using var context = new AppDbContext();

Console.WriteLine("--- LAB 7: LINQ QUERIES ---");

// 1. Filter and Sort 
Console.WriteLine("\n--- FILTERED & SORTED (> 1000) ---");
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

foreach (var p in filtered)
{
    Console.WriteLine($"{p.Name} - {p.Price}");
}

// 2. Project into DTO (Anonymous Type)

Console.WriteLine("\n--- DTO PROJECTION ---");
var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();

foreach (var dto in productDTOs)
{
    Console.WriteLine($"DTO: {dto.Name} @ {dto.Price}");
}

// -----------------------------LAB 6-------------------------------

// Console.WriteLine("--- LAB 6: UPDATE & DELETE ---");

// // 1. Update a Product 
// var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
// if (product != null)
// {
//     product.Price = 70000;
//     await context.SaveChangesAsync();
//     Console.WriteLine($"Updated Laptop price to: {product.Price}");
// }

// // 2. Delete a Product 
// var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
// if (toDelete != null)
// {
//     context.Products.Remove(toDelete);
//     await context.SaveChangesAsync();
//     Console.WriteLine($"Deleted product: {toDelete.Name}");
// }

// // 3. Verify the final database state
// Console.WriteLine("\n--- REMAINING PRODUCTS ---");
// var remainingProducts = await context.Products.ToListAsync();
// foreach (var p in remainingProducts)
// {
//     Console.WriteLine($"{p.Name} - {p.Price}");
// }

// -----------------------------LAB 5-------------------------------

// // 1. Retrieve All Products
// Console.WriteLine("--- ALL PRODUCTS ---");
// var products = await context.Products.ToListAsync();
// foreach (var p in products)
// {
//     Console.WriteLine($"{p.Name} - {p.Price}");
// }

// // 2. Find by ID
// Console.WriteLine("\n--- FIND BY ID (1) ---");
// var product = await context.Products.FindAsync(1);
// Console.WriteLine($"Found: {product?.Name}");

// // 3. FirstOrDefault with Condition
// Console.WriteLine("\n--- EXPENSIVE ITEM ---");
// var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
// Console.WriteLine($"Expensive: {expensive?.Name}");

// -----------------------------LAB 4-------------------------------
// 
// using var context = new AppDbContext();

// var electronics = new Category { Name = "Electronics" };
// var groceries = new Category { Name = "Groceries" };
// await context.Categories.AddRangeAsync(electronics, groceries);

// var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
// var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
// await context.Products.AddRangeAsync(product1, product2);

// await context.SaveChangesAsync();