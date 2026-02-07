using SmartStock.Core;

GestorInventario gestor = new();
// Suscripcion al evento de stock bajo
gestor.StockBajoDetectado += (s, e) =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Stock bajo de {e.Producto.Nombre}");
    Console.ResetColor();
};

bool salir = false;
// Menu
while (!salir)
{
    Console.WriteLine("1.Alta 2.Baja 3.Vender 4.Ver 5.Salir");
    var opcion = Console.ReadLine();

    try
    {
        switch (opcion)
        {
            case "1":
                Console.Write("ID: ");
                string id = Console.ReadLine();

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                Producto p = new Producto(id, nombre, precio, 10, 3, CategoriaProducto.Electronica);
                gestor.AgregarProducto(p);
                break;

            case "2":
                Console.Write("ID: ");
                gestor.EliminarProducto(Console.ReadLine());
                break;

            case "3":
                Console.Write("ID: ");
                string idVenta = Console.ReadLine();
                Console.Write("Cantidad: ");
                int cant = int.Parse(Console.ReadLine());

                gestor.VenderProducto(idVenta, cant);
                break;

            case "4":
                foreach (var prod in gestor.ObtenerInventario())
                    Console.WriteLine($"{prod.Id} - {prod.Nombre} - Stock: {prod.Stock}");
                break;

            case "5":
                salir = true;
                break;
        }
    }
    catch (Exception ex)
    {
        // Captura los errores pero no llega a cerrar la aplicación
        Console.WriteLine($"Error: {ex.Message}");
    }
}
