﻿using IotaSDK.NET.Domain.UnlockConditions;
using System.Collections.Generic;

namespace IotaSDK.NET.Domain.Outputs
{
    public class AliasOutput : StateMetadataOutput
    {
        public AliasOutput(
            string amount,
            string aliasId,
            List<UnlockCondition> unlockConditions,
            string? stateMetadata,
            int foundryCounter,
            int stateIndex)
            : base(amount, (int)OutputType.Alias, unlockConditions, stateMetadata)
        {
            AliasId = aliasId;
            FoundryCounter = foundryCounter;
            StateIndex = stateIndex;
        }
        /// <summary>
        /// The Alias ID as hex-encoded string.
        /// </summary>
        public string AliasId { get; }

        /// <summary>
        /// A counter that denotes the number of foundries created by this alias account.
        /// </summary>
        public int FoundryCounter { get; }

        /// <summary>
        ///  A counter that must increase by 1 every time the alias is state transitioned.
        /// </summary>
        public int StateIndex { get; }
    }
}
