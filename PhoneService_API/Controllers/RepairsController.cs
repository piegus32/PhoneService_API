using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneService_API.Data;
using PhoneService_API.Dtos;
using PhoneService_API.Models;

namespace PhoneService_API.Controllers
{
    [Route("repairs")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        private readonly IRepairRepo _repairRepo;

        public RepairsController(IRepairRepo repairRepo, IClientRepo clientRepo, IProductRepo productRepo,
            IMapper mapper)
        {
            _repairRepo = repairRepo;
            _productRepo = productRepo;
            _mapper = mapper;
            _clientRepo = clientRepo;
        }

        [HttpGet]
        public ActionResult<RepairReadDto> GetRepairList()
        {
            var listRepairs = _repairRepo.GetListRepairs().Where(repair => repair.DoneAttr == false);
            return Ok(_mapper.Map<IEnumerable<RepairReadDto>>(FilledFieldsOfRepairs(listRepairs)));
        }

        [HttpGet("complete")]
        public ActionResult<RepairReadDto> GetCompleteRepairs(){
            var completeRepairs = _repairRepo.GetListRepairs().Where(repair => repair.DoneAttr).ToList();
            return Ok(_mapper.Map<IEnumerable<RepairReadDto>>(FilledFieldsOfRepairs(completeRepairs)));
        }

        [HttpGet("{id}", Name = "GetRepairById")]
        public ActionResult<RepairReadDto> GetRepairById(int id)
        {
            var repair = _repairRepo.GetRepairById(id);

            if (repair == null)
                return NotFound();

            var productReadDto = _mapper.Map<ProductReadDto>(_productRepo.GetProductById(repair.ProductId));
            var clientReadWithoutRepairsDto =
                _mapper.Map<ClientReadWithoutRepairsDto>(_clientRepo.GetClientById(repair.ClientId));
            repair.Client = clientReadWithoutRepairsDto;
            repair.Product = productReadDto;
            return Ok(_mapper.Map<RepairReadDto>(repair));
        }

        [HttpPost]
        public ActionResult<RepairCreateDto> CreateRepair(RepairReadWithIdsDto repair)
        {
            var repairModel = _mapper.Map<Repair>(repair);
            _repairRepo.NewRepair(repairModel);
            _repairRepo.SaveChanges();

            var repairReadDto = _mapper.Map<RepairReadWithIdsDto>(repairModel);

            return CreatedAtRoute(nameof(GetRepairById), new {repairReadDto.Id}, repairReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRepair(int id, RepairReadForUpdateDto repair)
        {
            var repairFromRepo = _repairRepo.GetRepairById(id);
            if (repairFromRepo == null) return NotFound();
            _mapper.Map(repair, repairFromRepo);

            _repairRepo.UpdateRepair(repairFromRepo);
            _repairRepo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRepair(int id)
        {
            var repairFromRepo = _repairRepo.GetRepairById(id);
            if (repairFromRepo == null) return NotFound();

            _repairRepo.DeleteRepair(repairFromRepo);
            _repairRepo.SaveChanges();

            return NoContent();
        }

        [HttpPut("mark-complete/{id}")]
        public ActionResult MarkAsComplete(int id)
        {
            var repair = _repairRepo.GetRepairById(id);

            repair.DoneAttr = true;
            repair.CompletionDate = DateTime.Now;
            repair.WarrantyDate = DateTime.Now.AddMonths(repair.Warranty);

            _repairRepo.UpdateRepair(repair);
            _repairRepo.SaveChanges();

            return NoContent();
        }

        private IEnumerable<Repair> FilledFieldsOfRepairs(IEnumerable<Repair> repairs)
        {
            if (repairs == null)
                return null;

            var fillInTheFieldOfRepairs = repairs.ToList();
            foreach (var repair in fillInTheFieldOfRepairs)
            {
                var productReadDto = _mapper.Map<ProductReadDto>(_productRepo.GetProductById(repair.ProductId));
                var clientReadWithoutRepairsDto =
                    _mapper.Map<ClientReadWithoutRepairsDto>(_clientRepo.GetClientById(repair.ClientId));
                repair.Client = clientReadWithoutRepairsDto;
                repair.Product = productReadDto;
            }

            return fillInTheFieldOfRepairs;
        }
    }
}