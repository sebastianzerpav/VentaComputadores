using System;
using System.Collections.Generic;

namespace VentaComputadores.API.Data.Models;

public partial class Computador
{
    public int NumeroUnicoComputador { get; set; }

    public int? IdTipoComputador { get; set; }

    public int? NitAgencia { get; set; }

    public string? NombreModelo { get; set; }

    public string? MarcaComputador { get; set; }

    public int? NumeroProcesadores { get; set; }

    public string? MarcaProcesadores { get; set; }

    public string? TipoAlmacenamiento { get; set; }

    public decimal? CapacidadAlmacenamientoGb { get; set; }

    public decimal? RamGb { get; set; }

    public string? ComponentesAdicionales { get; set; }

    public virtual TipoComputador? IdTipoComputadorNavigation { get; set; }

    public virtual Agencia? NitAgenciaNavigation { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
