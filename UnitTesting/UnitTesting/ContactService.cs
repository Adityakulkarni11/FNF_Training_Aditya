using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingLib
{
    public class ContactService
    {
        public interface IContactRepository
        {
            Contact GetContactById(int id);
            void AddContact(Contact contact);
        }

        public class Contact
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public Contact GetContact(int id)
        {
            return _repository.GetContactById(id);
        }

        public void CreateContact(Contact contact)
        {
            _repository.AddContact(contact);
        }
    }
}

