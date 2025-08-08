using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.GenericsEx
{
    class Employee:Object
    {
        //data, shall be private by default
        private int _id;
        string _name;
        string _address;
        double _salary;
        string _designation;

        public int EmpID
        {
            get { return _id; }
            set { _id = value; }//value is the smart keyword that refers to the value being assigned to the property
        }

        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }


        public string EmpAddress
        {
            get { return _address; }
            set { _address = value; }
        }


        public double EmpSalary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }
        public override string ToString()
        {
            return EmpID.ToString();
        }

        //GetHashCode() is used to get a hash code for the object. It is used in collections like HashSet, Dictionary etc. The hash value is used to quickly locate the object in the collection.
        public override int GetHashCode()
        {
            return EmpID;
        }
        //Implement the logical Equivalence for the Employee class.
        public override bool Equals(object? obj)
        {
            //If 2 EmpIds are same, then the objects are considered equal.
            if (obj is Employee emp)
            {
                if (this.EmpID == emp.EmpID)
                    return true;
                else
                    return false;
            }
            return false; //If the object is not of type Employee, then return false.
        }
    }
}
