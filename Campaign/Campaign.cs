using System;

public class Campaign
{
    public string Name { get; set; } // Nome da campanha
    public string Description { get; set; } // Descrição
    public decimal DiscountPercentage { get; set; } // Percentual de desconto
    public DateTime StartDate { get; set; } // Data de início
    public DateTime EndDate { get; set; } // Data de fim
    public string Scope { get; set; } // Escopo ("Global", "Category", "Brand", "Product")
    public string Target { get; set; } // Categoria, marca ou ID do produto

    /// <summary>
    /// Verifica se a campanha está ativa no momento atual.
    /// </summary>
    public bool IsActive()
    {
        return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
    }

    /// <summary>
    /// Retorna uma representação em texto da campanha.
    /// </summary>
    public override string ToString()
    {
        return $"{Name} - {Description} | {DiscountPercentage}% off | Scope: {Scope} | Target: {Target} | Active: {IsActive()}";
    }
}


