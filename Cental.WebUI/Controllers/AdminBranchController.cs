using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BranchDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public AdminBranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var branches = _branchService.TGetAll();
            var resultDto = _mapper.Map<List<ResultBranchDto>>(branches);
            return View(resultDto);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBranchDto branchDto)
        {
            if (!ModelState.IsValid)
                return View(branchDto);
            var branch = _mapper.Map<Branch>(branchDto);
            _branchService.TCreate(branch);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update([FromRoute]int id)
        {
            var branch = _branchService.TGetById(id);
            var branchDto = _mapper.Map<UpdateBranchDto>(branch);
            return View(branchDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateBranchDto branchDto)
        {
            if (!ModelState.IsValid)
                return View(branchDto);
            var branch = _mapper.Map<Branch>(branchDto);
            _branchService.TUpdate(branch);
            return RedirectToAction("Index");
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _branchService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
