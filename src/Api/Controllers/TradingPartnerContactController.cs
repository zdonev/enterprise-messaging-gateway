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

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [RoutePrefix("api/tradingpartners")]
    public class TradingPartnerContactController : ApiController
    {
        //private readonly IRepository<TradingPartnerContact> _repository;
        private readonly ITradingPartnerService _tpService;
        private readonly IRepository<TradingPartnerContact> _contactRepository;
        private IPropertyMappingService _propertyMappingService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerContactController>();


        public TradingPartnerContactController(ITradingPartnerService tpService,
                                IRepository<TradingPartnerContact> contactRepository,
                               IPropertyMappingService propertyMappingService)
        {
            _tpService = tpService;
            _contactRepository = contactRepository;
            _propertyMappingService = propertyMappingService;
        }

        [HttpPost]
        [Route("{tpid}/contacts")]
        [ResponseType(typeof(TradingPartnerContactDetailDto))]
        public IHttpActionResult CreateTradingPartnerContact(int tpid, [FromBody] TradingPartnerContactDetailCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid Contact Object!");
            }


            return Ok(_tpService.AddContact(tpid, dto));
        }


        [HttpGet]
        [Route("{tpid}/contacts/{id}")]
        [ResponseType(typeof(TradingPartnerContactDetailDto))]
        public IHttpActionResult GetTradingPartnerContact(int tpid, int id)
        {
            try
            {
                var contact = _tpService.GetContact(tpid, id);

                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }
        }


        [HttpGet]
        [Route("{tpid}/contacts")]
        [ResponseType(typeof(IEnumerable<TradingPartnerContactDetailDto>))]
        public IHttpActionResult GetContacts(int tpid, [FromUri] ContactResourceParameters parameters)
        {
            try
            {
                parameters = parameters ?? new ContactResourceParameters();
                IEnumerable<TradingPartnerContact> contacts;

                if (!string.IsNullOrEmpty(parameters.SearchQuery))
                {
                    var searchQuery = parameters.SearchQuery.ToLower();
                    contacts = _contactRepository.List(c => (c.City.ToLower().Contains(searchQuery)
                                                || c.Country.ToLower().Contains(searchQuery)
                                                || c.Email.ToLower().Contains(searchQuery)
                                                || c.Name.ToLower().Contains(searchQuery)
                                                || c.Phone.ToLower().Contains(searchQuery)
                                                || c.PostalCode.ToLower().Contains(searchQuery)
                                                || c.Role.ToLower().Contains(searchQuery)
                                                || c.State.ToLower().Contains(searchQuery)
                                                || c.Street.ToLower().Contains(searchQuery))
                                                && c.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();


                    //.Where(t => t.Name.ToLower().Contains(searchQuery)
                    //                     || t.Description.ToLower().Contains(searchQuery));
                }
                else
                {
                    //contacts = _repository.List().ToList();
                    contacts = _contactRepository.List(c => c.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }

                if (contacts == null)
                {
                    return NotFound();
                }
                var contactsDto = AutoMapper.Mapper.Map<IEnumerable<TradingPartnerContactDetailDto>>(contacts);


                return Ok(contactsDto);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }


        [HttpPut]
        [Route("{tpid}/contacts")]
        [ResponseType(typeof(IEnumerable<TradingPartnerContactDto>))]
        public IHttpActionResult UpdateContact(int tpid, [FromBody] TradingPartnerContactDto dto)
        {
            try
            {
                var entity = _tpService.GetContact(tpid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_tpService.UpdateContact(tpid, dto));
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));
            }
        }

        [HttpDelete]
        [Route("{tpid}/contacts/{id}")]
        public IHttpActionResult DeleteTask(int tpid, int id)
        {
            try
            {
                var entity = _tpService.GetContact(tpid, id);

                if (entity == null)
                {
                    return NotFound();
                }
                _tpService.DeleteContact(tpid, id);

                return Ok();
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }
    }
}
