using AutoMapper;
using Business.IRepostitory;
using Common;
using Entities.Entities;
using Entities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Controllers
{
    public class MenusController : BaseController
    {

        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<MenusController> _logger;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 30;
        public MenusController(IMenuRepository menuRepository,
            ILogger<MenusController> logger, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index(int? page)
        {
            var filter = HttpContext.Request.Query["search"];
            var rs = _menuRepository.GetAllData().Include(x=>x.ParentNavigationMenu)
                .Where(x =>!x.IsAdmin && (string.IsNullOrEmpty(filter) ||
                x.Name.Contains(filter.ToString()))).AsQueryable().OrderByDescending(x => x.Name).AsNoTracking();
            var data = await PaginatedList<NavigationMenu>.CreateAsync(rs, page ?? 1, _pageSize);
            var vm = new BaseViewModel<NavigationMenu>
            {
                Data = data
            };
            return View(vm);
        }

        [HttpGet()]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Add(MenuModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ParentMenuId == Guid.Empty)
                {
                    model.ParentMenuId = null;
                }
                var menu = _mapper.Map<NavigationMenu>(model);
                _menuRepository.Add(menu);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet("menus/Edit/{id}")]
        public IActionResult Edit(Guid id)
        {

            var menu = _menuRepository.GetAllData().FirstOrDefault(x => x.Id == id);
            if (menu != null)
            {
                var model = _mapper.Map<MenuModel>(menu);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("menus/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MenuModel model)
        {
            try
            {
                var menu = _menuRepository.GetAllData().FirstOrDefault(x => x.Id == id);
                if (menu != null)
                {
                    menu.Visible = model.Visible;
                    menu.NameEng = model.NameEng;
                    menu.Name = model.Name;
                    menu.ParentMenuId = model.ParentMenuId;
                    menu.DisplayOrder = model.DisplayOrder;
                    menu.ExternalUrl = model.ExternalUrl;
                    _menuRepository.Update(menu);
                    return RedirectToAction("Index");
                  
                }
                ModelState.AddModelError(string.Empty, string.Format(MessageConstants.NotExists, "Menu"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
            }
            return View(model);
        }
    }
}
