using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionTranslators.Internal;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace Pomelo.EntityFrameworkCore.MySql.Json.Newtonsoft.Query.Internal
{
    public class MySqlJsonNewtonsoftPocoTranslator : MySqlJsonPocoTranslator
    {
        public MySqlJsonNewtonsoftPocoTranslator(
            [NotNull] IRelationalTypeMappingSource typeMappingSource,
            [NotNull] ISqlExpressionFactory sqlExpressionFactory)
        : base(typeMappingSource, (MySqlSqlExpressionFactory)sqlExpressionFactory)
        {
        }

        public override string GetJsonPropertyName(MemberInfo member)
            => member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;
        // public override string GetJsonPropertyName(MemberInfo member)
        // {
        //     var attributeName = member.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;
        //     if (!string.IsNullOrWhiteSpace(attributeName))
        //         return attributeName;

        //     if (JsonConvert.DefaultSettings?.Invoke()?.ContractResolver is DefaultContractResolver resolver)
        //         return resolver.GetResolvedPropertyName(member.Name);

        //     return new DefaultContractResolver().GetResolvedPropertyName(member.Name);
        // }
    }
}
