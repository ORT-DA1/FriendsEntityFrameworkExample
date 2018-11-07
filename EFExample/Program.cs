using DataAccess;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda a = new Agenda()
            {
                Name = "Agenda 1",
                Contacts = new List<User>()
            };

            User owner = new User()
            {
                Age = 24,
                Name = "Ramiro",
                Agendas = new List<Agenda>()
            };


            User contact1 = new User()
            {
                Age = 22,
                Name = "Lady",
                Agendas = new List<Agenda>()
            };

            User contact2 = new User()
            {
                Age = 21,
                Name = "Sir",
                Agendas = new List<Agenda>()
            };

            a.Contacts.Add(contact1);
            a.Contacts.Add(contact2);
            a.Owner = owner;

            Console.WriteLine("Se va a agregar la agenda con dos usuarios");
            Console.ReadKey();

            IDataAccess<Agenda> dataAccess = new AgendaDataAccess();
            dataAccess.Add(a);

            Console.WriteLine("Agenda Agregada");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener la agenda\n\n");
            Console.ReadKey();
            Agenda aCopy = dataAccess.Get(a.Id);

            Console.WriteLine(aCopy.Id);
            Console.WriteLine(aCopy.Name);
            Console.WriteLine(aCopy.Owner.Name);

            foreach (var u in aCopy.Contacts)
            {
                Console.WriteLine(u.Name);
            }
            Console.ReadKey();

            //Console.WriteLine("\n\nSe va a modificar la agenda");
            //Console.ReadKey();

            //aCopy.Name = "BLABLA";
            //aCopy.Owner.Name = "LadySir";
            //aCopy.Contacts.Add(new User() { Name = "Kid", Age = 20 });

            //dataAccess = new AgendaDataAccess();
            //dataAccess.Modify(aCopy);

            //Console.WriteLine("Agenda Modificada");
            //Console.ReadKey();
            //Console.WriteLine("Se va a obtener la agenda\n\n");
            //Console.ReadKey();
            //Agenda aCopy2 = dataAccess.Get(a.Id);

            //Console.WriteLine(aCopy2.Id);
            //Console.WriteLine(aCopy2.Name);
            //Console.WriteLine(aCopy2.Owner.Name);

            //foreach (var u in aCopy2.Contacts)
            //{
            //    Console.WriteLine(u.Name);
            //}

            //Console.ReadKey();




            User user2Agendas = new User()
            {
                Age = 21,
                Name = "Santiago",
                Agendas = new List<Agenda>()
            };

            Agenda agendaA = new Agenda()
            {
                Name = "Agenda A",
                Contacts = new List<User>()
            };

            Agenda agendaB = new Agenda()
            {
                Name = "Agenda B",
                Contacts = new List<User>()
            };

            agendaA.Owner = owner;
            agendaA.Owner = owner;
            user2Agendas.Agendas.Add(agendaA);
            user2Agendas.Agendas.Add(agendaB);

            Console.WriteLine("\n\nSe va a agregar usuario con dos agendas");
            Console.ReadKey();


            dataAccess = new AgendaDataAccess();
            IDataAccess<User> userDataAccess = new UserDataAccess();
            userDataAccess.Add(user2Agendas);

            Console.WriteLine("Usuario agregado");
            Console.ReadKey();
            Console.WriteLine("Se va a obtener el usuario\n\n");
            Console.ReadKey();
            User uCopy = userDataAccess.Get(user2Agendas.Id);

            Console.WriteLine(uCopy.Id);
            Console.WriteLine(uCopy.Name);
            Console.WriteLine(uCopy.Age);

            foreach (var agenda in uCopy.Agendas)
            {
                Console.WriteLine(agenda.Name);
            }

            Console.ReadKey();

        }
    }
}
