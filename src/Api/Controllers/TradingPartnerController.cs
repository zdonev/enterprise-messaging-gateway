using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using Serilog;
using System.Web.Http.Description;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Helpers;
using EnterpriseMessagingGateway.Api.Extensions;
using System.Web.Http.Routing;

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [RoutePrefix("api/tradingpartners")]
    public class TradingPartnerController : ApiController
    {
        private readonly ITradingPartnerService _tpService;
        private readonly IReadRepository<TradingPartner> _tpReadRepository;
        private IPropertyMappingService _propertyMappingService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerController>();
        

        public TradingPartnerController(ITradingPartnerService tpService,
                               IReadRepository<TradingPartner> tpReadRepository,
                               IPropertyMappingService propertyMappingService)
        {
            _tpService = tpService;
            _tpReadRepository = tpReadRepository;
            _propertyMappingService = propertyMappingService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(TradingPartnerDetailDto))]
        public IHttpActionResult CreateTradingPartner(TradingPartnerDetailCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid Trading Partner Object!");
            }

            return Ok(_tpService.AddTradingPartner(dto));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(TradingPartnerDetailDto))]
        public IHttpActionResult GetTradingPartner(int id)
        {
            try
            {
                var tp = _tpService.GetTradingPartnerById(id);

                if (tp == null)
                {
                    return NotFound();
                }

                return Ok(tp);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }

        [HttpGet]
        [Route("", Name = "GetTradingPartners")]
        [ResponseType(typeof(IEnumerable<TradingPartnerDetailDto>))]
        public IHttpActionResult GetTradingPartners([FromUri] TradingPartnerResourceParameters parameters)
        {
            try
            {
                var pagedList = _tpReadRepository.ToPagedList(parameters, _propertyMappingService);

                var previousPageLink = pagedList.HasPrevious ?
                                        CreateResourceUri(parameters,
                                        ResourceUriType.PreviousPage) : null;

                var nextPageLink = pagedList.HasNext ?
                                    CreateResourceUri(parameters,
                                    ResourceUriType.NextPage) : null;

                _log.Information("Received Record {0}");
                var tpDto = AutoMapper.Mapper.Map<IEnumerable<TradingPartnerDetailDto>>(pagedList);
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
        [ResponseType(typeof(TradingPartnerDetailDto))]
        public IHttpActionResult UpdateTradingPartner([FromBody] TradingPartnerDetailDto dto)
        {
            try
            {
                var tpExists = _tpService.GetTradingPartnerById(dto.Id);

                if (tpExists == null)
                {
                    return NotFound();
                }

                return Ok(_tpService.UpdateTradingPartner(dto));

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
        [ResponseType(typeof(TradingPartner))]
        public IHttpActionResult DeleteTradingPartner(int id)
        {
            try
            {
                var entity = _tpService.GetTradingPartnerById(id);

                if (entity == null)
                {
                    return NotFound();
                }
                _tpService.DeleteTradingPartner(id);

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
            TradingPartnerResourceParameters parameters,
            ResourceUriType type)
        {

            var _urlHelper = new UrlHelper(Request);

            int pageAdjustment = type.GetPageAdjustment();

            return Url.Link("GetTradingPartners",
                    new
                    {
                        searchQuery = parameters.SearchQuery,
                        name = parameters.Name,
                        pageNumber = parameters.PageNumber + pageAdjustment,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        description = parameters.Description,
                        identifier = parameters.Identifier,
                        propertyName = parameters.PropertyName,
                        propertyValue = parameters.PropertyValue,
                        qualifier = parameters.Qualifier
                    });
        }

    }
}
