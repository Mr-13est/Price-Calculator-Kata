namespace PriceCalculatorKata;

public class Product : IProduct
{
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    
    public string ReportAboutPrice()
    {
        string messageOutput = $"Product price = {CalculateFinalPrice().ParseToDollars()}";
        if (IProduct.Discount > 0)
            messageOutput += $" with {Price.CalculateDiscountValue(IProduct.Discount).ParseToDollars()} discount.";

        return messageOutput;
    }

    public double CalculateFinalPrice()
    {
        double finalPrice = Price;
        finalPrice += Price.CalculateTaxValue(IProduct.Tax);
        finalPrice -= Price.CalculateDiscountValue(IProduct.Discount);
        return finalPrice;
    }

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
