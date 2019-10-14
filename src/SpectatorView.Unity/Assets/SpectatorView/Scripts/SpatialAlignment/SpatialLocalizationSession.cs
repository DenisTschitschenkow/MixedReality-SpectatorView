﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.SpatialAlignment;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.MixedReality.SpectatorView
{
    public abstract class SpatialLocalizationSession : DisposableBase, ISpatialLocalizationSession
    {
        protected readonly CancellationTokenSource defaultCTS = null;

        /// <inheritdoc />
        public abstract IPeerConnection Peer { get; }

        /// <inheritdoc />
        public SpatialLocalizationSession()
        {
            this.defaultCTS = new CancellationTokenSource();
        }

        /// <inheritdoc />
        protected override void OnManagedDispose()
        {
            defaultCTS.Dispose();
        }

        /// <inheritdoc />
        public abstract Task<ISpatialCoordinate> LocalizeAsync(CancellationToken cancellationToken);

        /// <inheritdoc />
        public void Cancel()
        {
            if (defaultCTS.Token.CanBeCanceled)
            {
                defaultCTS.Cancel();
            }
        }

        /// <inheritdoc />
        public abstract void OnDataReceived(BinaryReader reader);
    }
}