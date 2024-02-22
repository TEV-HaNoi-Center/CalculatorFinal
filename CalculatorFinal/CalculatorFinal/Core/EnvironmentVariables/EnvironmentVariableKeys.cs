﻿using CalculatorFinal.Core.EnvironmentVariables.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFinal.Core.EnvironmentVariables
{
    public static class EnvironmentVariableKeys
    {
        private static readonly ReadOnlyDictionary<EnvironmentVariableKey, string> EnvironmentVariableKeysDictionary;

        static EnvironmentVariableKeys()
        {
            EnvironmentVariableKeysDictionary = new ReadOnlyDictionary<EnvironmentVariableKey, string>(new Dictionary<EnvironmentVariableKey, string>
            {
                {
                    EnvironmentVariableKey.EnvironmentType, "ENVIRONMENT_TYPE"
                }
            });
        }

        public static string GetEnvironmentVariableKey(EnvironmentVariableKey key)
        {
            EnvironmentVariableKeysDictionary.TryGetValue(key, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following Environment Variable Key does not exist with this key. {nameof(key).ToUpper()}: {key}");
            }

            return result;
        }
    }
}
