using System;
using System.Data.Common;
using System.Linq;
using Crosslog.TestRecrutement.DataAccess;
using Crosslog.TestRecrutement.DataAccess.Dto;
using Crosslog.TestRecrutement.Library.BusinessEntity;
using Crosslog.TestRecrutement.Library.Factory;

namespace Crosslog.TestRecrutement.Library
{
    public class CustomerBusiness : BaseBusiness, ICustomerBusiness
    {
        private DbConnection _connection;

        public DbConnection Connection
        {
            get
            {
                _connection = GetConnection();
                return _connection;
            }
        }

        public CustomerListEntity GetCustomers()
        {
            try
            {
                var lstCustomers = UnityFactory.Instance.Get<ICustomerDataAccess>().GetCustomers(Connection);

                return CustomersListToMapp(lstCustomers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCustomer(CustomerEntity customer)
        {
            try
            {
                var customerDto = CustomerDtoToMapp(customer);
                return UnityFactory.Instance.Get<ICustomerDataAccess>().UpdateCustomer(customerDto, Connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CustomerEntityDto CustomerDtoToMapp(CustomerEntity customer)
        {
            if (customer == null)
            {
                return null;
            }

            var customerDto = new CustomerEntityDto
            {
                City = customer.City,
                ZipCode = customer.ZipCode,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = customer.Address,
                LastName = customer.LastName,
                FirstName = customer.FirstName,
                CustomerId = customer.CustomerId
            };

            return customerDto;
        }

        private CustomerListEntity CustomersListToMapp(CustomerListEntityDto lstCustomerDto)
        {
            var lstCustomers = new CustomerListEntity();
            if (lstCustomerDto != null)
            {
                lstCustomers.AddRange(lstCustomerDto.Select(customerDto => new CustomerEntity
                {
                    CustomerId = customerDto.CustomerId,
                    Address = customerDto.Address,
                    City = customerDto.City,
                    Email = customerDto.Email,
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    OrderCount = customerDto.OrderCount,
                    OrderNumber = customerDto.OrderNumber,
                    Phone = customerDto.Phone,
                    ZipCode = customerDto.ZipCode,
                    TotalAmount = customerDto.TotalAmount
                }));
            }
            return lstCustomers;
        }
    }
}