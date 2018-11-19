using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface IDocumentTypeService
    {
        DocumentTypeDetailDto GetDocumentTypeById(int id);
        DocumentTypeDetailDto AddDocumentType(DocumentTypeCreateDto dto);
        DocumentTypeDto UpdateDocumentType(DocumentTypeDto dto);
        void DeleteDocumentType(int id);

        DocumentTypeResolverDto AddResolver(int docTypeId, DocumentTypeResolverCreateDto dto);
        DocumentTypeResolverDto GetResolver(int docTypeId, int id);
        DocumentTypeResolverDto UpdateResolver(int docTypeId, DocumentTypeResolverDto dto);
        void DeleteResolver(int docTypeId, int id);

    }
}
