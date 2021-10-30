using System.Collections.Generic;
using AutoMapper;
using BusinessObject.Models;
using BusinessObject;

namespace BusinessLogic
{
    public class MapperConfigurationForModels
    {
        public Product MapperFromCreateProductModelToProduct(CreateProductModel newProduct)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateProductModel, Product>());
            var mapper = new Mapper(config);
            return mapper.Map<CreateProductModel, Product>(newProduct);
        }

        public Product MapperFromUpdateProductModelToProduct(UpdateProductModel editProduct)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateProductModel, Product>());
            var mapper = new Mapper(config);
            return mapper.Map<UpdateProductModel, Product>(editProduct);
        }
        public IndexProductModel MapperFromProductToIndexProductModel(Product product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, IndexProductModel>());
            var mapper = new Mapper(config);
            return mapper.Map<Product, IndexProductModel>(product);
        }
        public List<IndexProductForListModel> MapperFromProductToIndexProductForListModel(List<Product> product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, IndexProductForListModel>()
            .ForMember("Id", opt => opt.MapFrom(c => c.Id))
            .ForMember("ValueAndName", opt => opt.MapFrom(c => c.Value + " " + c.Name))
            );
            var mapper = new Mapper(config);
            return mapper.Map<List<Product>, List<IndexProductForListModel>>(product);
        }
    }
}
