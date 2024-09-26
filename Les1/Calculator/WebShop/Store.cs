namespace WebShop
{
    public class Store
    {
        #region Fields

        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();

        #endregion Fields

        #region Public Methods

        public void AddInventory(Product product, int quantity)
        {
            if (inventory.ContainsKey(product))
            {
                inventory[product] += quantity;
            }
            else
            {
                inventory.Add(product, quantity);
            }
        }

        public bool HasInventory(Product product, int quantity)
        {
            return inventory[product] >= quantity;
        }

        public void RemoveInventory(Product product, int quantity)
        {
            inventory[product] -= quantity;
        }

        public int GetInventory(Product product)
        {
            return inventory[product];
        }

        #endregion Public Methods
    }
}