//  @ Project : GEFALA
//  @ Date : 20/03/2013
//  @ Author : Marcelo do Nascimento Rocha

using GEFALA.Models;
using Models.Interfaces;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GEFALA.Repository
{
    public class RespostaRepository : IRepository<Resposta>
    {      

        private static RespostaRepository instance;
        private static ISessionFactory RespostaDaoSession { get; set; }

        private RespostaRepository()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(Resposta).Assembly);
            RespostaDaoSession = configuration.BuildSessionFactory();
        }

        public static RespostaRepository getInstance()
        {
            if (instance == null)
            {
                instance = new RespostaRepository();
                return instance;
            }
            else
            {
                RespostaRepository aux = instance;
                return aux;
            }
        }

      

       

        public void Add(Resposta resposta)
        {
            using (ISession session = RespostaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(resposta);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Update(Resposta resposta)
        {
            using (ISession session = RespostaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(resposta);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Resposta funcionario)
        {
            using (ISession session = RespostaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(funcionario);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public IList<Resposta> ListAll()
        {
            try
            {
                List<Resposta> Lista = new List<Resposta>();

                using (ISession session = RespostaDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select p from Resposta p");
                    query.List(Lista);
                }
                Lista = Lista.OrderByDescending(q => q.Data).ToList();
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Resposta> ListParaMural(String user)
        {
            try
            {
                List<Resposta> Lista = new List<Resposta>();
                using (ISession session = RespostaDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select r from Resposta r where r.Mensagem.User =?").SetParameter(0, user);
                    query.List(Lista);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}