using Fiap.Api.MVPSaude.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.MVPSaude.Repository.Context
{
    public class ProntuarioRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public ProntuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<ProntuarioModel> Listar()
        {
            

            // Efetuando a listagem (Substituindo o Select *)
            var lista = dataBaseContext.Prontuario
                .Include(p => p.Paciente )
                .Include(p => p.Medico)
                .ToList<ProntuarioModel>();


            return lista;

                        
        }

        public ProntuarioModel Consultar(int id)
        {
            // Recuperando o objeto Prontuário de um determinado Id
            var prontuario = dataBaseContext.Prontuario.Find(id);

            return prontuario;
        }

        public void Inserir(ProntuarioModel prontuario)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Prontuario.Add(prontuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(ProntuarioModel prontuario)
        {
            dataBaseContext.Prontuario.Update(prontuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(ProntuarioModel prontuario)
        {
            

            dataBaseContext.Prontuario.Remove(prontuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}