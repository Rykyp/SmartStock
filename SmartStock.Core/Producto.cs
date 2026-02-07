using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Core
{
    /// <summary>
    /// Clase Producto
    /// Validaciones de datos y el control del stock.
    /// </summary>
    public class Producto
    {
        private string _id;
        private string _nombre;
        private decimal _precio;
        private int _stock;
        private int _stockMinimo;

        public string Id
        {
            get => _id;
            set
            {
                // Validacion para evitar los ID vacios
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("id incorrecto");
                _id = value;
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                // Evita nombres vacios
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nombre incorrecto");
                _nombre = value;
            }
        }
        /// <summary>
        /// el precio del producto no puede ser negativo.
        /// </summary>
        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("precio negativo");
                _precio = value;
            }
        }
        /// <summary>
        /// Stock o productos disponibles.
        /// </summary>
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                    throw new ArgumentException("stock invalido");
                _stock = value;
            }
        }

        public int StockMinimo
        {
            get => _stockMinimo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("stock minimo invalido");
                _stockMinimo = value;
            }
        }

        public CategoriaProducto Categoria { get; set; }

        public Producto(string id, string nombre, decimal precio, int stock, int stockMinimo, CategoriaProducto categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            StockMinimo = stockMinimo;
            Categoria = categoria;
        }
    }
    public class StockBajoEventArgs : EventArgs
    {
        public Producto Producto { get; }

        public StockBajoEventArgs(Producto producto)
        {
            Producto = producto;
        }
    }
}

