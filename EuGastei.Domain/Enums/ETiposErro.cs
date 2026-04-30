namespace EuGastei.Domain.Enums
{
    public enum ETiposErro
    {
        TENANT_ID_INVALIDO,
        TENANT_NOME_É_OBRIGATORIO,

        PERMISSAO_ID_INVALIDO,
        PERMISSAO_NÃO_ENCONTRADO,
        PERMISSAO_SIGLA_É_OBRIGATORIO,
        PERMISSAO_DESCRICAO_É_OBRIGATORIO,

        PERFIL_PERMISSAO_ID_INVALIDO,
        PERFIL_PERMISSAO_ASSOCIACAO_INVALIDO,

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

        TRANSACAO_ID_INVALIDO,
        TRANSACAO_DESCRICAO_É_OBRIGATORIA,
        TRANSACAO_VALOR_INVALIDO,

        CATEGORIA_ID_INVALIDO,
        CATEGORIA_NOME_É_OBRIGATORIO,

        FORMA_PAGAMENTO_ID_INVALIDO,
        FORMA_PAGAMENTO_NOME_É_OBRIGATORIO,

        CONTA_ID_INVALIDO,
        CONTA_NOME_É_OBRIGATORIO,

        ANO_ID_INVALIDO,
        ANO_NUMERO_INVALIDO,

        MES_ID_INVALIDO,
        MES_NUMERO_INVALIDO,

        TIPO_TRANSACAO_ID_INVALIDO,
        TIPO_TRANSACAO_NOME_É_OBRIGATORIO,

        TRANSACAO_RECORRENTE_ID_INVALIDO,
        TRANSACAO_RECORRENTE_FREQUENCIA_INVALIDA,

        CONTA_ANO_MES_SALDO_ID_INVALIDO
    }

    public static class ETiposErroExtensions
    {
        public static string ToString(ETiposErro erro)
        {
            return erro switch
            {
                ETiposErro.TENANT_ID_INVALIDO => "TenantId inválido",
                ETiposErro.TENANT_NOME_É_OBRIGATORIO => "Obrigatório informar nome do tenant",

                ETiposErro.PERMISSAO_ID_INVALIDO => "PermissãoId inválido",
                ETiposErro.PERMISSAO_NÃO_ENCONTRADO => "Permissão não encontrado",
                ETiposErro.PERMISSAO_SIGLA_É_OBRIGATORIO => "Obrigatório informar sigla da permissão",
                ETiposErro.PERMISSAO_DESCRICAO_É_OBRIGATORIO => "Obrigatório informar descriçãa da permissão",

                ETiposErro.PERFIL_PERMISSAO_ID_INVALIDO => "PerfilPermissaoId inválido",
                ETiposErro.PERFIL_PERMISSAO_ASSOCIACAO_INVALIDO => "Permmissão já associada ao perfil informado",

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

                ETiposErro.TRANSACAO_ID_INVALIDO => "TransaçãoId inválido",
                ETiposErro.TRANSACAO_DESCRICAO_É_OBRIGATORIA => "Obrigatório informar descrição da transação",
                ETiposErro.TRANSACAO_VALOR_INVALIDO => "Valor da transação inválido",

                ETiposErro.CATEGORIA_ID_INVALIDO => "CategoriaId inválido",
                ETiposErro.CATEGORIA_NOME_É_OBRIGATORIO => "Obrigatório informar nome da categoria",

                ETiposErro.FORMA_PAGAMENTO_ID_INVALIDO => "FormaPagamentoId inválido",
                ETiposErro.FORMA_PAGAMENTO_NOME_É_OBRIGATORIO => "Obrigatório informar nome da forma de pagamento",

                ETiposErro.CONTA_ID_INVALIDO => "ContaId inválido",
                ETiposErro.CONTA_NOME_É_OBRIGATORIO => "Obrigatório informar nome da conta",

                ETiposErro.ANO_ID_INVALIDO => "AnoId inválido",
                ETiposErro.ANO_NUMERO_INVALIDO => "Número do ano inválido",

                ETiposErro.MES_ID_INVALIDO => "MesId inválido",
                ETiposErro.MES_NUMERO_INVALIDO => "Número do mês inválido",

                ETiposErro.TIPO_TRANSACAO_ID_INVALIDO => "TipoTransacaoId inválido",
                ETiposErro.TIPO_TRANSACAO_NOME_É_OBRIGATORIO => "Obrigatório informar nome do tipo de transação",

                ETiposErro.TRANSACAO_RECORRENTE_ID_INVALIDO => "TransacaoRecorrenteId inválido",
                ETiposErro.TRANSACAO_RECORRENTE_FREQUENCIA_INVALIDA => "Frequência da transação recorrente inválida",

                ETiposErro.CONTA_ANO_MES_SALDO_ID_INVALIDO => "ContaAnoMesSaldoId inválido",

                _ => erro.ToString()
            };
        }
    }
}
