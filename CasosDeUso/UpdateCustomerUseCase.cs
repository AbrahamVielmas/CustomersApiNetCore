using CustomersApi.Dtos;
using CustomersApi.Repositories;

namespace CustomersApi.CasosDeUso
{
    public interface IUpdateCustomerUseCase
    {
        Task<CustomerDto> Execute(CustomerDto customer);
    }

    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public UpdateCustomerUseCase(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }

        public async Task<CustomerDto> Execute(Dtos.CustomerDto customer)
        {
            var entity = await _customerDatabaseContext.Get((long)customer.Id);
            if (entity == null)
            {
                return null;
            }

            entity.Id = customer.Id;
            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Email = customer.Email;
            entity.Phone = customer.Phone;
            entity.Address = customer.Address;

            await _customerDatabaseContext.Update(entity);
            return entity.ToDto();

        }
    }
}
