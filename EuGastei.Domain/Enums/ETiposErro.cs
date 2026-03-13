namespace EuGastei.Domain.Enums
{
    public enum ETiposErro
    {
        TENANT_NOME_É_OBRIGATORIO,
        TENANT_NÃO_ENCONTRADO,
        TENANT_ID_INVALIDO,

        PERMISSAO_ID_INVALIDO,
        PERMISSAO_NÃO_ENCONTRADO,
        PERMISSAO_SIGLA_É_OBRIGATORIO,
        PERMISSAO_DESCRICAO_É_OBRIGATORIO,

        PERFIL_ID_INVALIDO,
        PERFIL_NÃO_ENCONTRADO,
        PERFIL_NOME_É_OBRIGATORIO,
        PERFIL_DESCRICAO_É_OBRIGATORIO,

        USUARIO_ID_INVALIDO,
        USUARIO_NÃO_ENCONTRADO,
        USUARIO_NOME_É_OBRIGATORIO,
        USUARIO_APELIDO_É_OBRIGATORIO,
        USUARIO_EMAIL_É_OBRIGATORIO,
        USUARIO_SENHA_É_OBRIGATORIO,
    }

    public static class ETiposErroExtensions
    {
        public static string ToString(ETiposErro erro)
        {
            return erro switch
            {
                ETiposErro.TENANT_ID_INVALIDO => "TenantId inválido",
                ETiposErro.TENANT_NÃO_ENCONTRADO => "Tenant não encontrado",
                ETiposErro.TENANT_NOME_É_OBRIGATORIO => "Obrigatório informar nome do tenant",

                ETiposErro.PERMISSAO_ID_INVALIDO => "PermissãoId inválido",
                ETiposErro.PERMISSAO_NÃO_ENCONTRADO => "Permissão não encontrado",
                ETiposErro.PERMISSAO_SIGLA_É_OBRIGATORIO => "Obrigatório informar sigla da permissão",
                ETiposErro.PERMISSAO_DESCRICAO_É_OBRIGATORIO => "Obrigatório informar descriçãa da permissão",

                ETiposErro.PERFIL_ID_INVALIDO => "PerfilId inválido",
                ETiposErro.PERFIL_NÃO_ENCONTRADO => "Perfil não encontrado",
                ETiposErro.PERFIL_NOME_É_OBRIGATORIO => "Obrigatório informar nome do perfil",
                ETiposErro.PERFIL_DESCRICAO_É_OBRIGATORIO => "Obrigatório informar descrição do perfil",

                ETiposErro.USUARIO_ID_INVALIDO => "UsuárioId inválido",
                ETiposErro.USUARIO_NÃO_ENCONTRADO => "Usuário não encontrado",
                ETiposErro.USUARIO_NOME_É_OBRIGATORIO => "Obrigatório informar nome do usuário",
                ETiposErro.USUARIO_APELIDO_É_OBRIGATORIO => "Obrigatório informar apelido do usuário",
                ETiposErro.USUARIO_EMAIL_É_OBRIGATORIO => "Obrigatório informar email do usuário",
                ETiposErro.USUARIO_SENHA_É_OBRIGATORIO => "Obrigatório informar senha do usuário",



                


                _ => erro.ToString()
            };
        }
    }
}
