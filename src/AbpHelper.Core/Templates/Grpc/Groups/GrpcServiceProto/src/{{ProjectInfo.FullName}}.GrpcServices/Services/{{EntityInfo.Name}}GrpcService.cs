using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using {{ProjectInfo.FullName}}.{{EntityInfo.RelativeDirectory}};
using Volo.Abp.ObjectMapping;

namespace {{ ProjectInfo.FullName }}.GrpcServices
{
    public class {{ EntityInfo.Name }}GrpcService : {{ EntityInfo.Name }}Grpc.{{ EntityInfo.Name }}GrpcBase
    {
        private readonly ILogger<{{ EntityInfo.Name }}GrpcService> _logger;
        private readonly I{{ EntityInfo.Name }}Service _{{EntityInfo.NameCamel}}Service;
        private readonly IObjectMapper _objectMapper;


        public {{ EntityInfo.Name }}GrpcService(ILogger<{{ EntityInfo.Name }}GrpcService> logger,
            I{{ EntityInfo.Name }}Service  {{EntityInfo.NameCamel}}Service, 
            IObjectMapper objectMapper
        )
        {
            _logger = logger;
            _{{EntityInfo.NameCamel}}Service = {{EntityInfo.NameCamel}}Service;
            _objectMapper = objectMapper;
        }
       
        public override async Task<{{ EntityInfo.Name }}ItemResponse> Get({{ EntityInfo.Name }}IDRequest request, ServerCallContext context)
        {
            var result = await _{{EntityInfo.NameCamel}}Service.GetByIdAsync(request.Id);
            var response= _objectMapper.Map<{{EntityInfo.RelativeDirectory}}.{{ EntityInfo.Name }}, {{ EntityInfo.Name }}ItemResponse>(result);
            return response;
        }

        public override async Task<{{ EntityInfo.Name }}BoolResponse> Delete({{ EntityInfo.Name }}IDRequest request, ServerCallContext context)
        {
            var {{EntityInfo.NameCamel}} = await _{{EntityInfo.NameCamel}}Service.GetByIdAsync(request.Id);

            await _{{EntityInfo.NameCamel}}Service.DeleteAsync({{EntityInfo.NameCamel}});

            return new {{ EntityInfo.Name }}BoolResponse() { Success = true };
        }

        public override async Task<{{ EntityInfo.Name }}BoolResponse> CreateOrUpdate({{ EntityInfo.Name }}CreateOrUpdateRequest request, ServerCallContext context)
        {
            if (request.Id.IsNullOrEmpty()) throw new UserFriendlyException("id不能为空");
            var model = await _{{EntityInfo.NameCamel}}Service.GetByIdAsync(request.Id);
            if (model == null)
            {
                model = new {{ EntityInfo.Name }}();
            }
            {{~ for prop in EntityInfo.Properties ~}}
                {{~ 
                    if prop.Type  == "DateTime?" || prop.Type  == "DateTime"
                  ~}}
            model.{{ prop.Name }} = request.{{ prop.Name }}.ToDateTime();
                {{~
                    else
                ~}}
            model.{{ prop.Name }} = request.{{ prop.Name }};
                 {{~
                     end
                 ~}}
            {{~ end ~}}
            await _{{EntityInfo.NameCamel}}Service.MergeAsync(model);
            return new {{ EntityInfo.Name }}BoolResponse() { Success = true };
        }

        public async override Task<{{ EntityInfo.Name }}PageResponse> PageAll({{ EntityInfo.Name }}PageRequest request, ServerCallContext context)
        {
            var query = await _{{EntityInfo.NameCamel}}Service.GetQueryableAllAsync();
            query = query.Skip((request.PageIndex -1)* request.PageSize).Take(request.PageSize).OrderByDescendingDynamic(request.OrderBy);
            var items = _objectMapper.Map<IList<{{EntityInfo.RelativeDirectory}}.{{ EntityInfo.Name }}>,IList<{{ EntityInfo.Name }}ItemResponse>>(query.ToList());

            var response = new {{ EntityInfo.Name }}PageResponse() { TotalCount= query.Count()};
            response.Items.Add(items);
            return response;
        }
    }
}