using CRUDInWPFSample.Data;
using CRUDInWPFSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDInWPFSample.Model
{
    public class PersonnelBusinessObject
    {
        List<User> Employee { get; set; }
        public PersonnelBusinessObject()
        {
            Employee = DatabaseLayer.GetEmployeeFromDatabase();
        }

        public List<User> GetEmployees()
        {
            return Employee = DatabaseLayer.GetEmployeeFromDatabase();
        }

        List<NationalityCollection> NationalityCollection { get; set; }

        public EventHandler EmployeeChanged { get; internal set; }

        public List<NationalityCollection> GetNationality()
        {
            return NationalityCollection = DatabaseLayer.GetNationality();
        }
        public void AddEmployee(User employee)
        {
            DatabaseLayer.InsertEmployee(employee);
            OnEmployeeChanged();
        }

        public void UpdateEmployee(User employee)
        {
            DatabaseLayer.UpdateEmployee(employee);
            OnEmployeeChanged();
        }

        public void DeleteEmployee(User employee)
        {
            DatabaseLayer.DeleteEmployee(employee);
            OnEmployeeChanged();
        }

        void OnEmployeeChanged()
        {
            if (EmployeeChanged != null)
                EmployeeChanged(this, null);
        }
    }
}
