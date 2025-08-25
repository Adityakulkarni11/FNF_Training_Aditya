using System;
using System.Collections.Generic;

namespace Assignment.Data;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public string? ExpDesc { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? ExpDate { get; set; }
}
