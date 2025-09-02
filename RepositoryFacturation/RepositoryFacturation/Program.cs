
using RepositoryFacturation.Domain;
using RepositoryFacturation.Services;
using System.Timers;
Console.WriteLine("Ingrese 1 si quiere trabajar con producto o 2 si quiere trabajar con facturas");
int opc = Convert.ToInt32(Console.ReadLine());
if (opc == 1)
{
    ProductServices ps = new ProductServices();
    List<Product> lp = new List<Product>();
    lp = ps.GetProduct();
    
    Console.WriteLine("si quiere borrar un producto ingrese un id (si no quiere borrar ninguno ingrese 0)");
    int pborrar = int.Parse(Console.ReadLine());
    if (pborrar == 0)
        Console.WriteLine("no se borro ningun elemento");
    else
        if (pborrar != null)

    {
        Product p1 = ps.GetPById(pborrar);
        Console.WriteLine("El producto con id " + p1.Id.ToString() + "es: " + p1.ToString());
        Console.WriteLine("esta seguro que desea borrar este producto? (1 es si o es no)");
        int pborrarDef = int.Parse(Console.ReadLine());
        if (pborrarDef == 1)
        {
            ps.DeleteProduct(pborrar);
        }
        else 
        {
            Console.WriteLine("no se borro el producto");
        }
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
    else
    {
        Product pn1 = ps.GetPById(pNuevo);
        if (pn1 != null)
        {
            Console.WriteLine("El producto elegido para actualizar es: " + pn1.ToString());
            Console.WriteLine("quiere editar este producto (1 es SI 0 es NO)");

            int opc1 = Convert.ToInt32(Console.ReadLine());
            if (opc1 == 1)
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
}
else
    if (opc == 2)
    {

    BillServices bs = new BillServices();
    List<Bills> lb = new List<Bills>();
    lb = bs.GetAllBills();
    
    Console.WriteLine("si quiere cancelar un factura ingrese un id (si no quiere cancelar ninguna ingrese 0)");
    int Bborrar = int.Parse(Console.ReadLine());
    if (Bborrar == 0)
        Console.WriteLine("no se borro ningun elemento");
    

    if (Bborrar != 0)
    {
        Bills b1 = bs.GetBillsbyId(Bborrar);
        Console.WriteLine("la factura con id " + b1.N_Bill.ToString() + "es: " + b1.ToString());
        Console.WriteLine("esta seguro que desea cancelar esta factura ? (1 es si o es no)");
        int pborrarDef = int.Parse(Console.ReadLine());
        if (pborrarDef == 1)
        {
            bs.DeleteBill(Bborrar);
        }
        else
        {
            Console.WriteLine("no se borro el producto");
        }
    }
    else
    {
        Console.WriteLine("no se encontro la factura con el id solicitado");
    }
    if (lb.Count > 0)

        foreach (Bills b in lb)
            Console.WriteLine(b);
    else
        Console.WriteLine("no Facturas");

    Console.WriteLine("si desea actualizar un producto ingresar el id correspondiente, si desea crear un nuevo ingrese 0");
    int bNuevo = Convert.ToInt32(Console.ReadLine());
    List<BillDetails> lbd = bs.GetBillDetails();
    List<Payment_Methods> lpm = bs.GetPaymentMethods() ;
    if (bNuevo == 0)
    {
        Bills bn = new Bills();
        {
            Console.WriteLine("Ingrese la fecha de la factura: ");
            bn.Date_bill = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el metodo de pago que utilizo: ");
            Console.WriteLine("los metodos de pago disponbles son: ");
            foreach (Payment_Methods pm in lpm)
                Console.WriteLine(pm);
            bn.Paym_meth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del cliente: ");
            bn.Client = Console.ReadLine().ToString();
            Console.WriteLine("Ingrese el numero de detalle");
            Console.WriteLine("Los Detalles Cargados son: ");
            foreach(BillDetails bd in lbd)
            {
                Console.WriteLine(bd);
            }

            bn.id_det = Convert.ToInt32(Console.ReadLine());
            bn.Cancelled = 0;
        }

        bs.SaveBill(bn);

    }
    else
    {
        Bills bn1 = bs.GetBillsbyId(bNuevo);
        if (bn1 != null)
        {
            Console.WriteLine("El producto elegido para actualizar es: " + bn1.ToString());
            Console.WriteLine("quiere editar este producto (1 es SI 0 es NO)");

            int opc1 = Convert.ToInt32(Console.ReadLine());
            if (opc1 == 1)
            {
                Console.WriteLine("Ingrese la fecha de la factura: ");
                bn1.Date_bill = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Ingrese el metodo de pago que utilizo: ");
                bn1.Paym_meth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del cliente: ");
                bn1.Client = Console.ReadLine().ToString();
                Console.WriteLine("Ingrese el numero de detalle");
                bn1.id_det = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ingrese el estado (1 es cancelada 0 es no cancelada)");
                bn1.Cancelled = Convert.ToInt32(Console.ReadLine());
                bs.SaveBill(bn1);

            }
            else { Console.WriteLine("se canecela la actualizacion"); }

        }

        else
        {
            Console.WriteLine("no se pudo encontrar el producto que desea actualizar");
        }
    }
}
    

  
