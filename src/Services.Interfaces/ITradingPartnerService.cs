using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface ITradingPartnerService
    {
        TradingPartnerDetailDto GetTradingPartnerById(int id);
        TradingPartnerDetailDto AddTradingPartner(TradingPartnerDetailCreateDto dto);
        TradingPartnerDto UpdateTradingPartner(TradingPartnerDto dto);
        void DeleteTradingPartner(int id);

        TradingPartnerPropertyDto AddProperty(int tpid, TradingPartnerPropertyCreateDto dto);
        TradingPartnerPropertyDto GetProperty(int tpid,  int id);
        TradingPartnerPropertyDto UpdateProperty(int tpid, TradingPartnerPropertyDto dto);
        void DeleteProperty(int tpid, int id);

        TradingPartnerIdentifierDto AddIdentifier(int tpid, TradingPartnerIdentifierCreateDto dto);
        TradingPartnerIdentifierDto GetIdentifier(int tpid, int id);
        TradingPartnerIdentifierDto UpdateIdentifier(int tpid, TradingPartnerIdentifierDto dto);
        void DeleteIdentifier(int tpid, int id);

        TradingPartnerContactDetailDto AddContact(int tpid, TradingPartnerContactDetailCreateDto dto);
        TradingPartnerContactDetailDto GetContact(int tpid, int id);
        TradingPartnerContactDto UpdateContact(int tpid, TradingPartnerContactDto dto);
        void DeleteContact(int tpid, int id);

        TradingPartnerContactPropertyDto AddContactProperty(int tpid, int contactid, TradingPartnerContactPropertyCreateDto dto);
        TradingPartnerContactPropertyDto GetContactProperty(int tpid, int contactid, int id);
        TradingPartnerContactPropertyDto UpdateContactProperty(int tpid, int contactid, TradingPartnerContactPropertyDto dto);
        void DeleteContactProperty(int tpid, int contactid, int id);

        
    }
}
