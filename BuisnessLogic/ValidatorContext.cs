using System;
using BusinessObject.Models;

namespace BusinessLogic
{
    public class ValidatorContext
    {
        private CreateProductValidator createProductValidator;
        private UpdateProductValidator updateProductValidator;
        public ValidatorContext()
        {
            createProductValidator = new CreateProductValidator();
            updateProductValidator = new UpdateProductValidator();
        }

        public bool ValidateCreateProduct(CreateProductModel product)
        {
            var result = createProductValidator.Validate(product);

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return result.IsValid;
        }
        public bool ValidateUpdateProduct(UpdateProductModel product)
        {
            var result = updateProductValidator.Validate(product);

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return result.IsValid;
        }
    }
}
