﻿using Utils;
using Utils.Enumeradores;

namespace Contatos.Requests
{
    public class ContatoPaginacaoRequest : PaginacaoFiltro
    {
        public ContatoPaginacaoRequest() : base("nome", TipoOrdernacao.Desc)
        {
        }

        public int? DDD { get; set; }
        public string? Regiao { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

    }
}
