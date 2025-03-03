using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public AdminContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.TGetAll();
            var contactDtos = _mapper.Map<List<ResultContactDto>>(contacts);
            return View(contactDtos);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _contactService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return View(contactDto);
            var contact = _mapper.Map<Contact>(contactDto);
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Update([FromRoute] int id)
        {
            var contact = _contactService.TGetById(id);
            var contactDto = _mapper.Map<UpdateContactDto>(contact);
            return View(contactDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return View(contactDto);
            var contact = _mapper.Map<Contact>(contactDto);
            _contactService.TUpdate(contact);
            return RedirectToAction("Index");
        }

    }
}
