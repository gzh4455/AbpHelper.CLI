using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Volo.Abp;
using CommandLineBuilder = EasyAbp.AbpHelper.Core.Commands.CommandLineBuilder;

namespace EasyAbp.AbpHelper
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();


            using (var application = AbpApplicationFactory.Create<AbpHelperModule>(options =>
            {
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                application.Initialize();

                var parser = new CommandLineBuilder(application.ServiceProvider, "abphelper")
                    .AddAllRootCommands()
                    .UseDefaults()
                    .Build();
                //args = new string[] {"generate", "grpc", "Attachment","-d",@"E:\workspace\产品\科研全场景项目系统\abptest","--exclude",@"E:\workspace\产品\科研全场景项目系统\abptest\src\Clinbrain.SRCRM.XProject.GrpcServices\obj\Debug\net5.0\Protos"};
                args = new string[] {"generate", "grpc", "Attachment","-d",@"E:\workspace\产品\科研全场景项目系统\abptest" ,"--exclude",@"**/Protos"};
                // args = new string[] {"generate", "controller", "Project","-d",@"E:\workspace\产品\科研全场景项目系统\abptest"};
                //args = new string[] {"generate", "controller", "Project","-d",@"D:\\360安全浏览器下载\\XProject"};

                Log.Logger.Information(JsonConvert.SerializeObject(args));
                await parser.InvokeAsync(args);
            }
        }
    }
}