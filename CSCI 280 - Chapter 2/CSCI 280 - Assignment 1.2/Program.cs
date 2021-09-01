/*
 * Modified by Alexander Phelps
 * 3/8/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSCI_280___Assignment_1
{
    class Program

    {
        public class Employee
        {
            public Employee(string name)
            {
                this.name = name;
            }

            public string name { get; set; }
            public List<Employee> Employees
            {
                get
                {
                    return EmployeesList;
                }
            }

            public void isEmployeeOf(Employee e)
            {
                EmployeesList.Add(e);
            }

            List<Employee> EmployeesList = new List<Employee>();

            public override string ToString()
            {
                return name;
            }
        }

        public class DepthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee John = new Employee("John");
                Employee Tina = new Employee("Tina");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);

                // New employees
                Employee Mary = new Employee("Mary");
                Employee Ella = new Employee("Ella");
                Employee Alex = new Employee("Alex");
                Employee Greg = new Employee("Greg");
                Employee Steve = new Employee("Steve");
                Lisa.isEmployeeOf(Mary);
                John.isEmployeeOf(Ella);
                John.isEmployeeOf(Alex);
                Mike.isEmployeeOf(Greg);
                Mike.isEmployeeOf(Steve);
                //

                return Eva;
            }

            // Modified into breadth-first search
            public Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> open = new Queue<Employee>();

                open.Enqueue(root);
                while (open.Count > 0)
                {
                    Employee search = open.Dequeue();
                    if (search.name == nameToSearchFor)
                    {
                        return search;
                    }
                    else
                    {
                        foreach (Employee child in search.Employees)
                        {
                            open.Enqueue(child);
                        }
                    }
                }

                // not found
                return null;
            }

            // Modified into breadth-first traverse
            public void Traverse(Employee root)
            {
                Queue<Employee> open = new Queue<Employee>();

                open.Enqueue(root);
                while (open.Count > 0)
                {
                    Employee search = open.Dequeue();
                    Console.WriteLine(search.name);
                    foreach (Employee child in search.Employees)
                    {
                        open.Enqueue(child);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            DepthFirstAlgorithm b = new DepthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Alex");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Tammy");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Greg");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
        }
    }
}

