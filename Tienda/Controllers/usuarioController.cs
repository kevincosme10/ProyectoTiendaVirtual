using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Tienda.Infraestructura.Base;
using TiendaEntities.DTOS;
using TiendaEntities.Models;
using TiendaService.Base.BaseInterface;
using TiendaService.Service;
using TiendaService.ServiceInterface;

namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : BaseApi<usuario, usuarioDto, IServiceBase<usuario>>
    {
        readonly Iusuario usuarioService;

        public usuarioController(IServiceBase<usuario> manager,IMapper mapper , Iusuario _usuarioService ): base(manager, mapper)
        {
            this.usuarioService = _usuarioService;
        }

        [HttpGet]
        [Route("Login")]
        public JsonResult login(string correo, string contrasena)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena)) {
                return Json(new { isOK = false, Message = "Error: valores nulos" });
            }
            else
            {
                usuario usr = usuarioService.login(correo, contrasena);
                if (usr != null && usr.Id > 0)
                {
                    return Json(new { obj = usr, isOK = true });
                }
                else
                {
                    return Json(new { isOK = false, Message = "Correo o Contraseña invalidos" });
                }
            }
        }

        public usuario get() 
        {
            return new usuario();
        }
    }
}
