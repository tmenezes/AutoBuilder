using System;

namespace AutoBuilder.FillingStrategy
{
    internal class EnumValueGenerator : IValueGenerator
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public object GenerateValue(BuilderContext context)
        {
            var enumType = TypeManager.IsNullableTypeOfEnum(context.CurrentValueGeneratorType)
                ? Nullable.GetUnderlyingType(context.CurrentValueGeneratorType)
                : context.CurrentValueGeneratorType;

            var enumValues = Enum.GetValues(enumType);
            var index = _random.Next(0, enumValues.Length - 1);

            return enumValues.GetValue(index);
        }
    }
}