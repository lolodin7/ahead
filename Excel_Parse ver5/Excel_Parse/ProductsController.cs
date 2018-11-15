using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Parse
{
    class ProductsController
    {
        private ProductTypesController ptController;
        private List<ProductTypesModel> ptList;

        public ProductsController()
        {
            ptController = new ProductTypesController(this);


        }
    }
}
