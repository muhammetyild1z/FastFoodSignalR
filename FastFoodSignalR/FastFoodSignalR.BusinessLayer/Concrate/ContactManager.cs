using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.BusinessLayer.Concrate
{
    public class ContactManager : IContactService
    {
        IContactDal _contact;

        public ContactManager(IContactDal contact)
        {
            _contact = contact;
        }

        public void TAdd(Contact entity)
        {
            _contact.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contact.Delete(entity);
        }

        public Contact TGetById(int Id)
        {
            return _contact.GetById(Id);
        }

        public List<Contact> TGetListAll()
        {
           return _contact.GetListAll();
        }

      

        public void Update(Contact entity, Contact unchanged)
        {
            _contact.Update(entity, unchanged); 
        }
    }
}
