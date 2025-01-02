using System;
using Tech2019.EntityLayer.Abstract;
using Tech2019.EntityLayer.Enum;

namespace Tech2019.EntityLayer.Concrete
{
    public class Expense : IGenericEntity
    {
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal ExpenseTotalPrice { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
