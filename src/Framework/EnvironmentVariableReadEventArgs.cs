﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Build.Framework
{
    /// <summary>
    /// Arguments for the environment variable read event.
    /// </summary>
    [Serializable]
    public class EnvironmentVariableReadEventArgs : BuildStatusEventArgs
    {
        /// <summary>
        /// Initializes an instance of the EnvironmentVariableReadEventArgs class.
        /// </summary>
        public EnvironmentVariableReadEventArgs()
        {
        }

        /// <summary>
        /// Initializes an instance of the EnvironmentVariableReadEventArgs class.
        /// </summary>
        /// <param name="environmentVariableName">The name of the environment variable that was read.</param>
        public EnvironmentVariableReadEventArgs(
            string environmentVariableName,
            string message,
            string helpKeyword = null,
            string senderName = null) : base(message, helpKeyword, senderName)
        {
            this.EnvironmentVariableName = environmentVariableName;
        }

        /// <summary>
        /// The name of the environment variable that was read.
        /// </summary>
        public string EnvironmentVariableName { get; set; }
    }
}