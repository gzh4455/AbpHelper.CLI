using EasyAbp.AbpHelper.Core.Steps.Common;
using Elsa.Scripting.JavaScript;
using Elsa.Services;

namespace EasyAbp.AbpHelper.Core.Workflow.Generate.Grpc
{
    public static class ControllerGenerationWorkflow
    {
        public  static IActivityBuilder AddControllerGeneration(this IActivityBuilder activityBuilder)
        {
            return activityBuilder
                .Then<GroupGenerationStep>(step =>
                {
                    step.GroupName = "Controller";
                    step.TemplateDirectory = new JavaScriptExpression<string>(VariableNames.TemplateDirectory);
                });
        }
    }
}