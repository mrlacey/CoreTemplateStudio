﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.RegularExpressions;

namespace Microsoft.Templates.Core.Naming
{
    public class RegExValidator : Validator<RegExConfig>
    {
        public RegExValidator(RegExConfig config)
           : base(config)
        {
        }

        public override ValidationResult Validate(string suggestedName)
        {
            var regex = new Regex(Config.Pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(suggestedName))
            {
                return new ValidationResult()
                {
                    IsValid = true,
                    ErrorType = ValidationErrorType.None,
                    ValidatorName = Config.Name,
                };
            }

            return new ValidationResult()
            {
                IsValid = false,
                ErrorType = ValidationErrorType.Regex,
                ValidatorName = Config.Name,
            };
        }
    }
}
