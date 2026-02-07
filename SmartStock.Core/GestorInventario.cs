using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace SmartStock.Core
{
    /// <summary>
    /// Gestiona el inventario.
    /// </summary>
    public class GestorInventario
    {
        private List<Producto> inventario = new();
        private Producto[] escaparate = new Producto[5];

        public event EventHandler<StockBajoEventArgs> StockBajoDetectado;

        public void AgregarProducto(Producto p)
        {
            //asegura que el producto no sea nulo
            Debug.Assert(p != null);
            inventario.Add(p);
        }

        public Producto BuscarProducto(string id)
        {
            return inventario.FirstOrDefault(p => p.Id == id);
        }

        public void EliminarProducto(string id)
        {
            var p = BuscarProducto(id);
            if (p != null)
                inventario.Remove(p);
        }

        public void VenderProducto(string id, int cantidad)
        {
            var p = BuscarProducto(id);

            if (p == null)
                throw new Exception("el producto no ha sido encontrado");

            if (p.Stock < cantidad)
                throw new Exception("El stock no es suficiente");

            p.Stock -= cantidad;

            // Invocar al evento
            if (p.Stock < p.StockMinimo)
                StockBajoDetectado?.Invoke(this, new StockBajoEventArgs(p));
        }

        public List<Producto> ObtenerInventario()
        {
            return inventario;
        }

        public void AsignarEscaparate(int posicion, Producto p)
        {
            escaparate[posicion] = p;
        }
    }
}

