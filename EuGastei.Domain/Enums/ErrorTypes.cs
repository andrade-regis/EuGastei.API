using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EuGastei.Domain.Enums
{

    //TODO: Criar um enum para cada entidade e uma mensagem de erro correspondente
    public enum TiposErro
    {
        TENANT_NOME_NÃO_ENCONTRADO


    }

    public static class ErrorTypesExtensions
    {
        public static string ToString(TiposErro erro)
        {
            return erro switch
            {
                TiposErro.TENANT_NOME_NÃO_ENCONTRADO => "Obrigatório informar nome do Tenant",
                _ => erro.ToString()
            };
        }
    }
}
