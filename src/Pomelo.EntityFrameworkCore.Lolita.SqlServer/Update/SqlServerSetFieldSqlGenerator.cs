﻿using Microsoft.EntityFrameworkCore.Storage;

namespace Pomelo.EntityFrameworkCore.Lolita.Update
{
    public class SqlServerSetFieldSqlGenerator : DefaultSetFieldSqlGenerator
    {
        public SqlServerSetFieldSqlGenerator(ISqlGenerationHelper x) : base(x) { }

        public override string TranslateToSql(SetFieldInfo operation)
        {
            switch (operation.Type)
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
                    return $"SET {operation.Field} = {operation.Field}+{{{operation.Index}}}";
                case "Prepend":
                    return $"SET {operation.Field} = {{{operation.Index}}}+{operation.Field}";
                case "AddMilliseconds":
                    return $"SET {operation.Field} = DATEADD(ss, {{{operation.Index}}}, {operation.Field})";
                case "AddSeconds":
                    return $"SET {operation.Field} = DATEADD(ms, {{{operation.Index}}}, {operation.Field})";
                case "AddMinutes":
                    return $"SET {operation.Field} = DATEADD(mi, {{{operation.Index}}}, {operation.Field})";
                case "AddHours":
                    return $"SET {operation.Field} = DATEADD(hh, {{{operation.Index}}}, {operation.Field})";
                case "AddDays":
                    return $"SET {operation.Field} = DATEADD(dd, {{{operation.Index}}}, {operation.Field})";
                case "AddMonths":
                    return $"SET {operation.Field} = DATEADD(mm, {{{operation.Index}}}, {operation.Field})";
                case "AddYears":
                    return $"SET {operation.Field} = DATEADD(yy, {{{operation.Index}}}, {operation.Field})";
            }
            return string.Empty;
        }
    }
}
