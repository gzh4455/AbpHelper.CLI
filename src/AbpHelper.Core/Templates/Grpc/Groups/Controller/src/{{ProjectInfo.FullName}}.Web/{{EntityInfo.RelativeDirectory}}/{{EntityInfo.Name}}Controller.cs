using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using {{ProjectInfo.FullName }}.{{EntityInfo.RelativeDirectory}}.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;
using {{ProjectInfo.FullName }}.GrpcServices;
using System.Collections.Generic;
using System.Linq;
using {{ProjectInfo.FullName }}.Web;
    
namespace {{ ProjectInfo.FullName }}.Controllers
{
    [Route("/api/app/{{EntityInfo.Name}}")]
    public class {{ EntityInfo.Name }}Controller : AbpController
    {
        private readonly {{ EntityInfo.Name }}Grpc.{{ EntityInfo.Name }}GrpcClient _{{EntityInfo.NameCamel}}GrpcClient;
        private readonly IObjectMapper _objectMapper;

        public {{ EntityInfo.Name }}Controller({{ EntityInfo.Name }}Grpc.{{ EntityInfo.Name }}GrpcClient {{EntityInfo.NameCamel}}GrpcClient,
            IObjectMapper objectMapper)
        {
            _{{EntityInfo.NameCamel}}GrpcClient = {{EntityInfo.NameCamel}}GrpcClient;
            _objectMapper = objectMapper;
        }
        [HttpPost]
        public async Task SaveAsync(CreateUpdate{{ EntityInfo.Name }}Dto input)
        {
            var {{EntityInfo.NameCamel}} = _objectMapper.Map<CreateUpdate{{ EntityInfo.Name }}Dto, {{ EntityInfo.Name }}CreateOrUpdateRequest>(input);
            await _{{EntityInfo.NameCamel}}GrpcClient.CreateOrUpdateAsync({{EntityInfo.NameCamel}});
        }

        [HttpDelete]
        public async Task DeleteAsync(string id)
        {
            await _{{EntityInfo.NameCamel}}GrpcClient.DeleteAsync(new {{ EntityInfo.Name }}IDRequest() {Id = id});
        }

        [HttpGet]
        public async Task<{{ EntityInfo.Name }}Dto> GetAsync(string id)
        {
            var {{EntityInfo.NameCamel}} = await _{{EntityInfo.NameCamel}}GrpcClient.GetAsync(new {{ EntityInfo.Name }}IDRequest() {Id = id});
            return _objectMapper.Map<{{ EntityInfo.Name }}ItemResponse, {{ EntityInfo.Name }}Dto>({{EntityInfo.NameCamel}});
        }

        [HttpGet,Route("PageAll")]
        public async Task<PagedResultDto<{{ EntityInfo.Name }}Dto>> GetPageListAsync(PageRequestDto input)
        {
            var result = await _{{EntityInfo.NameCamel}}GrpcClient.PageAllAsync(new {{ EntityInfo.Name }}PageRequest()
            {
                OrderBy = input.Sorting, 
                PageIndex = input.PageIndex,
                PageSize = input.PageSize, 
                SearchKey = input.SearchKey
            });

            var items = _objectMapper.Map<List<{{ EntityInfo.Name }}ItemResponse>,List<{{ EntityInfo.Name }}Dto>>(result.Items.ToList());
            var response = new PagedResultDto<{{ EntityInfo.Name }}Dto>()
            {
                TotalCount = result.TotalCount,
                Items = items
            };
            return response;
        }
    }
}