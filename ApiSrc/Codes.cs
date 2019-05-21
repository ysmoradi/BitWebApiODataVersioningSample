using Bit.Model.Contracts;
using Bit.OData.ODataControllers;
using System.Web.Http;

namespace ApiSrc
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProductsController : DtoController<ProductDto>
    {
        [Function]
        public virtual SingleResult<ProductDto> GetBestProduct()
        {
#if ApiV1 // compile level if based on version in C# code.

#elif ApiV2

#endif

            if (ODataConfig.Version == "ApiV1") // if based on version in C# code.
            {

            }
            else
            {

            }

            return SingleResult(new ProductDto { Id = 1, Name = "MyName" });
        }
    }
}
