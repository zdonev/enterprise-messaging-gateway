using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using EnterpriseMessagingGateway.Services.Helpers;
using EnterpriseMessagingGateway.Api.Extensions;
using System.Web.Http.Routing;

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [RoutePrefix("api/doctypes/{doctypeid}/resolvers")]
    public class DocumentTypeResolverController : ApiController
    {
        private readonly IReadRepository<DocumentTypeResolver> _readRepository;
        private readonly IDocumentTypeService _docTypeService;
        private IPropertyMappingService _propertyMappingService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerContactProperty>();


        public DocumentTypeResolverController(IReadRepository<DocumentTypeResolver> readRepository,
                                                IDocumentTypeService docTypeService,
                                                IPropertyMappingService propertyMappingService)
        {
            _readRepository = readRepository;
            _docTypeService = docTypeService;
            _propertyMappingService = propertyMappingService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(DocumentTypeResolverDto))]
        public IHttpActionResult Create(int doctypeid, [FromBody] DocumentTypeResolverCreateDto resolver)
        {
            if (resolver == null)
            {
                return BadRequest("Invalid Property Object!");
            }                        

            return Ok(_docTypeService.AddResolver(doctypeid, resolver));
        }


        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(DocumentTypeResolverDto))]
        public IHttpActionResult Get(int doctypeid, int id)
        {
            try
            {
                var dto = _docTypeService.GetResolver(doctypeid, id);

                if (dto == null)
                {
                    return NotFound();
                }

                return Ok(dto);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }
        }


        [HttpGet]
        [Route("", Name = "GetDocumentTypeResolvers")]
        [ResponseType(typeof(IEnumerable<DocumentTypeResolverDto>))]
        public IHttpActionResult GetList(int doctypeid, [FromUri] ResolverResourceParameters parameters)
        {
            try
            {
                var pagedList = _readRepository.ToPagedList(parameters, _propertyMappingService);

                var previousPageLink = pagedList.HasPrevious ?
                                        CreateResourceUri(parameters,
                                        ResourceUriType.PreviousPage) : null;

                var nextPageLink = pagedList.HasNext ?
                                    CreateResourceUri(parameters,
                                    ResourceUriType.NextPage) : null;

                var tpDto = AutoMapper.Mapper.Map<IEnumerable<DocumentTypeResolverDto>>(pagedList);
                var response = Request.CreateResponse(HttpStatusCode.OK, tpDto);
                response.Headers.Add("X-Pagination-PageNumber", pagedList.CurrentPage.ToString());
                response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pagedList.MetaData(previousPageLink, nextPageLink)));
                return ResponseMessage(response);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }


        [HttpPut]
        [Route("")]
        [ResponseType(typeof(DocumentTypeResolverDto))]
        public IHttpActionResult Update(int doctypeid, [FromBody] DocumentTypeResolverDto dto)
        {
            try
            {
                var entity = _docTypeService.GetResolver(doctypeid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_docTypeService.UpdateResolver(doctypeid, dto));
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int doctypeid, int id)
        {
            try
            {
                var entity = _docTypeService.GetResolver(doctypeid, id);

                if (entity == null)
                {
                    return NotFound();
                }

                _docTypeService.DeleteResolver(doctypeid, id);                

                return Ok();
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }

        private string CreateResourceUri(
            ResolverResourceParameters parameters,
            ResourceUriType type)
        {

            var _urlHelper = new UrlHelper(Request);

            int pageAdjustment = type.GetPageAdjustment();

            return Url.Link("GetDocumentTypeResolvers",
                    new
                    {
                        searchQuery = parameters.SearchQuery,
                        name = parameters.Name,
                        pageNumber = parameters.PageNumber + pageAdjustment,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        description = parameters.Description,
                        value = parameters.Value
                    });
        }
    }
}
