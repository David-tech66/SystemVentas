using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string InsertarVenta(int id_venta, int id_cliente, int id_vendedor, DateTime fecha, decimal subtotal, decimal vuelto, DataTable dtDetalles)
        {
            DVenta Obj      = new DVenta();
            Obj.Id_cliente  = id_cliente;
            Obj.Id_vendedor = id_vendedor;
            Obj.Fecha       = fecha;
            Obj.Subtotal    = subtotal;
            Obj.Vuelto      = vuelto;

            // LLAMAMOS AL METODO DETALLE DE VENTA
            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalleVenta detalle     = new DDetalleVenta();
                detalle.Id_venta          = Convert.ToInt32(row["id_venta"]);
                detalle.Id_producto1      = Convert.ToInt32(row["id_producto1"]);
                detalle.Cantidad_unitaria = Convert.ToInt32(row["cantidad_unitaria"]);
                detalle.Subtotal_venta    = Convert.ToDecimal(row["subtotal_venta"]);
                detalle.Vuelto            = Convert.ToDecimal(row["vuelto"]);
                detalles.Add(detalle);
            }
            // ENVIAMOS TODO LO QUE ES LA VENTA Y SU DETALLE
            return Obj.InsertarVenta(Obj, detalles);
        }

        //public static string InsertarDetalleVenta(int id_det_venta, int id_venta, int id_producto1, DateTime fecha_det, int cantidad_uni_det, decimal subtotal_det_vent)
        //{
        //    DDetalleVenta Obj = new DDetalleVenta();
        //    Obj.Id_venta = id_venta;
        //    Obj.Id_producto1 = id_producto1;
        //    Obj.Fecha_det = fecha_det;
        //    Obj.Cantidad_uni_det = cantidad_uni_det;
        //    Obj.Subtotal_det_vent = subtotal_det_vent;
            
        //    return Obj.InsertarDetalleVenta(Obj, ref DConexion.SqlCon, ref DConexion.SqlTra);
        //}
    }
}
