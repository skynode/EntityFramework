// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    /// <summary>
    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class RawRelationalParameter : IRelationalParameter
    {
        private readonly DbParameter _dbParameter;
        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public RawRelationalParameter(
            [NotNull] string invariantName,
            [NotNull] DbParameter dbParameter)
        {
            Check.NotEmpty(invariantName, nameof(invariantName));
            Check.NotNull(dbParameter, nameof(dbParameter));

            InvariantName = invariantName;
            _dbParameter = dbParameter;
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string InvariantName { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public void AddDbParameter(DbCommand command, object value)
        {
            if (value == null)
            {
                command.Parameters.Add(_dbParameter);
            }
        }
    }
}
