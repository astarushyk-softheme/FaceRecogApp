using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FaceRecog.Web.API.Swagger
{
    public class FileOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            var fileTypeParameters = context.ApiDescription.ParameterDescriptions.Where(x =>
                    x.ModelMetadata.ModelType == typeof(IFormFile)).ToList();

            operation.Parameters = operation.Parameters.Select(x =>
            {
                var fileTypeParameter = fileTypeParameters.FirstOrDefault(y => y.Name == x.Name);

                if (fileTypeParameter != null)
                {
                    return new NonBodyParameter
                    {
                        Name = fileTypeParameter.Name,
                        In = "formData",
                        Description = "File for upload",
                        Required = fileTypeParameter.IsRequired(),
                        Type = "file"
                    };
                }

                return x;
            })
            .ToList();
        }
    }
}
