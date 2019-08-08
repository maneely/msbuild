// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

using SdkReference = Microsoft.Build.Framework.SdkReference;
using SdkResultBase = Microsoft.Build.Framework.SdkResult;

namespace Microsoft.Build.BackEnd.SdkResolution
{
    /// <summary>
    /// An internal implementation of <see cref="Microsoft.Build.Framework.SdkResult"/>.
    /// </summary>
    internal sealed class SdkResult : SdkResultBase, INodePacket
    {
        private string _path;
        private string _version;
        private bool _trackEnvironmentVariables;

        public SdkResult(ITranslator translator)
        {
            Translate(translator);
        }

        public SdkResult(SdkReference sdkReference, IEnumerable<string> errors, IEnumerable<string> warnings, bool trackEnvironmentVariables = true)
        {
            Success = false;
            SdkReference = sdkReference;
            Errors = errors;
            Warnings = warnings;
            TrackEnvironmentVariables = trackEnvironmentVariables;
        }

        public SdkResult(SdkReference sdkReference, string path, string version, IEnumerable<string> warnings, bool trackEnvironmentVariables = true)
        {
            Success = true;
            SdkReference = sdkReference;
            _path = path;
            _version = version;
            Warnings = warnings;
            TrackEnvironmentVariables = trackEnvironmentVariables;
        }

        public SdkResult()
        {
        }

        public Construction.ElementLocation ElementLocation { get; set; }

        public IEnumerable<string> Errors { get; }

        public override string Path => _path;

        public override SdkReference SdkReference { get; protected set; }

        public override string Version => _version;

        public override bool TrackEnvironmentVariables { get => _trackEnvironmentVariables; set => _trackEnvironmentVariables = value; }

        public IEnumerable<string> Warnings { get; }

        public void Translate(ITranslator translator)
        {
            translator.Translate(ref _path);
            translator.Translate(ref _version);
            translator.Translate(ref _trackEnvironmentVariables);
        }

        public NodePacketType Type => NodePacketType.ResolveSdkResponse;

        public static INodePacket FactoryForDeserialization(ITranslator translator)
        {
            return new SdkResult(translator);
        }
    }
}
