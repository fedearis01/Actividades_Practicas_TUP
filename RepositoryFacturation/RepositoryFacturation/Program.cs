
using RepositoryFacturation.Domain;
using RepositoryFacturation.Services;
ProductServices ps = new ProductServices();
List<Product> lp = new List<Product>();
lp = ps.GetProduct();
if (lp.Count > 0)

    foreach (Product p in lp)
        Console.WriteLine(p);
else Console.WriteLine("no hay productos...");