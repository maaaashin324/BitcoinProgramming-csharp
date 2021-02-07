using System;
using NBitcoin;

namespace ProgrmmingBitcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitcoinKey = new BitcoinKey();
            Key privateKey = createPrivateKey();
            PubKey pubKey = createPublicKey(privateKey);

            var bitcoinAddressMain = getAddressFromPubKey(pubKey, Network.Main);
            var bitcoinAddressTestNet = getAddressFromPubKey(pubKey, Network.TestNet);
            var scriptPubKey = getScriptPubKey(bitcoinAddressMain);
            var scriptPubKeyTest = getScriptPubKey(bitcoinAddressTestNet);
            Console.WriteLine(scriptPubKey);
            Console.WriteLine(scriptPubKeyTest);
            Console.WriteLine(scriptPubKey == scriptPubKeyTest);

            var pubKeyHash = getPubKeyHashFromScript(scriptPubKey);
            var sameBitcoinAddressMain = getAddressFromPubKeyHash(pubKeyHash, Network.Main);
            Console.WriteLine(bitcoinAddressMain == sameBitcoinAddressMain);
        }

        static Key createPrivateKey() {
            Key privateKey = new Key();
            return privateKey;
        }

        static PubKey createPublicKey(Key privateKey) {
            return privateKey.PubKey;
        }

        static BitcoinAddress getAddressFromPubKey(PubKey pubKey, Network network) {
            return pubKey.GetAddress(ScriptPubKeyType.Legacy, network);
        }

        static BitcoinAddress getAddressFromPubKeyHash(KeyId pubKeyHash, Network network) {
            return pubKeyHash.GetAddress(network);
        }

        static BitcoinAddress getAddressFromPubKeyHash2(KeyId pubKeyHash, Network network) {
            return new BitcoinPubKeyAddress(pubKeyHash, network);
        }

        static BitcoinAddress getAddressFromScript(Script scriptPubKey, Network network) {
            return scriptPubKey.GetDestinationAddress(network);
        }

        static KeyId getPubKeyHash(PubKey pubKey) {
            return pubKey.Hash;
        }

        static KeyId getPubKeyHashFromScript(Script scriptPubKey) {
            return (KeyId) scriptPubKey.GetDestination();
        }

        static Script getScriptPubKey(BitcoinAddress address) {
            return address.ScriptPubKey;
        }
    }
}
