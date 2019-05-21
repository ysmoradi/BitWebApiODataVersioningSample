using Bit.Model.Contracts;
using Bit.OData.ODataControllers;
using System.Web.Http;

namespace ApiSrc
{
    public class CustomerDto : IDto
    {
        public int Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }
    }

    public class CustomersController : DtoController<CustomerDto>
    {
        [Function]
        public virtual SingleResult<CustomerDto> GetBestCustomer()
        {
            return SingleResult(new CustomerDto { Id = 1, FName = "MyName", LName = "MyLastName" });
        }
    }
}
