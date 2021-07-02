using EasyAbp.AbpHelper.Core.Steps.Common;
using Elsa.Scripting.JavaScript;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Core.Workflow.Generate.Grpc
{
    public static class GrpcProtobufFileGenerationWorkflow
    {
        public static IActivityBuilder AddGrpcProtobufFileGeneration(this IActivityBuilder builder)
        {
            return builder
                .Then<GroupGenerationStep>(step =>
                {
                    step.GroupName = "GrpcServiceProto";
                    step.TemplateDirectory = new JavaScriptExpression<string>(VariableNames.TemplateDirectory);
                });
        }
    }
}