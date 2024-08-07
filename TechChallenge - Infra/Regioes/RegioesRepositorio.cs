﻿using Dapper;
using TC_Domain.Regioes.Entidades;
using TC_Domain.Regioes.Repositorios;
using TC_IOC.Bibliotecas;
using TC_IOC.DBContext;

namespace TC_Infra.Regioes
{
    public class RegioesRepositorio(DapperContext dapperContext) : RepositorioDapper<Regiao>(dapperContext), IRegioesRepositorio
    {
        public async Task<List<Regiao>> ListarRegioesAsync(int ddd = 0)
        {
            string SQL = @"
                            SELECT ddd as RegiaoDDD,
                                   estado,
                                   regiao as Descricao
                            FROM TECHCHALLENGE.regioes
                            WHERE 1 = 1
                         ";
            if(ddd > 0)
            {
                SQL += $@"
                        AND ddd = {ddd}
                        ";
            } 
            
            var result =  await session.QueryAsync<Regiao>(SQL);
            return result.ToList();
        }
    }
}
