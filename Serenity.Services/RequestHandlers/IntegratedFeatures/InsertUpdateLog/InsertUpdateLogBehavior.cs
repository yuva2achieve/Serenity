﻿using Serenity;
using Serenity.Data;
using Serenity.Data.Mapping;
using Serenity.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Serenity.Services
{
    public class UpdateInsertLogBehavior : BaseSaveBehavior, IImplicitBehavior
    {
        public bool ActivateFor(Row row)
        {
            return row is IUpdateLogRow || row is IInsertLogRow;
        }

        public override void OnSetInternalFields(ISaveRequestHandler handler)
        {
            var row = handler.Row;
            var updateLogRow = row as IUpdateLogRow;
            var insertLogRow = row as IInsertLogRow;

            if (updateLogRow != null && (handler.IsUpdate || insertLogRow == null))
            {
                updateLogRow.UpdateDateField[row] = DateTimeField.ToDateTimeKind(DateTime.Now, updateLogRow.UpdateDateField.DateTimeKind);
                if (updateLogRow.UpdateUserIdField.IsIntegerType)
                    updateLogRow.UpdateUserIdField[row] = Authorization.UserId.TryParseID();
                else
                    ((Field)updateLogRow.UpdateUserIdField).AsObject(row,
                        ((Field)updateLogRow).ConvertValue(Authorization.UserId, CultureInfo.InvariantCulture));
            }
            else if (insertLogRow != null && handler.IsCreate)
            {
                insertLogRow.InsertDateField[row] = DateTimeField.ToDateTimeKind(DateTime.Now, insertLogRow.InsertDateField.DateTimeKind);
                if (insertLogRow.InsertUserIdField.IsIntegerType)
                    insertLogRow.InsertUserIdField[row] = Authorization.UserId.TryParseID();
                else
                    ((Field)insertLogRow.InsertUserIdField).AsObject(row,
                        ((Field)insertLogRow).ConvertValue(Authorization.UserId, CultureInfo.InvariantCulture));
                insertLogRow.InsertUserIdField[row] = Authorization.UserId.TryParseID();
            }
        }
    }
}