 
//  @ Project : GEFALAUntitled
//  @ Date : 20/03/2013 20/03/2013
//  @ Author : Marcelo do Nascimento Rocha

using GEFALA.Models;
using Models.Interfaces;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;

namespace GEFALA.Repository
{
    public class RespondedorRepository : IRepository<Respondedor>
    {        
        private static RespondedorRepository instance;
        private static ISessionFactory RespondedorDaoSession { get; set; }

        private RespondedorRepository()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(Respondedor).Assembly);
            RespondedorRepository.RespondedorDaoSession = configuration.BuildSessionFactory();
        }

        public static RespondedorRepository getInstance()
        {
            if (instance == null)
            {
                instance = new RespondedorRepository();
                return instance;
            }
            else
            {
                RespondedorRepository aux = instance;
                return aux;
            }
        }

        public void Add(Respondedor respondedor)
        {
            using (ISession session = RespondedorDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(respondedor);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Update(Respondedor respondedor)
        {
            using (ISession session = RespondedorDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(respondedor);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Respondedor respondedor)
        {
            using (ISession session = RespondedorDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(respondedor);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public Respondedor GetById(Int32 respondedorId)
        {
            using (ISession session = RespondedorDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Respondedor respondedor = session.Get<Respondedor>(respondedorId);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return respondedor;
            }
        }

        public IList<Respondedor> ListAll()
        {
            try
            {
                List<Respondedor> Lista = new List<Respondedor>();
                using (ISession session = RespondedorDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select p from Respondedor p");
                    query.List(Lista);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Respondedor GetByAccount(string Nome, string Senha)
        {
            Respondedor respondedor = new Respondedor();
            // List<Account> Lista = new List<Account>();
            using (ISession session = RespondedorDaoSession.OpenSession())
            {
                String queryString = "select a from Respondedor a where a.Nome =? and a.Senha = ?";
                IQuery query = session.CreateQuery(queryString).SetString(0, Nome).SetString(1, Senha);
                respondedor = query.UniqueResult<Respondedor>();
                // query.List(Lista);
            }
            return respondedor;
        }
    }
}