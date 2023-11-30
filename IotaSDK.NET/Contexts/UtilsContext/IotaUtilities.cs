﻿using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Contexts.UtilsContext.Commands.Bech32ToHex;
using IotaSDK.NET.Contexts.UtilsContext.Commands.GenerateMnemonic;
using IotaSDK.NET.Contexts.UtilsContext.Commands.MnemonicToHexSeed;
using IotaSDK.NET.Contexts.UtilsContext.Commands.NftIdToBech32;
using IotaSDK.NET.Contexts.UtilsContext.Commands.VerifyMnemonic;
using IotaSDK.NET.Domain.Network;
using MediatR;
using System.Threading.Tasks;

namespace IotaSDK.NET.Contexts.UtilsContext
{
    public class IotaUtilities : IIotaUtilities
    {
        private readonly IMediator _mediator;

        public IotaUtilities(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IotaSDKResponse<string>> ConvertMnemonicToHexSeedAsync(string mnemonic)
        {
            return await _mediator.Send(new MnemonicToHexSeedCommand(mnemonic));
        }

        public async Task<IotaSDKResponse<bool>> VerifyMnemonicAsync(string mnemonic)
        {
            return await _mediator.Send(new VerifyMnemonicCommand(mnemonic));
        }

        public async Task<IotaSDKResponse<string>> GenerateMnemonicAsync()
        {
            IotaSDKResponse<string> generateMnemonicResponse = await _mediator.Send(new GenerateMnemonicCommand());

            return generateMnemonicResponse;
        }

        public async Task<IotaSDKResponse<string>> ConvertNftIdToBech32Async(string nftId, HumanReadablePart humanReadablePart)
        {
            return await _mediator.Send(new NftIdToBech32Command(nftId, humanReadablePart));
        }

        public async Task<IotaSDKResponse<string>> ConvertBech32ToHexStringAsync(string bech32Address)
        {
            return await _mediator.Send(new Bech32ToHexCommand(bech32Address));
        }
    }
}
