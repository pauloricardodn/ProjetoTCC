﻿
using ProjetoHortFrut.Application.Interfaces;
using ProjetoHortFrut.Domain.Cidades;
using ProjetoHortFrut.Domain.Estados;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ProjetoHortFrut.MVC.Controllers
{
    [Authorize]
    public class EstadosCidadesController : Controller
    {
        private readonly IEstadoAppService _estadoAppService;
        private readonly ICidadesAppService _cidadeAppService;
        private List<SelectListItem> Cidades;

        public EstadosCidadesController(IEstadoAppService estadoAppService, ICidadesAppService cidadeAppService)
        {
            _estadoAppService = estadoAppService;
            _cidadeAppService = cidadeAppService;
            Cidades = new List<SelectListItem>(); ;
        }

        // GET: EstadosCidades
        public IEnumerable<Estado> GetAllEstados()
        {
            try
            {
                var statusCode = _estadoAppService.GetAllEstados();
                if (!statusCode.IsSuccessStatusCode)
                {
                    return null;
                }
                return statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result;
            }
            catch {
                return null;
            }
        }

        //Busca Cidades pelo id do estado
        public JsonResult GetCidadesByIdEstado(int id)
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _cidadeAppService.GetCidadesByEstadoId(id);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
                }
                return Json(statusCode.Content.ReadAsAsync<IEnumerable<Cidade>>().Result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }
     
        public JsonResult GetCidadeJaCadastrada(int cidadeId, int EstadoId)
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _cidadeAppService.GetCidadesByEstadoId(EstadoId);
                if (!statusCode.IsSuccessStatusCode)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 400;
                    return Json(statusCode.Content.ReadAsStringAsync().Result, JsonRequestBehavior.AllowGet);
                }
                var cidades = new List<Cidade>(statusCode.Content.ReadAsAsync<IEnumerable<Cidade>>().Result);
                foreach (var item in cidades)
                {
                    if (item.cidadeId == cidadeId)
                    {
                        Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
                    }
                }
                foreach (var item in cidades)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Nome, Value = item.cidadeId + "" });
                }
                Response.StatusCode = 200;
                return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
            }
            catch {
                return null;
            }
        }
        [HttpGet]
        public JsonResult GetEstadoJaCadastrado(int EstadoId)
        {
            try
            {
                var statusCode = new HttpResponseMessage();
                statusCode = _estadoAppService.GetAllEstados();
                if (!statusCode.IsSuccessStatusCode)
                {
                    return null;
                }
                var estados = new List<Estado>(statusCode.Content.ReadAsAsync<IEnumerable<Estado>>().Result);
                foreach (var item in estados)
                {
                    if (item.EstadoId == EstadoId)
                    {
                        Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
                    }
                }
                foreach (var item in estados)
                {
                    Cidades.Add(new SelectListItem() { Text = item.Sigla, Value = item.EstadoId + "" });
                }
                return Json(new SelectList(Cidades, "Value", "Text", 0), JsonRequestBehavior.AllowGet);
            }
            catch {
                return null;
            }
        }
    }
}