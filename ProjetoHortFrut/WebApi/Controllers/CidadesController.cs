﻿using ProjetoHortFrut.Domain.Cidade;
using ProjetoHortFrut.Domain.Cidades;
using ProjetoHortFrut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class CidadesController : ApiController
    {
        private readonly ICidadeService _cidadeService;
        private readonly Notifications _notifications;

        public CidadesController(Notifications notifications, ICidadeService cidadeService)
        {
            _notifications = notifications;
            _cidadeService = cidadeService;
        }

        public IHttpActionResult GetCidadesByEstadoId(int id)
        {
            try
            {
                List<Cidade> cidades = new List<Cidade>(_cidadeService.GetCidadesByEstadoId(id));
                if (_notifications.Notificacoes.Count > 0)
                {
                    string erros = "";
                    foreach (var erro in _notifications.Notificacoes)
                    {
                        erros = erros + " " + erro;
                    }
                    return BadRequest(erros);
                }
                else
                {
                    return Ok(cidades);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Ops! algo deu errado. Erro :{e.Message}");
            }
        }
    }
}
