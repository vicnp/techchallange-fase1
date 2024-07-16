﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_Domain.Contatos.Entidades;
using TC_Domain.Contatos.Repositorios.Filtros;
using TC_IOC.Bibliotecas;
using TC_DataTransfer.Contatos.Reponses;
using TC_DataTransfer.Contatos.Requests;
using TC_Domain.Utils;
using YCTC_DataTransfer.Contatos.Requests;

namespace TC_Application.Contatos.Profiles
{
    public class ContatoProfile : Profile
    {
        public ContatoProfile()
        {
           CreateMap<ContatoPaginacaoRequest, ContatosPaginadosFiltro>();
           CreateMap<ContatoCrudRequest, ContatoFiltro>();
           CreateMap<ContatoRequest, ContatoFiltro>();
           CreateMap<Contato, ContatoResponse>();  
           CreateMap<PaginacaoConsulta<Contato>, PaginacaoConsulta<ContatoResponse>>();
        }
    }
}
