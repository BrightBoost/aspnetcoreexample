//using Microsoft.AspNetCore.Mvc;

//namespace MyFirstAPI.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ProductController : Controller
//    {
//        public static List<Product> products = new List<Product>()
//        {
//            { new Product(1, "muis", "fantastische muis", "computerspullen", 15.0m) },
//            { new Product(2, "keyboard", "fantastische keyboard", "computerspullen", 25.0m) },
//            { new Product(3, "tas", "fanTAStisch", "computerspullen", 35.0m) }
//        };

//        [HttpGet]
//        public List<Product> GetProducts()
//        {
//            return products;
//        }

//        [HttpGet("/{id}")]
//        public Product GetProductById(int id)
//        {
//            return products.Where(p => p.Id == id).First();
//        }

//        [HttpPost]
//        public Product AddProduct(Product product)
//        {
//            // in het echt kan dit niet, id's mogen nooit twee keer uitgegeven worden
//            product.Id = products.Count() + 1;
//            products.Add(product);
//            return product;
//        }

//        [HttpPut]
//        public bool UpdateProduct(Product product)
//        {
//            int i = products.IndexOf(products.Where(p => p.Id == product.Id).First());
//            if(i >= 0)
//            {
//                products[i] = product;
//                return true;
//            }
//            return false;

//        }

//        [HttpDelete("/{id}")] 
//        public bool DeleteProduct(int id) 
//        {
//            return products.Remove(products.Where(p => p.Id == id).First());
//        }
//    }
//}
