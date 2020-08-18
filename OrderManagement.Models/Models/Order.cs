using System;

public class Order{
    public int Id { get; set; }
    public string OrderNumber { get; set; } 
    public OrderStatus Status { get; set; }

    public OrderDetails ODetails { get; set; }

    public decimal UnitPrice { get; set; }
    
    public DateTime CreationDate { get; set; }

    public DateTime LastUpdated { get; set; }

    public string UpdatedBy { get; set; }
}


public  enum OrderStatus{
 Ordered, Pending , Delivered, Cancelled
}