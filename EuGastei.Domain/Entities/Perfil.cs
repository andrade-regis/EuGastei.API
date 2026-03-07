using System;
using System.Collections.Generic;
using System.Text;

namespace EuGastei.Domain.Entities
{
    public class Perfil
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        //EF CORE
        public Tenant Tenant { get; private set; }

        private Perfil() { }

        public static Perfil Criar(Guid tenantId, string nome, string descricao)
        {
            return new Perfil()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Nome = nome,
                Descricao = descricao,
                Ativo = true
            };
        }

        public void AtualizarTenantId(Guid tenantId) 
            => this.TenantId = tenantId;

        public void AtualizarNome(string nome)
            => this.Nome = nome;

        public void AtualizarDescricao(string descricao)
            => this.Descricao = descricao;

        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;

    }
}
