using System.Collections.Generic;

namespace _Scripts.GrowthFund._Shared.Analytics
{
    public interface ITransactionHandlerService
    {
        void OnTransactionBatch(TransactionSource source, ITransactionData transactionSpent, ITransactionData transactionReceived, IDictionary<string, string> sourceContext = null);
        void OnTransactionBatch(TransactionSource source, IEnumerable<ITransactionData> transactionsSpent = null, IEnumerable<ITransactionData> transactionsReceived = null, IDictionary<string, string> sourceContext = null);

        void OnTransaction(TransactionSource source, IEnumerable<ITransactionData> transactionSpent, ITransactionData transactionReceived, IDictionary<string, string> sourceContext = null);
        void OnTransaction(TransactionSource source, ITransactionData transactionSpent, IEnumerable<ITransactionData> transactionsReceived = null, IDictionary<string, string> sourceContext = null);
        void OnSingleTransaction(TransactionSource source, ITransactionData transactionsSpent, ITransactionData transactionsReceived, IDictionary<string, string> sourceContext = null);
    }
}