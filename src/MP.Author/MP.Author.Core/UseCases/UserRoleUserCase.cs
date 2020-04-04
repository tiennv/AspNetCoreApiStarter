using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public class UserRoleUserCase : IUserRoleUserCase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleUserCase(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
       

        public async Task<bool> Create(UserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            var response = await _userRoleRepository.Create(request);
            outputPort.Handle(response);
            return response.Success;
        }

        public async Task<bool> Delete(UserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            var response = await _userRoleRepository.Delete(request);
            outputPort.Handle(response);
            return response.Success;
        }

        public Task<bool> GetAllUser(IOutputPort<UserRoleDtoResponse> outputPort)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Handle(UserRoleDtoRequest request, IOutputPort<UserRoleDtoResponse> outputPort)
        {
            var objUserRoles = await _userRoleRepository.GetRoleByUserId(request.UserId);

            //var response = await _userRoleRepository.Create(request);

            await PopulatorUserRole(objUserRoles.Select(x => x.RoleName).ToList(), request.RoleIds, request.UserId);


            outputPort.Handle(new UserRoleDtoResponse(true, "", 200));
            return true;
        }

        private async Task PopulatorUserRole(List<string> currents, List<string> news, string userId)
        {
            var listStay = new List<string>();
            var listRemove = new List<string>();
            var listAdd = new List<string>();

            if (currents.Count > news.Count)
            {
                listStay = currents.Where(s => news.Any(n => n.Equals(s))).ToList();
            }
            else
            {
                // xem trong list news co item nao van giu, khong remove di
                listStay = news.Where(s => currents.Any(n => n.Equals(s))).ToList();
            }

            if (listStay != null && listStay.Count > 0)
            {
                // lay ra list add moi theo list news
                listAdd = news.Where(n => listStay.All(s => !s.Equals(n))).ToList();

                // list remove 
                listRemove = currents.Where(s => news.All(n => !n.Equals(s))).ToList();
            }
            else
            {
                listAdd = news;
                listRemove = currents;
            }


            var objAdd = new UserRoleDtoRequest(userId, "", listAdd);
            var objRemove = new UserRoleDtoRequest(userId, "", listRemove);
            
            if (objRemove != null && objRemove.RoleIds != null && objRemove.RoleIds.Count > 0)
            {
                await _userRoleRepository.Delete(objRemove);
            }

            if (objAdd != null && objAdd.RoleIds != null && objAdd.RoleIds.Count > 0)
            {
                await _userRoleRepository.Create(objAdd);
            }

        }
    }
}
