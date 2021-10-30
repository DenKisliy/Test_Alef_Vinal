using BusinessObject;
using BusinessObject.Models;
using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class SendQuery
    {
        private MapperConfigurationForModels mapperConfiguration;
        private ValidatorContext validatorContext;
        private Query query;  

        public SendQuery()
        {
            validatorContext = new ValidatorContext();
            mapperConfiguration = new MapperConfigurationForModels();
            query = new Query();
        }

        public void CreateProduct(CreateProductModel newProduct)
        {
            if (validatorContext.ValidateCreateProduct(newProduct))
            {
                query.CreateProduct(mapperConfiguration.MapperFromCreateProductModelToProduct(newProduct));
            }
        }

        public void UpdateProduct(UpdateProductModel updateProduct)
        {
            if (validatorContext.ValidateUpdateProduct(updateProduct))
            {
                query.UpdateProduct(mapperConfiguration.MapperFromUpdateProductModelToProduct(updateProduct));
            }
        }
        public IndexProductModel GetProduct(int id)
        {
            return mapperConfiguration.MapperFromProductToIndexProductModel(query.GetProduct(id));
        }

        public List<IndexProductForListModel> GetListProducts()
        {
            return mapperConfiguration.MapperFromProductToIndexProductForListModel(query.GetListProducts());
        }
    }
}
