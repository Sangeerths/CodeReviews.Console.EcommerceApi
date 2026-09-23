namespace Ecommerce.API.DTO.Sale;

public class SaleResponseDto
{
    public int SaleId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; }

    public decimal TotalPrice { get; set; }

    public List<SaleItemResponseDto> Items { get; set; } = new();
}

public class SaleItemResponseDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }
}
