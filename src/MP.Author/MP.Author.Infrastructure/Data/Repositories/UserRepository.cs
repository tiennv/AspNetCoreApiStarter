using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto.GatewayResponses.Repositories;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        public Task<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPassword(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetSingleBySpec(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> List(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
