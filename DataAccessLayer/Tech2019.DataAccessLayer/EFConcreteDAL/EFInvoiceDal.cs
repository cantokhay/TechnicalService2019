using System.Collections.Generic;
using System.Linq;
using Tech2019.DataAccessLayer.AbstractDAL;
using Tech2019.DataAccessLayer.Context;
using Tech2019.DTOLayer.InvoiceDTOs;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.DataAccessLayer.EFConcreteDAL
{
    public class EFInvoiceDal : EFGenericDal<Invoice>, IInvoiceDal
    {
        private readonly TechDBContext _context;

        public EFInvoiceDal(TechDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ResultInvoiceDTO> TGetInvoiceList()
        {
            return _context.Invoices
                .Where(i => i.DataStatus != EntityLayer.Enum.DataStatus.Deleted)
                .Select(i => new
                {
                    i.InvoiceId,
                    i.InvoiceSequenceNumber,
                    i.InvoiceSerialCharacter,
                    InvoiceDate = i.InvoiceDate,
                    i.InvoiceTaxOffice,
                    CustomerId = i.Customer,
                    CustomerFullName = i.CustomerNavigation.CustomerFirstName + " " + i.CustomerNavigation.CustomerLastName,
                    EmployeeId = i.Employee,
                    EmployeeFullName = i.EmployeeNavigation.EmployeeFirstName + " " + i.EmployeeNavigation.EmployeeLastName
                })
                .ToList()
                .Select(i => new ResultInvoiceDTO
                {
                    InvoiceId = i.InvoiceId,
                    InvoiceSequenceNumber = i.InvoiceSequenceNumber,
                    InvoiceSerialCharacter = i.InvoiceSerialCharacter,
                    InvoiceDate = i.InvoiceDate.ToString("dd-MM-yyyy"),
                    InvoiceHour = i.InvoiceDate.ToString("HH:mm"),
                    InvoiceTaxOffice = i.InvoiceTaxOffice,
                    CustomerId = i.CustomerId,
                    CustomerFullName = i.CustomerFullName,
                    EmployeeId = i.EmployeeId,
                    EmployeeFullName = i.EmployeeFullName
                })
                .ToList();
        }
    }
}