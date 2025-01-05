namespace Tech2019.DTOLayer.EmployeeDTOs
{
    public class EmployeeToSaleDTO
    {
        public short EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFullName => $"{EmployeeFirstName} {EmployeeLastName}";
    }
}
