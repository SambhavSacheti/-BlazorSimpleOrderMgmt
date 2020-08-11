using System;

public class OrderDetails{
    public int Id { get; set; }

    public string OrderNumber { get; set; }

    public int ProductId { get; set; } 

    public string QuantityOrdered { get; set; }

    public decimal priceEach { get; set; }

    public string Comments { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdated { get; set; }

    public string UpdatedBy { get; set; }
}