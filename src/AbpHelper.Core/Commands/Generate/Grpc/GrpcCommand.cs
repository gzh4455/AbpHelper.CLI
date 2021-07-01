using System;
using EasyAbp.AbpHelper.Core.Steps;
using EasyAbp.AbpHelper.Core.Steps.Abp;
using EasyAbp.AbpHelper.Core.Steps.Common;
using EasyAbp.AbpHelper.Core.Workflow;
using EasyAbp.AbpHelper.Core.Workflow.Generate;
using EasyAbp.AbpHelper.Core.Workflow.Generate.Crud;
using EasyAbp.AbpHelper.Core.Workflow.Generate.Grpc;
using Elsa.Activities;
using Elsa.Expressions;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Core.Commands.Generate.Grpc
{
    public class GrpcCommand: CommandWithOption<GrpcCommandOption>
    {
        public GrpcCommand(IServiceProvider serviceProvider) : base(serviceProvider, "grpc", "Generate business service and controller files according to the specified entity")
        {
            
        }

        protected override IActivityBuilder ConfigureBuild(GrpcCommandOption option, IActivityBuilder activityBuilder)
        {
            var entityFileName = option.Entity + ".cs";

            return base.ConfigureBuild(option, activityBuilder)
                .AddOverwriteWorkflow()
                .Then<SetVariable>(
                    step =>
                    {
                        step.VariableName = VariableNames.TemplateDirectory;
                        step.ValueExpression = new LiteralExpression<string>("/Templates/Grpc");
                    })
                .Then<FileFinderStep>(
                    step =>
                    {
                        step.SearchFileName = new LiteralExpression(entityFileName);
                    })
                .Then<EntityParserStep>()
                .Then<BuildDtoInfoStep>()
                .Then<SetModelVariableStep>()
                .AddBusinessServiceGeneration()
                ;
        }
    }
}