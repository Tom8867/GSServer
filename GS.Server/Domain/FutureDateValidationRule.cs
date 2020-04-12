﻿// /* Copyright(C) 2020  Rob Morgan (robert.morgan.e@gmail.com)
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as published
//     by the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
// 
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see <https://www.gnu.org/licenses/>.
//  */
using System;
using System.Globalization;
using System.Windows.Controls;

namespace GS.Server.Domain
{
    public class FutureDateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!DateTime.TryParse((value ?? "").ToString(),
                CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                out var time)) return new ValidationResult(false, "Invalid date");

            return time.Date < DateTime.Now.Date
                ? new ValidationResult(false, "Future date required")
                : ValidationResult.ValidResult;
        }
    }
}