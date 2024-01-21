﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace IotaSDK.NET.Domain.Events
{
    [Flags]
    public enum WalletEventType
    {
        ConsolidationRequired = 32,
        NewOutput = 1,
        SpentOutput = 2,
        TransactionInclusion = 4,
        TransactionProgress = 8,
        LedgerAddressGeneration = 16,
        AllEvents = ConsolidationRequired | NewOutput | SpentOutput | TransactionInclusion | TransactionProgress | LedgerAddressGeneration
    };

    internal static class  WalletEventFlagToInt
    {
        public static List<int> ConvertWalletEventType(WalletEventType walletEventType)
        {
            var mapping = new Dictionary<WalletEventType, int>
            {
                { WalletEventType.ConsolidationRequired, 0 },
                { WalletEventType.LedgerAddressGeneration, 1 },
                { WalletEventType.NewOutput, 2 },
                { WalletEventType.SpentOutput, 3 },
                { WalletEventType.TransactionInclusion, 4 },
                { WalletEventType.TransactionProgress, 5 }
            };

            var result = new List<int>();

            foreach (var eventType in Enum.GetValues(typeof(WalletEventType)).Cast<WalletEventType>())
            {
                if (walletEventType.HasFlag(eventType) && mapping.ContainsKey(eventType))
                {
                    result.Add(mapping[eventType]);
                }
            }

            return result;
        }
    }

}
