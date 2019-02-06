﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CoreTemplateStudio.Api.Enumerables;

namespace CoreTemplateStudio.Api.Models
{
    // just a base implementation for the API scaffolding,
    // can't provide working logic until the engine is done.
    public class SyncModel
    {
        private readonly Platform platform;

        public bool WasUpdated { get; set; }

        public SyncModel(Platform platform)
        {
            this.platform = platform;
        }

        public void Sync()
        {
            this.WasUpdated = true;
        }
    }
}