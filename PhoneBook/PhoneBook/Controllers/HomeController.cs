using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BusinessLogic.Contracts;
using PhoneBook.BusinessLogic.DTO;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PhoneBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IMapper _mapper;
        private readonly IPhoneService _phoneService;

        private readonly UserManager<UserDto> _userManager;

        public HomeController(IMapper mapper, IPhoneService phoneService, UserManager<UserDto> userManager)
        {
            _mapper = mapper;
            _phoneService = phoneService;
            _userManager = userManager;
        }

        public IActionResult Index(IndexViewModel model)
        {
            if (model.CurrentPage <= 0 || model.Search != null)
            {
                model.CurrentPage = 1;
            }
            int curent = model.CurrentPage;

            var curenUserId = _userManager.GetUserId(User);
            var items = _phoneService.GetPhones(ref curent, model.PageSize, model.Search, new Guid(curenUserId));
            var phones = items.Item1;
            var total = items.Item2;
            var phonesViewModel = _mapper.Map<IEnumerable<PhoneViewModel>>(phones);

            model.PageViewModel= new PageViewModel(total, model.PageSize, curent);
            model.Phones = phonesViewModel;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
