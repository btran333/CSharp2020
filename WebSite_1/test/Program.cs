﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Database accessor. This opens the database automatically
            var school = new ClassEntities();

            // This accesses the ClassMaster table
            foreach (var classMaster in school.Classes)
            {
                Console.WriteLine("ClassId: {0}\nClassName: {1}\nClassDescription: {2}\nClassPrice: {3}\n",
                    classMaster.ClassId, classMaster.ClassName, classMaster.ClassDescription, classMaster.ClassPrice);
            }

            Console.Write("Done.");
            Console.ReadLine();
        }
    }
}
