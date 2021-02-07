using System;
using NBitcoin;

namespace ProgrmmingBitcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitcoinKey = new BitcoinKey();
            var bitcoinAddressMain = bitcoinKey.getAddress(Network.Main);
            var bitcoinAddressTestNet = bitcoinKey.getAddress(Network.TestNet);
            var scriptPubKey = BitcoinKey.getScriptPubKey(bitcoinAddressMain);
            var scriptPubKeyTest = BitcoinKey.getScriptPubKey(bitcoinAddressTestNet);
            Console.WriteLine(scriptPubKey);
            Console.WriteLine(scriptPubKeyTest);
            Console.WriteLine(scriptPubKey == scriptPubKeyTest);

            var pubKeyHash = BitcoinKey.getPubKeyHashFromScript(scriptPubKey);
            var sameBitcoinAddressMain = BitcoinKey.getAddressFromPubKeyHash(pubKeyHash, Network.Main);
            Console.WriteLine(bitcoinAddressMain == sameBitcoinAddressMain);
        }
    }
}
