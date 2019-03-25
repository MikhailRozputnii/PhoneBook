using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BusinessLogic.Contracts;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Models;
using System;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;
        private IMapper _mapper;
        private readonly UserManager<UserDto> _userManager;

        public PhoneController(IPhoneService phoneService, UserManager<UserDto> userManager, IMapper mapper)
        {
            _phoneService = phoneService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var curenUserId = _userManager.GetUserId(User);
                var phoneNumber = $"+{model.PhoneNumber}";
                var phoneDto = new PhoneDto
                {
                    Name = model.Name,
                    PhoneNumber = phoneNumber,
                    Description = model.Description
                };


                var result = _phoneService.Create(phoneDto, new Guid(curenUserId));
                if (result != null)
                {
                    if (result.Name == model.Name)
                    {
                        ModelState.AddModelError(string.Empty, $"Contact {model.Name} already exists. Enter new name!");
                        return View(model);
                    }

                    ModelState.AddModelError(string.Empty, $"Contact {model.PhoneNumber} already exists. Enter new number!");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(Guid phoneId)
        {
            if (phoneId == Guid.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            var curenUserId = _userManager.GetUserId(User);
            var phoneDto = _phoneService.GetPhone(phoneId, new Guid(curenUserId));
            var phoneViewModel = _mapper.Map<PhoneViewModel>(phoneDto);

            return View(phoneViewModel);
        }

        public IActionResult ConfirmDelete(Guid phoneId)
        {
            var curenUserId = _userManager.GetUserId(User);
            _phoneService.Delete(phoneId, new Guid(curenUserId));
            return RedirectToAction("Index", "Home", new IndexViewModel());
        }
    }
}