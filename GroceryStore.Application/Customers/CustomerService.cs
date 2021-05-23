﻿using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GroceryStore.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public int Add(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            return  _customerRepository.Add(customer);
        }

        public CustomerDto Get(int id)
        {
            Customer customer = _customerRepository.Get(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public IEnumerable<CustomerDto> List()
        {
            IEnumerable<Customer> customers = _customerRepository.List();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public void Update(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Update(customer);
        }
        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
    }
}
