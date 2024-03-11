using Budget.Doc415.Models;
using Budget.Doc415.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Budget.Doc415.Controllers;


public class TransactionController : Controller
{
    private readonly TransactionService _transactionService;
    private readonly CategoryService _categoryService;

    public TransactionController(TransactionService transactionService, CategoryService categoryService)
    {
        _transactionService = transactionService;
        _categoryService = categoryService;
    }

   
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> Index(string name, string transactionDate, int categoryId)
    {
        var transactionList = await _transactionService.GetAllTransactions(name, transactionDate, categoryId);
        var categoryList= await _categoryService.GetAllCategories();
        var modelToView=new IndexViewModel() { Categories=categoryList, Transactions=transactionList};
        return View(modelToView);
    }

    
    [HttpPost]
    public async Task<ActionResult> Add(Transaction transaction)
    {
        await _transactionService.InsertTransaction(transaction);
        return Ok();
    }

    
    [HttpPut]
    public async Task<IActionResult> Put(int id, Transaction transaction)
    {
        if (id != transaction.Id)
        {
            await Task.FromResult(result: BadRequest());
        }
        await _transactionService.UpdateTransaction(id, transaction);
        return Ok();
    }

    
    [HttpDelete]
    public async Task Delete(int id)
    {
        await _transactionService.DeleteTransaction(id);
    }
}
