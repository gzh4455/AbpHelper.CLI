using EasyAbp.AbpHelper.Core.Steps;
using EasyAbp.AbpHelper.Core.Steps.Common;
using Elsa.Scripting.JavaScript;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Core.Workflow.Generate.Grpc
{
    public static class BusinessServiceGenerationWorkflow
    {
        public static IActivityBuilder AddBusinessServiceGeneration(this IActivityBuilder builder)
        {
            return builder
                .Then<GroupGenerationStep>(step =>
                {
                    step.GroupName = "Service";
                    step.TemplateDirectory = new JavaScriptExpression<string>(VariableNames.TemplateDirectory);
                });
        }
    }
}