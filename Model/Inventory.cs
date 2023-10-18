namespace HospitalSystemManagement.Model
{
    public class Inventory
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
    }
}
