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

    [Route("clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        private readonly IRepairRepo _repairRepo;
        private readonly IClientRepo _repository;

        public ClientController(IClientRepo repository, IRepairRepo repairRepo, IProductRepo productRepo,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repairRepo = repairRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientReadDto>> GetClientList()
        {
            var clientList = _repository.GetListOfClients();
            if (clientList == null)
                return NotFound();

            foreach (var client in clientList)
            {
                client.Repairs = _repairRepo.GetListRepairs().Where(x => x.ClientId == client.Id).ToList();
                _mapper.Map<IEnumerable<RepairReadWithoutClient>>(client.Repairs);
                foreach (var clientRepair in client.Repairs)
                {
                    var mappedProduct =
                        _mapper.Map<ProductReadDto>(_productRepo.GetProductById(clientRepair.ProductId));
                    clientRepair.Product = mappedProduct;
                }
            }

            return Ok(_mapper.Map<IEnumerable<ClientReadDto>>(clientList));
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public ActionResult<ClientReadDto> GetClientById(int id)
        {
            var client = _repository.GetClientById(id);
            if (client == null)
                return NotFound();
            client.Repairs = _repairRepo.GetListRepairs().Where(x => x.ClientId == client.Id).ToList();
            foreach (var clientRepair in client.Repairs)
            {
                var mappedProduct = _mapper.Map<ProductReadDto>(_productRepo.GetProductById(clientRepair.ProductId));
                clientRepair.Product = mappedProduct;
            }

            return Ok(_mapper.Map<ClientReadDto>(client));
        }

        [HttpPost]
        public ActionResult<ClientCreateDto> CreateClient(ClientReadWithoutRepairsDto client)
        {
            var clientModel = _mapper.Map<Client>(client);
            _repository.CreateClient(clientModel);
            _repository.SaveChanges();

            var clientReadWithoutRepairsDto = _mapper.Map<ClientReadWithoutRepairsDto>(clientModel);

            return CreatedAtRoute(nameof(GetClientById), new {clientReadWithoutRepairsDto.Id},
                clientReadWithoutRepairsDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClient(int id, ClientUpdateDto client)
        {
            var clientFromRepo = _repository.GetClientById(id);
            if (clientFromRepo == null) return NotFound();
            _mapper.Map(client, clientFromRepo);

            _repository.UpdateClient(clientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            var clientFromRepo = _repository.GetClientById(id);
            if (clientFromRepo == null) return NotFound();

            _repository.DeleteClient(clientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}