﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFAfspraken
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    
    [ServiceContract]
    public interface IAfspraakService
    {

        [OperationContract]
        List<Afspraak> GetAll();

        [OperationContract]
        List<Afspraak> GetInvites();

        [OperationContract]
        List<Afspraak> GetAfspraken();

        [OperationContract]
        void VastUpdate(Afspraak a);

        [OperationContract]
        void Delete(Afspraak a);

        [OperationContract]
        void NewAfspraak(Afspraak a);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Afspraak
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Cursist cursist { get; set; }

        [DataMember]
        public TrajectBegeleider TB { get; set; }

        [DataMember]
        public DateTime StartUur { get; set; }

        [DataMember]
        public DateTime StopUur { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public Boolean Vastgelegd { get; set; }

        public Afspraak()
        {

        }

        public void VastLeggen()
        {
            if (!this.Vastgelegd)
            {
                this.Vastgelegd = true;
                //Stuur bericht naar cursist dat afspraak is vastgelegd
                new AfspraakDB().VastUpdate(this);
            }
        }

        public void Cancellen()
        {
            if (this.Vastgelegd)
            {
                this.Vastgelegd = false;
                //Stuur bericht naar afzender (cursist) dat afspraak gecancelled is.
                //comment van TB met rede
                new AfspraakDB().Delete(this);
            }
        }

        public void CancelInv()
        {
            if (!this.Vastgelegd)
            {
                //stuur bericht naar cursist dat afspraak niet is vastgelegd.
                //comment van TB met rede
                new AfspraakDB().Delete(this);
            }
        }

        public void Opslaan()
        {
            //Slaagt de afspraak op in de database
            new AfspraakDB().NewAfspraak(this);
        }
    }

    [DataContract]
    public class Cursist
    {
        [DataMember]
        public string CursistId { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public string Voornaam { get; set; }

        public void NieuweAfspraak()
        {
            //nieuwe afspraak maken.
        }
    }

    [DataContract]
    public class TrajectBegeleider
    {
        [DataMember]
        public string TBid { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public string Voornaam { get; set; }
    }
}
