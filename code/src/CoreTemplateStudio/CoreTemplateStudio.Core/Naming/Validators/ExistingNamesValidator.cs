﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Templates.Core.Naming
{
    public class ExistingNamesValidator : Validator<Func<IEnumerable<string>>>
    {
        public ExistingNamesValidator(Func<IEnumerable<string>> config)
            : base(config)
        {
        }

        public override ValidationResult Validate(string suggestedName)
        {
            if (Config == null)
            {
                throw new ArgumentNullException(nameof(Config));
            }

            var existingNames = Config.Invoke();
            if (existingNames.Contains(suggestedName, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    ErrorType = ValidationErrorType.AlreadyExists,
                    ValidatorName = nameof(ExistingNamesValidator),
                };
            }

            return new ValidationResult()
            {
                IsValid = true,
                ErrorType = ValidationErrorType.None,
                ValidatorName = nameof(ExistingNamesValidator),
            };
        }
    }
}
