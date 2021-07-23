using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using {{ProjectInfo.FullName }}.Controllers;
using {{ProjectInfo.FullName }}.{{EntityInfo.RelativeDirectory}}.Dtos;

namespace {{ ProjectInfo.FullName }}.Controllers
{
    [Route("/api/app/{{EntityInfo.Name}}")]
    public class {{ EntityInfo.Name }}Controller : {{ ProjectInfo.Name }}Controller
    {
        public {{ EntityInfo.Name }}Controller()
        {
            
        }
        public Task<{{ EntityInfo.Name}}Dto> CreateAsync(CreateUpdate{{EntityInfo.Name}}Dto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<{{EntityInfo.Name}}Dto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<{{ EntityInfo.Name }}Dto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<{{EntityInfo.Name}}Dto> UpdateAsync(string id, CreateUpdate{{EntityInfo.Name}}Dto input)
        {
            throw new NotImplementedException();
        }
    }
}