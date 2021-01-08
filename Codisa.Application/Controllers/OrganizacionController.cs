using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Codisa.Infrastructure.ParamsDTO;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Codisa.Application.Controllers
{
    public class OrganizacionController : Controller
    {
        #region ATTRIBUTES
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public OrganizacionController (IMapper mapper, IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository ?? throw new ArgumentNullException(nameof(empleadoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region "METODOS"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IList<EmpleadoDto> empleadoDtos = _mapper.Map<IList<EmpleadoDto>>(await _empleadoRepository.GetAllEmployee());
            ViewData["EmpleadosA"] = empleadoDtos.Where(e => e.IdJefe == 1);
            ViewData["EmpleadosB"] = empleadoDtos.Where(e => e.IdJefe == 2);

            return View();
        }
        #endregion
    }
}