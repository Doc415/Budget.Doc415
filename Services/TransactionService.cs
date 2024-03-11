﻿using Budget.Doc415.Models;
using Budget.Doc415.Repositories;
using Budget.Doc415.Transformations;

namespace Budget.Doc415.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }


    public async Task<List<Transaction>> GetAllTransactions(string name, string transactionDate, int categoryId)
    {
        var _transactionDate = Transformer.ConvertToDateTime(transactionDate);
        return await _transactionRepository.GetAllTransactions(name, _transactionDate, categoryId);
    }

    public async Task InsertTransaction(Transaction transaction)
    {
        await _transactionRepository.InsertTransaction(transaction);
    }

    public async Task DeleteTransaction(int id)
    {
        await _transactionRepository.DeleteTransaction(id);
    }

    public async Task UpdateTransaction(int id, Transaction transaction)
    {
        await _transactionRepository.UpdateTransaction(id, transaction);
    }

    public async Task<Transaction> GetTransactionById(int id)
    {
        return await _transactionRepository.GetTransactionById(id);
    }

}
