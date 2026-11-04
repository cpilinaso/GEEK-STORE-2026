using System;
using System.Collections.Generic;
using System.Text;

namespace GEEK_STORE_2026
{
    public class Tienda
    {
        private List<ArticuloTienda> inventario; // Se guardan las clases hijas de ArticuloTienda, JS inventario solo es el nombre de la lista
        public double SaldoCaja { get; private set; }

        public Tienda() //constructor para dar valores
        {
            inventario = new List<ArticuloTienda>(); //empieza con una lista nueva y vacia
            SaldoCaja = 1000.0;
        }
        public void AgregarAlInventario(ArticuloTienda nuevoArticulo, int cantidadAComprar)
        {
            double costoTotal = nuevoArticulo.PrecioCosto * cantidadAComprar;
            if (SaldoCaja < costoTotal)
            {
                Console.WriteLine("No hay suficiente saldo en caja para comprar este artículo.");
                return;
            }
            else
            {
                SaldoCaja -= costoTotal;
                nuevoArticulo.Stock += cantidadAComprar;
                inventario.Add(nuevoArticulo);
                Console.WriteLine($"Articulo: {nuevoArticulo.Nombre} , agregado exitosamente!");
                Console.WriteLine($"Saldo actual: {SaldoCaja}");
            }
        }
        public void MostrarInventario()
        {
            Console.WriteLine("\n Inventario de la tienda: \n");
            foreach (ArticuloTienda articulo in inventario)
            {
                articulo.MostrarDetalles();
            }
        }
        public void VenderArticulo(int idArticulo, int cantidadAVender)
        {
            ArticuloTienda articuloEncontrado = inventario.Find(a => a.Id == idArticulo);
            if (articuloEncontrado != null)
            {
                if (articuloEncontrado.Stock >= cantidadAVender)
                {
                    double Total = ((IComercializable)articuloEncontrado).CalculartotalVenta(cantidadAVender);
                    articuloEncontrado.Stock -= cantidadAVender;
                    SaldoCaja += Total;
                    Console.WriteLine($"Se vendieron {cantidadAVender} unidades de {articuloEncontrado.Nombre}. Total de la venta: {Total}");
                    Console.WriteLine($"Venta realizada con éxito. Saldo actual: {SaldoCaja}");
                }
                else
                {
                    Console.WriteLine("No hay suficiente stock");
                }
            }
            else
            {
                Console.WriteLine("Articulo inexistente");
            }
        }

    }
}
