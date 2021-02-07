using NBitcoin;

public class BitcoinKey
{
    public Key privateKey;
    public BitcoinSecret bitcoinSecretMain;
    public PubKey publicKey;
    public KeyId pubKeyHash;

    public BitcoinKey() {
      privateKey = new Key();
      bitcoinSecretMain = getBitcoinSecret(Network.Main);
      publicKey = privateKey.PubKey;
      pubKeyHash = publicKey.Hash;
    }

    public BitcoinSecret getBitcoinSecret(Network network) {
      return privateKey.GetBitcoinSecret(network);
    }

    public BitcoinAddress getAddress(Network network) {
      return publicKey.GetAddress(ScriptPubKeyType.Legacy, network);
    }

    public static BitcoinAddress getAddressFromPubKey(PubKey publicKey, Network network) {
        return publicKey.GetAddress(ScriptPubKeyType.Legacy, network);
    }

    public static BitcoinAddress getAddressFromPubKeyHash(KeyId pubKeyHash, Network network) {
      return pubKeyHash.GetAddress(network);
    }

    public static BitcoinAddress getAddressFromPubKeyHash2(KeyId pubKeyHash, Network network) {
        return new BitcoinPubKeyAddress(pubKeyHash, network);
    }

    public static BitcoinAddress getAddressFromScript(Script scriptPubKey, Network network) {
        return scriptPubKey.GetDestinationAddress(network);
    }

    public static KeyId getPubKeyHashFromScript(Script scriptPubKey) {
        return (KeyId) scriptPubKey.GetDestination();
    }


    public static Script getScriptPubKey(BitcoinAddress address) {
      return address.ScriptPubKey;
    }
}
