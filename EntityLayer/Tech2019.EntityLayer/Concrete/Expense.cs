using System;

namespace Tech2019.EntityLayer.Concrete
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal ExpenseTotalPrice { get; set; }
    }
}
