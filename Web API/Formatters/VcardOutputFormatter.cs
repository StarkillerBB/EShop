using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace Web_API.Formatters
{
    public class VcardOutputFormatter : TextOutputFormatter
    {
        public VcardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
            => typeof(Product).IsAssignableFrom(type)
                || typeof(IEnumerable<Product>).IsAssignableFrom(type);

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<VcardOutputFormatter>>();
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<Product> products)
            {
                foreach (var product in products)
                {
                    FormatVcard(buffer, product, logger);
                }
            }
            else
            {
                FormatVcard(buffer, (Product)context.Object!, logger);
            }

            await httpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        private static void FormatVcard(
            StringBuilder buffer, Product product, ILogger logger)
        {
            buffer.AppendLine($"Product ID:{product.ID}");
            buffer.AppendLine($"Product Name:{product.ProductName}");
            buffer.AppendLine($"Product Description:{product.Description}");
            buffer.AppendLine($"Product Price:{product.Price}");
            buffer.AppendLine($"Product SoftDeleted:{product.SoftDelete}");
            buffer.AppendLine($"Product Type ID:{product.TypeID}");
            buffer.AppendLine("\n");

            logger.LogInformation("Writing {ProductName}",
                product.ProductName);
        }
    }
}
