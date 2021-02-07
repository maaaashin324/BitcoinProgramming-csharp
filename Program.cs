using System;
using NBitcoin;
using QBitNinja.Client;
using QBitNinja.Client.Models;

namespace ProgrmmingBitcoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create private key
            var bitcoinKey = new BitcoinKey();
            // Create Bitcoin Address for Main Network
            var bitcoinAddressMain = bitcoinKey.getAddress(Network.Main);
            // Create Bitcoin Address for Test Network
            var bitcoinAddressTestNet = bitcoinKey.getAddress(Network.TestNet);
            // Create ScriptPubKey with Bitcoin Address for Main Network
            var scriptPubKey = BitcoinKey.getScriptPubKey(bitcoinAddressMain);
            // Create ScriptPubKey with Bitcoin Address for Test Network
            var scriptPubKeyTest = BitcoinKey.getScriptPubKey(bitcoinAddressTestNet);
            Console.WriteLine("ScriptPubKey in main net: " + scriptPubKey);
            Console.WriteLine("ScriptPubKey in test net: " + scriptPubKeyTest);
            // ScriptPubKey is the same for both Main and Test Network
            Console.WriteLine("ScriptPubKey in main and testnet is same?: " + (scriptPubKey == scriptPubKeyTest));
            // Create hash of the public key with ScriptPubKey
            var pubKeyHash = BitcoinKey.getPubKeyHashFromScript(scriptPubKey);
            // You can retrieve Bitcoin Address with the hash, which means ScriptPubKey
            // Bitcoin Address -> ScriptPubKey
            // ScriptPubKey -> Hash of PubKey -> Bitcoin Address
            var sameBitcoinAddressMain = BitcoinKey.getAddressFromPubKeyHash(pubKeyHash, Network.Main);
            Console.WriteLine("Can you retrieve Bitcoin Address from ScriptPubKey?: " + (bitcoinAddressMain == sameBitcoinAddressMain));

            // You can retrieve a transaction from a raw data
            // Transaction tx = Transaction.Parse("0100000009dd9e20cecf519ce7cdec2c4890e60bbff540b2fafdca2b426304fd8fefc58847000000006b483045022100d08870b424f19d8b3921861bedec81599a9cd5f179e35e80d16709a296d41484022023f1c2a9eab7d5dd8a1043d1d423e185641e79d33f32491638c7caf6029105410121035904165d4ed4aae69b1adef8dd99a21dac2c1ad479188d9d7de3b341aae229deffffffffc5a6457d1532d7cfe5dc6802323806bfd81c365bc4bb9fdadd8cfb2fd39280c3000000006b483045022100f337bc11e419e2317a59a0acd33c2937823aa2b015a1579bd6caab6f55dc828602201cc6985189b2b654ee9b71850697460086429c91f5e90598ca927dfbe315a3940121034e1304481c7403a35e1348289468df9982bbd516a3aedb7f1bc81667f7a09c5dffffffffa94e871f35a616b5a22139cc7dc5a4da35061d6317accb935a4af037573c1dc3000000008a473044022045476041f0d2910269ee4e707dda5678af483339962c0a2d7897c3aa78cb29ea0220476032a6bbe59e67ad5f95cc2f3e5264bb2bca8ea88eb30c96123b9ff7a33a5001410482d593f88a39160eaed14470ee4dad283c29e88d9abb904f953115b1a93d6f3881d6f8c29c53ddb30b2d1c6b657068d60a93ed240d5efca247836f6395807bcdffffffff8d199257330921571d8984bf38c47304b26e3c497a09acc298941e60b998ccfb010000008b483045022100fc8e579f4cabda1e26a294b3f7f227087b64ca2451155b8747bd1f6c96780d6d022041912d38512030e1ec1d3df6b8d91d8b9aa4c564642fd7cafc48f97fd550100101410482d593f88a39160eaed14470ee4dad283c29e88d9abb904f953115b1a93d6f3881d6f8c29c53ddb30b2d1c6b657068d60a93ed240d5efca247836f6395807bcdffffffff0246c072469f817ec87273c0a0d6b30fc840a6aa31f56427cca2ce31163c49fd000000006a473044022034cd8a6ecc391539af0e0af1075cf48599a40fb011936f2397a6b457e5fb60bd02201d059c7cf571d80bb6ead165639334fc6e45985c34a0cf7bc10d9a1817d22d0501210249af09f7a52e81c6de1df85a00792522df76b6a529178673d27754772f5d2758ffffffff2515c8cbc51039bc50bc8b4504617410824d1858dcff721ab3716dae44f350a9000000008b48304502210095a36910e3a466697f0a3a42cd0e487c280b1d48f8a8ea3d2867c1bb6fa6a4cf0220486eb68f95ae081e42dd48cb96d01b9536761e17b4f2ae10935aa406ceed268d01410482d593f88a39160eaed14470ee4dad283c29e88d9abb904f953115b1a93d6f3881d6f8c29c53ddb30b2d1c6b657068d60a93ed240d5efca247836f6395807bcdffffffff36c456759b51e87a75673d8bd8a1d91177164767ea937a4365578930cd8bf855000000006b483045022100eae7bf8ead57bedc858700ff7e8f0f917650a97d905ecc5264c29c6a4e87f7ac022055483fac8618831d163370bb8a083aff5111c795bafdbd48693cf98b5f2e420b012103b1534714e589d87484e2305e32261fc157a7ddd3ca060f5293a3dfbc76b7576bffffffff50a85ca81a0c667b6484ac371493be2a5298fe9e04b095f545cc795ba7dfda19000000006b483045022100dab39ceb5f48718fd3f7f549f5cb28fdd9bca755d031a15f608ebc7902ede62502200fcd17229262dd183fbc134279a9139d9e2a1e1e5723adfec8f3599e3f62b6ed0121025fbd9ac3c3277a06e623dfed29f9d490c643c023987a0412308c4a8e78b12b55ffffffff66fb69807af8e4d8f0cbfece1f02fed8c130c168f3b06d10640d02ffdebf2d90000000008b483045022100df2e15424b9664be46e5eef90030b557655ffd4b9f1dfc4dfd5a0422e8e8d13202204c94a8c9975f914f7926cda55b04193328f612d154fa6c6c908c88b4a4f9729201410482d593f88a39160eaed14470ee4dad283c29e88d9abb904f953115b1a93d6f3881d6f8c29c53ddb30b2d1c6b657068d60a93ed240d5efca247836f6395807bcdffffffff01a4c5a84e000000001976a914b6cefbb855cabf6ee45598f518a98011c22961aa88ac00000000", Network.Main);
            // Console.WriteLine(tx);

            // Create an instance of QBitNinja Client
            var client = new QBitNinjaClient(Network.Main);
            // Parsed the id of the transaction with uint256
            var txId = uint256.Parse("f13dc48fb035bbf0a6e989a26b3ecb57b84f85e0836e777d6edf60d87a4a2d94");
            // Get the transaction(GetTransactionResponse) from QBitNinja
            var txResponse = client.GetTransaction(txId).Result;
            // Get the transaction(Transaction) from GetTransactionResponse
            Transaction tx = txResponse.Transaction;
            Console.WriteLine("Transactin data got from QBitNinja" + tx);
            // Retrieve coins received, which is the same as txOutputs
            var receivedCoins = txResponse.ReceivedCoins;
            foreach (var coin in receivedCoins) {
                Money amount = (Money) coin.Amount;
                Console.WriteLine("Amount receieved: " + amount.ToDecimal(MoneyUnit.BTC));

                var paymentScript = coin.TxOut.ScriptPubKey;
                Console.WriteLine("ScriptPubKey received: " + paymentScript);

                var address = BitcoinKey.getAddressFromScript(paymentScript, Network.Main);
                Console.WriteLine("Bitcoin addrss received: " + address);
            }
            // Retrieve coins spent for this transaction, which is the same as txInputs
            var spentCoins = txResponse.SpentCoins;
            foreach (var coin in spentCoins) {
                Money amount = (Money) coin.Amount;
                Console.WriteLine("Amount spent: " + amount.ToDecimal(MoneyUnit.BTC));

                var paymentScript = coin.TxOut.ScriptPubKey;
                Console.WriteLine("ScriptPubKey spent: " + paymentScript);

                var address = BitcoinKey.getAddressFromScript(paymentScript, Network.Main);
                Console.WriteLine("Bitcoin address spent: " + address);
            }
            // Retrieve the output of the transaction, which is the same as txResponse.ReceivedCoins
            var outputs = tx.Outputs;
            foreach (var output in outputs) {
                Money amount = output.Value;
                Console.WriteLine("Amount received: " + amount.ToDecimal(MoneyUnit.BTC));

                var eachScriptPubKey = output.ScriptPubKey;
                Console.WriteLine("ScriptPubKey received: " + eachScriptPubKey);

                var address = BitcoinKey.getAddressFromScript(eachScriptPubKey, Network.Main);
                Console.WriteLine("Bitcoin address received: " + address);
            }
            // Retrieve the input of the transaction, which is the same as txResponse.SpentCoins
            var inputs = tx.Inputs;
            foreach (var input in inputs) {
                var prevOut = input.PrevOut;
                Console.WriteLine("Transaction spent for this tx: " + prevOut.Hash);
                Console.WriteLine("Transaction Index for this tx: " + prevOut.N);
            }
            // Create a new txOutput
            Money twentyOneBTC = new Money(21, MoneyUnit.BTC);
            var receipientScriptPubKey = tx.Outputs[0].ScriptPubKey;
            var newTxOut = tx.Outputs.CreateNewTxOut(twentyOneBTC, receipientScriptPubKey);
            // Check what is the txID and index
            var firstOutPoint = receivedCoins[0].Outpoint;
            Console.WriteLine("TxId of the first outpoint" + firstOutPoint.Hash);
            Console.WriteLine("The index of the first outpoint" + firstOutPoint.N);
            // How many inputs this transaction has?
            Console.WriteLine("How many inputs this transaction has?" + tx.Inputs.Count);
            // Retrieve the transaction spent for the current transaction
            var firstPreviousOutPoint = tx.Inputs[0].PrevOut;
            var firstPreviousTransaction = client.GetTransaction(firstPreviousOutPoint.Hash).Result.Transaction;
            Console.WriteLine("Is the previous transaction coinbase?" + firstPreviousTransaction.IsCoinBase);
            // How much Bitcoin was spent for this transaction?
            Money spentAmount = Money.Zero;
            foreach (var eachCoin in spentCoins) {
                spentAmount = (Money) eachCoin.Amount.Add(spentAmount);
            }
            Console.WriteLine("How much Bitcoin was spent for this transaction?" + spentAmount.ToDecimal(MoneyUnit.BTC));
            Money receivedAmount = Money.Zero;
            foreach (var eachCoin in receivedCoins) {
                receivedAmount = (Money) eachCoin.Amount.Add(receivedAmount);
            }
            Console.WriteLine("How much Bitcoin was received in this transaction?" + receivedAmount.ToDecimal(MoneyUnit.BTC));
            // Calculate Fee
            var fee = tx.GetFee(spentCoins.ToArray());
            Console.WriteLine("Fee: " + fee.ToDecimal(MoneyUnit.BTC));
        }
    }
}
