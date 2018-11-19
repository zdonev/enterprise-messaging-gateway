using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IRepository<DocumentType> _docTypeRepository;
        private readonly IRepository<DocumentTypeResolver> _resolverRepository;
        private readonly ILogger _log = Log.ForContext<TaskService>();

        public DocumentTypeService(IRepository<DocumentType> docTypeRepository,
                                    IRepository<DocumentTypeResolver> resolverRepository)
        {
            _docTypeRepository = docTypeRepository;
            _resolverRepository = resolverRepository;
        }

        public DocumentTypeDetailDto GetDocumentTypeById(int id)
        {
            var entity = _docTypeRepository.GetById(id);
            return AutoMapper.Mapper.Map<DocumentTypeDetailDto>(entity);
        }

        public DocumentTypeDetailDto AddDocumentType(DocumentTypeCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<DocumentType>(dto);

            var newEntity = _docTypeRepository.Add(entity);

            return AutoMapper.Mapper.Map<DocumentTypeDetailDto>(newEntity);
        }

        public DocumentTypeDto UpdateDocumentType(DocumentTypeDto dto)
        {
            var entity = AutoMapper.Mapper.Map<DocumentType>(dto);
            _docTypeRepository.Update(entity);

            return AutoMapper.Mapper.Map<DocumentTypeDto>(entity);
        }

        public void DeleteDocumentType(int id)
        {
            var entity = _docTypeRepository.GetById(id);
            _docTypeRepository.Delete(entity);
        }

        public DocumentTypeResolverDto AddResolver(int docTypeId, DocumentTypeResolverCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<DocumentTypeResolver>(dto);

            var docType = _docTypeRepository.GetById(docTypeId);
            entity.DocumentType = docType;
            _resolverRepository.Add(entity);

            return AutoMapper.Mapper.Map<DocumentTypeResolverDto>(entity);
        }

        public DocumentTypeResolverDto GetResolver(int docTypeId, int id)
        {
            var entity = _resolverRepository.GetById(id);
            return AutoMapper.Mapper.Map<DocumentTypeResolverDto>(entity);
        }

        public DocumentTypeResolverDto UpdateResolver(int docTypeId, DocumentTypeResolverDto dto)
        {
            var entity = AutoMapper.Mapper.Map<DocumentTypeResolver>(dto);

            _resolverRepository.Update(entity);

            return AutoMapper.Mapper.Map<DocumentTypeResolverDto>(entity);
        }

        public void DeleteResolver(int docTypeId, int id)
        {
            var entity = _resolverRepository.GetById(id);
            _resolverRepository.Delete(entity);
        }
    }
}
