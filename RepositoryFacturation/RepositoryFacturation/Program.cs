
using RepositoryFacturation.Domain;
using RepositoryFacturation.Services;
ProductServices ps = new ProductServices();
List<Product> lp = new List<Product>();
lp = ps.GetProduct();
Product p1 = ps.GetPById(4);
Console.WriteLine("si quiere borrar un producto ingrese un id (si no quiere borrar ninguno ingrese 0)");
int pborrar = int.Parse(Console.ReadLine());
if (pborrar == 0)
    Console.WriteLine("no se borro ningun elemento");
else
    ps.DeleteProduct(pborrar);

if (p1 != null)
{
    Console.WriteLine("El producto con id " + p1.Id.ToString() + "es: " + p1.ToString());
}
else
{
    Console.WriteLine("no se encontro el producto con el id solicitado");
}
if (lp.Count > 0)

    foreach (Product p in lp)
    Console.WriteLine(p);
else 
    Console.WriteLine("no hay productos...");
    
