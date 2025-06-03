using Modelo;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product c in CustomerData.Products)
            {
                if (c.Id == id) return c;
            }

            return null!;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = [];

            foreach (Product c in CustomerData.Products)
            {
                if (c.ProductName!.ToLower().Contains(name.ToLower()))
                {
                    ret.Add(c);
                }
            }

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return CustomerData.Products;
        }

        public bool Delete(Product product)
        {
            return CustomerData.Products.Remove(product);
        }

        public bool DeleteById(int id)
        {
            Product product = Retrieve(id);

            if (product != null) return Delete(product);

            return false;
        }

        public void Update(Product newProduct)
        {
            Product oldProduct = Retrieve(newProduct.Id);

            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.Description = newProduct.Description;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
        }

        public void Save(Product product)
        {
            product.Id = GetCount() + 1;
            CustomerData.Products.Add(product);
        }

        public int GetCount()
        {
            return CustomerData.Products.Count;
        }
    }
}