using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid PerfilId { get; private set; }
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }

        //EF CORE
        public Tenant Tenant { get; private set; }
        public Perfil Perfil { get; private set; }


        private Usuario() { }
        public static Usuario Criar(Guid tenantId,
                                    Guid perfilId,
                                    string nome,
                                    string apelido,
                                    string email,
                                    string senha)
        {
            ValidarTenantId(tenantId);
            ValidarPerfilId(perfilId);
            ValidarNome(nome);
            ValidarApelido(apelido);
            ValidarEmail(email);
            ValidarSenha(senha);

            return new Usuario()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                PerfilId = perfilId,
                Nome = nome,
                Apelido = apelido,
                Email = email,
                Senha = senha
            };
        }
        public static Usuario Criar(Guid id,
                                    Guid tenantId,
                                    Guid perfilId,
                                    string nome,
                                    string apelido,
                                    string email,
                                    string senha)
        {
            ValidarId(id);
            ValidarTenantId(tenantId);
            ValidarPerfilId(perfilId);
            ValidarNome(nome);
            ValidarApelido(apelido);
            ValidarEmail(email);
            ValidarSenha(senha);

            return new Usuario()
            {
                Id = id,
                TenantId = tenantId,
                PerfilId = perfilId,
                Nome = nome,
                Apelido = apelido,
                Email = email,
                Senha = senha
            };
        }


        public void AtualizarTenantId(Guid tenantId)
        {
            ValidarTenantId(tenantId);

            this.TenantId = tenantId;
        }
        public void AtualizarPerfilId(Guid perfilId)
        {
            ValidarPerfilId(perfilId);

            this.TenantId = perfilId;
        }
        public void AtualizarNome(string nome)
        {
            ValidarNome(nome);

            this.Nome = nome;
        }
        public void AtualizarApelido(string apelido)
        {
            ValidarApelido(apelido);

            this.Apelido = apelido;
        }
        public void AtualizarEmail(string email)
        {
            ValidarEmail(email);

            this.Email = email;
        }
        public void AtualizarSenha(string senha)
        {
            ValidarSenha(senha);

            this.Senha = senha;
        }
        public void AtualizarAtivo(bool ativo)
        {
            this.Ativo = ativo;
        }


        private static void ValidarId(Guid id)
        {
            EntityValidator.ValidarId(id, ETiposErro.USUARIO_ID_INVALIDO);
        }
        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }
        private static void ValidarPerfilId(Guid perfilId)
        {
            EntityValidator.ValidarId(perfilId, ETiposErro.PERFIL_ID_INVALIDO);
        }
        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.USUARIO_NOME_É_OBRIGATORIO));
        }
        private static void ValidarApelido(string apelido)
        {
            if (string.IsNullOrEmpty(apelido))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.USUARIO_APELIDO_É_OBRIGATORIO));
        }
        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.USUARIO_EMAIL_É_OBRIGATORIO));
        }
        private static void ValidarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.USUARIO_SENHA_É_OBRIGATORIO));
        }
    }
}
