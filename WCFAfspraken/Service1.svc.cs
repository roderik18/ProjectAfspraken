using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFAfspraken
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IAfspraakService
    {
        AfspraakDB data;
        public Service1()
        {
            data = new AfspraakDB();
        }

        public List<Afspraak> GetAfspraken()
        {
            return data.GetAfspraken();
        }

        public List<Afspraak> GetAll()
        {
            return data.GetAll();
        }

        public List<Afspraak> GetInvites()
        {
            return data.GetInvites();
        }

        public void VastUpdate(Afspraak af)
        {
            data.VastUpdate(af);
        }

        public void Delete(Afspraak af)
        {
            data.Delete(af);
        }

        public void NewAfspraak(Afspraak af)
        {
            data.NewAfspraak(af);
        }
    }
}
