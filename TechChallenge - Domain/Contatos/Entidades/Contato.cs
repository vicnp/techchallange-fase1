﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_Domain.Contatos.Entidades
{
    public class Contato
    {
        public int? Id { get; protected set; }
        public string? Nome { get; protected set; }
        public string? Email { get; protected set; }
        public int? DDD { get; protected set; }
        public string? Telefone { get; protected set; }

        public Contato()
        {

        }

        public Contato(string nome, string email, int numeroDDD, string telefone)
        {
            SetNome(nome);
            SetEmail(email);
            SetDDD(numeroDDD);
            SetTelefone(telefone);
        }

        public void SetId(int? id)
        {
            Id = id;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetDDD(int numeroDDD)
        {
            DDD = numeroDDD;
        }

        public void SetTelefone(string telefone) 
        { 
            Telefone =  telefone;
        }

    }
}
