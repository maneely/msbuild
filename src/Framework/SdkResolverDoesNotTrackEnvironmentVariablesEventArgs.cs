// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Build.Framework
{
    /// <summary>
    /// The arguments for an SDK resolver not tracking environment variables event.
    /// </summary>
    [Serializable]
    public class SdkResolverDoesNotTrackEnvironmentVariablesEventArgs : BuildMessageEventArgs
    {
        /// <summary>
        /// Creates an instance of the <see cref="SdkResolverDoesNotTrackEnvironmentVariablesEventArgs"/> class.
        /// </summary>
        public SdkResolverDoesNotTrackEnvironmentVariablesEventArgs()
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="SdkResolverDoesNotTrackEnvironmentVariablesEventArgs"/> class.
        /// </summary>
        public SdkResolverDoesNotTrackEnvironmentVariablesEventArgs(
            string sdkResolverName,
            string message,
            string helpKeyword = null,
            string senderName = null,
            MessageImportance importance = MessageImportance.Low) : base(message, helpKeyword, senderName, importance)
        {
            this.SdkResolverName = sdkResolverName;
        }

        /// <summary>
        /// The name of the SDK Resolver that isn't tracking environment variable reads.
        /// </summary>
        public string SdkResolverName { get; set; }
    }
}
