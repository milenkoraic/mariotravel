using EnsureThat;
using Fluid;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace MarioTravel.Core.BLL.Services.EmailTemplate.Service
{
    public class TemplateEngine
    {
        private static readonly ConcurrentDictionary<string, FluidTemplate> registry = new ConcurrentDictionary<string, FluidTemplate>();

        public void RegisterTemplate(string templateName, string templatePath)
        {
            EnsureArg.IsNotNullOrEmpty(templateName, nameof(templateName));
            EnsureArg.IsNotNullOrEmpty(templatePath, nameof(templatePath));

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template {templateName} file not found at location {templatePath}");
            }

            var templateFileContent = File.ReadAllText(templatePath);

            if (!FluidTemplate.TryParse(templateFileContent, out var template))
            {
                throw new FormatException($"Can't parse template {templateName} from file {templatePath}");
            }

            registry.TryAdd(templateName, template);
        }

        public string Render(string templateName, params (string ModelPropertyName, ITemplateModel ModelProperty)[] modelMapping)
        {
            if (!registry.TryGetValue(templateName, out var template))
            {
                throw new ArgumentException($"Template {templateName} not registered with the template engine.");
            }

            var context = new TemplateContext();
            foreach (var property in modelMapping)
            {
                context.MemberAccessStrategy.Register(property.ModelProperty.GetType());
                context.SetValue(property.ModelPropertyName, property.ModelProperty);
            }

            return template.Render(context);
        }
    }
}