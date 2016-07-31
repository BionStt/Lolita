﻿using Microsoft.EntityFrameworkCore.Storage;

namespace Pomelo.EntityFrameworkCore.Lolita.Update
{
    public class DefaultSetFieldSqlGenerator : ISetFieldSqlGenerator
    {
        public DefaultSetFieldSqlGenerator(ISqlGenerationHelper SqlGenerationHelper)
        {
            sqlGenerationHelper = SqlGenerationHelper;
        }

        protected ISqlGenerationHelper sqlGenerationHelper;

        public virtual string TranslateToSql(SetFieldInfo operation)
        {
            switch(operation.Type)
            {
                case "WithValue":
                    return $"SET {operation.Field} = {{{ operation.Index }}}";
                case "Plus":
                    return $"SET {operation.Field} = {operation.Field} + {{{ operation.Index }}}";
                case "Subtract":
                    return $"SET {operation.Field} = {operation.Field} - {{{ operation.Index }}}";
                case "Multiply":
                    return $"SET {operation.Field} = {operation.Field} * {{{ operation.Index }}}";
                case "Divide":
                    return $"SET {operation.Field} = {operation.Field} / {{{ operation.Index }}}";
                case "Mod":
                    return $"SET {operation.Field} = {operation.Field} % {{{ operation.Index }}}";
                case "Append":
                    return $"SET {operation.Field} = CONCAT({operation.Field}, {{{operation.Index}}})";
                case "Prepend":
                    return $"SET {operation.Field} = CONCAT({{{operation.Index}}}, {operation.Field})";
                case "AddMilliseconds":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} microsecond)";
                case "AddSeconds":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} second)";
                case "AddMinutes":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} minute)";
                case "AddHours":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} hour)";
                case "AddDays":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} day)";
                case "AddMonths":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} month)";
                case "AddYears":
                    return $"SET {operation.Field} = DATE_ADD({operation.Field}, INTERVAL {{{operation.Index}}} year)";
            }
            return string.Empty;
        }
    }
}
