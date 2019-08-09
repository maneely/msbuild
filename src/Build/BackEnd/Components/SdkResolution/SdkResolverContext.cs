// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.Build.BackEnd.Logging;
using Microsoft.Build.Framework;
using Microsoft.Build.Shared;
using Microsoft.Build.Utilities;
using SdkResolverContextBase = Microsoft.Build.Framework.SdkResolverContext;

namespace Microsoft.Build.BackEnd.SdkResolution
{
    /// <summary>
    /// An internal implementation of <see cref="Framework.SdkResolverContext"/>.
    /// </summary>
    internal sealed class SdkResolverContext : SdkResolverContextBase
    {
        private readonly IDictionary<string, string> _globalProperties;
        private readonly LoggingContext _loggingContext;

        public SdkResolverContext(Framework.SdkLogger logger, string projectFilePath, string solutionPath, Version msBuildVersion, bool interactive, IDictionary<string, string> globalProperties, LoggingContext loggingContext)
        {
            Logger = logger;
            ProjectFilePath = projectFilePath;
            SolutionFilePath = solutionPath;
            MSBuildVersion = msBuildVersion;
            Interactive = interactive;
            _globalProperties = globalProperties;
            _loggingContext = loggingContext;
        }

        public override string GetGlobalPropertyValue(string name)
        {
            if (_globalProperties != null && _globalProperties.TryGetValue(name, out string property))
            {
                return property;
            }

            return string.Empty;
        }

        public override string GetEnvironmentVariableValue(string name)
        {
            Traits.PropertyTrackingSetting settings = (Traits.PropertyTrackingSetting)Traits.Instance.LogPropertyTracking;
            if ((settings & Traits.PropertyTrackingSetting.EnvironmentVariableRead) == Traits.PropertyTrackingSetting.EnvironmentVariableRead)
            {
                // Log this usage.
                var args = new EnvironmentVariableReadEventArgs(
                    name,
                    ResourceUtilities.FormatResourceStringIgnoreCodeAndKeyword("EnvironmentVariableRead", name));
                args.BuildEventContext = _loggingContext.BuildEventContext;

                _loggingContext.LogBuildEvent(args);
            }

            return Environment.GetEnvironmentVariable(name) ?? string.Empty;
        }
    }
}
