using AutoMapper;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Dto;
using MP.Author.Core.Dto.UseCaseRequests;
using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Helpers;
using MP.Author.Core.Interfaces;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MP.Author.Core.UseCases
{
    public sealed class MenusUseCase : IMenusUseCase
    {
        private readonly IMenusRepository _menusRepository;
        private readonly IMapper _mapper;
        public MenusUseCase(IMenusRepository menusRepository, IMapper mapper)
        {
            _menusRepository = menusRepository;
            _mapper = mapper;
        }
        public async Task<bool> Add(MenusDtoRequest request, IOutputPort<MenusDtoResponse> outputPort)
        {
            var entity = _mapper.Map<Menus>(request);
            var inserted = await _menusRepository.Add(entity);

            if (inserted != null)
            {
                outputPort.Handle(new MenusDtoResponse(_mapper.Map<MenusDto>(inserted), true, ""));
            }
            else
            {
                outputPort.Handle(new MenusDtoResponse(new[] { new Error(GlobalMessage.INSERT_FAIL_CODE, GlobalMessage.INSERT_FAIL_MES)}, false, GlobalMessage.INSERT_FAIL_MES));
            }

            return inserted != null;
        }

        public Task<bool> Handle(MenusDtoRequest message, IOutputPort<MenusDtoResponse> outputPort)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(MenusDtoRequest request, IOutputPort<MenusDtoResponse> outputPort)
        {
            var entity = await _menusRepository.GetById(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity.IsShow = request.IsShow;
                await _menusRepository.Update(entity);
                outputPort.Handle(new MenusDtoResponse(_mapper.Map<MenusDto>(entity), true, ""));
            }
            else
            {
                outputPort.Handle(new MenusDtoResponse(new[] { new Error(GlobalMessage.UPDATE_FAIL_CODE, GlobalMessage.UPDATE_FAIL_MES) }, false, GlobalMessage.UPDATE_FAIL_MES));
            }
            return true;
        }
    }
}
