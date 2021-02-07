using NBitcoin;

public class BitcoinKey
{
    public Key privateKey;
    public PubKey publicKey;

    public BitcoinKey() {
      privateKey = new Key();
      publicKey = privateKey.PubKey;
    }
}
