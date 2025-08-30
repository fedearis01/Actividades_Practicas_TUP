
using RepositoryFacturation.Domain;
using RepositoryFacturation.Services;
using System.Timers;
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

Console.WriteLine("si desea actualizar un producto ingresar el id correspondiente, si desea crear un nuevo ingrese 0");
int pNuevo = Convert.ToInt32(Console.ReadLine());
if (pNuevo == 0)
{
    Product pn = new Product();
    {
        Console.WriteLine("Ingrese el nombre: ");
        pn.N_Product = Console.ReadLine().ToString();
        Console.WriteLine("Ingrese el Precio");
        pn.unit_price = Convert.ToInt32(Console.ReadLine());
        pn.Active = 1;
    }

    ps.SaveProduct(pn);

}
else { 
    Product pn1 = ps.GetPById(pNuevo);
    if (pn1 != null)
    {
        Console.WriteLine("El producto elegido para actualizar es: " + pn1.ToString());
        Console.WriteLine("quiere editar este producto (1 es SI 0 es NO)");
        
        int opc =Convert.ToInt32(Console.ReadLine());
        if (opc == 1)
        {
            Console.WriteLine("Ingrese el nuevo  nombre: ");
            pn1.N_Product = Console.ReadLine().ToString();
            Console.WriteLine("Ingrese el nuevo Precio");
            pn1.unit_price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo valor de Active (1 o 0)");
            pn1.Active = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("se actualizo el producto");
            ps.SaveProduct(pn1);
        }
        else { Console.WriteLine("se canecela la actualizacion"); }
            
    }

    else
    {
        Console.WriteLine("no se pudo encontrar el producto que desea actualizar");
    }
}

  
