//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuntodeVenta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENT_CompraDetalle
    {
        public string NumeroFactura { get; set; }
        public int IdProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precioU { get; set; }
    
        public virtual BODE_PRODUCTO BODE_PRODUCTO { get; set; }
        public virtual VENT_CompraEncabezado VENT_CompraEncabezado { get; set; }
    }
}
