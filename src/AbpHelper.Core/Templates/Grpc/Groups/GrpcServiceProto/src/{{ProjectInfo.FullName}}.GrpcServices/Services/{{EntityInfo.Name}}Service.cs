using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace {{ ProjectInfo.FullName }}.GrpcServices
{
    public class {{ EntityInfo.Name }}Service : {{ EntityInfo.Name }}.{{ EntityInfo.Name }}Base
    {
        private readonly ILogger<{{ EntityInfo.Name }}Service> _logger;

        public {{ EntityInfo.Name }}Service(ILogger<{{ EntityInfo.Name }}Service> logger)
        {
            _logger = logger;
        }
    }
}