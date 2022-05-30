using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message2 GetById(int id)
        {
            return _messageDal.TGetByID(id);
        }

        public List<Message2> GetInbox(int id)
        {
            return _messageDal.GetMessageWriter(id);
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<Message2> GetSendbox(int id)
        {
            return _messageDal.GetSendMessageWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
