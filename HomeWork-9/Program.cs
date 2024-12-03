using HomeWork_9.Core.University;
using HomeWork_9.Core.Employee;
using System;
using System.Collections.Generic;
using System.IO;

Console.WriteLine("create or upload [need to create an object to work with]");
Console.WriteLine("\n\n\n");
Console.WriteLine("                  [Create]   [Upload]");

string? option = Console.ReadLine();
string FileName = "Data.txt";

if (!File.Exists(FileName))
{
    File.Create(FileName).Dispose();
}

if (string.IsNullOrWhiteSpace(option))
{
    Console.WriteLine("Invalid option. Please choose 'Create' or 'Upload'.");
    return;
}

switch (option.ToLower())
{
    case "create":
        {
            Console.Write("University Name: ");
            string? Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Invalid name.");
                return;
            }

            Console.Write("University description: ");
            string? Descr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Descr))
            {
                Console.WriteLine("Invalid description.");
                return;
            }

            University univ = new(Name, Descr);
            Console.WriteLine("Class object \"University\" is created");

            string Data = $"University, {univ.Name}, {univ.Description};";
            File.AppendAllText(FileName, Data + Environment.NewLine);

            Console.Write("Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee Name: ");
            string? employeeName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                Console.WriteLine("Invalid employee name.");
                return;
            }

            Employee emp = new(employeeId, employeeName);
            Console.WriteLine("Class object \"Employee\" is created");

            string employeeData = $"Employee ,{emp.Id} ,{emp.Name};";
            File.AppendAllText(FileName, employeeData + Environment.NewLine);

            Console.WriteLine("Data successfully written to file.");
            break;
        }

    case "upload":
        {
            List<University> univs = new List<University>();
            List<Employee> employees = new List<Employee>();

            if (new FileInfo(FileName).Length == 0)
            {
                Console.WriteLine("No data found in file.");
                return;
            }

            Console.WriteLine("Loading Objects...");

            string Data = File.ReadAllText(FileName);
            string[] DataModules = Data.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string Module in DataModules)
            {
               
                string[] ObjectData = Module.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                
                if (ObjectData.Length >= 3)
                {
                    
                    if (ObjectData[0].Trim() == "University")
                    {
                        string name = ObjectData[1].Trim();
                        string description = ObjectData[2].Trim();
                        University univ = new(name, description);
                        univs.Add(univ);
                    }
                   
                    else if (ObjectData[0].Trim() == "Employee")
                    {
                        int id = int.Parse(ObjectData[1].Trim());
                        string name = ObjectData[2].Trim();
                        Employee emp = new(id, name);
                        employees.Add(emp);
                    }
                }
            }

            Console.WriteLine("\nLoaded Universities:");
            foreach (var univ in univs)
            {
                Console.WriteLine($"University name: {univ.Name}");
                Console.WriteLine($"University description: {univ.Description}");
            }

            Console.WriteLine("\nLoaded Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee ID: {emp.Id}");
                Console.WriteLine($"Employee Name: {emp.Name}");
            }

            Console.WriteLine("\n");
            break;
        }

    default:
        Console.WriteLine("Invalid option. Please choose 'Create' or 'Upload'.");
        break;
}
