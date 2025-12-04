using December.Domain.Entities;
using December.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December.Infrastructure.Repositories
{
    /// <summary>
    /// How do I make this class work?
    /// 1) Inherit Interface
    /// 2) Create constructor with DatabaseContext
    /// 3) Implement all methods in the interface
    /// 4) Remember to register the repository in the Dependency Injection 
    ///    container in Program.cs
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        public DatabaseContext context;
        public PersonRepository(DatabaseContext c) { context = c; }

        public async Task<Person?> Create(Person person)
        {
            context.Persons.Add(person);
            await context.SaveChangesAsync();
            return await context.Persons.FirstAsync(p => p.Equals(person));
            //return await context.Persons.FirstAsync(p => p.Name == person.Name && p.Lastname == person.Lastname
            //&& p.Mail == person.Mail);
            //return await context.Persons.FirstAsync(person.Id);
        }

        public async Task<List<Person>> GetAll()
        {
            // vælg database.table.Where()
            // vælg database.table.Max()
            var t = await context.Persons.ToListAsync();
            return t;
        }

        public async Task<Person?> GetById(int id)
        {
            return await context.Persons.FindAsync(id);
        }

        public async Task<Person?> Update(Person person)
        {
            var t = await context.Persons.FindAsync(person.Id);
            if(person.Name != null) t.Name = person.Name;
            if(person.Lastname != null) t.Lastname = person.Lastname;
            if(person.Mail != null) t.Mail = person.Mail;
            // FindAsync finder vores EF objekt. EF tracker hermed 't' automatisk. 
            // Så når vi laver SaveChangesAsync, bliver ændringer på t, gemt på databasen.
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new(e.Message + " Update throw");
            }
            return t;
        }
    }
}
