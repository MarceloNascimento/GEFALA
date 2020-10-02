//  @ Project :GEFALA Untitled
//  @ Date : 20/03/2013 20/03/2013
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
    public class MensagemRepository : IRepository<Mensagem>
    {
        private static MensagemRepository instance;
        private static ISessionFactory MensagemDaoSession { get; set; }

        /*O metodo construtor da classe é mantido como privado por
         * estarmos utilizando o padrão de projeto singleton
         */

        private MensagemRepository()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(Mensagem).Assembly);
            MensagemDaoSession = configuration.BuildSessionFactory();
        }

        /*O metodo construtor da classe é mantido como privado por
         * estarmos utilizando o padrão de projeto singleton
         * este metodo é um metodo static para chamar uma instancia unica da classe
         */

        public static MensagemRepository getInstance()
        {
            if (instance == null)
            {
                instance = new MensagemRepository();
                return instance;
            }
            else
            {
                MensagemRepository aux = instance;
                return aux;
            }
        }

        public void Add(Mensagem mensagem)
        {
            using (ISession session = MensagemDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(mensagem);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Update(Mensagem menssagem)
        {
            using (ISession session = MensagemDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(menssagem);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(Mensagem menssagem)
        {
            using (ISession session = MensagemDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(menssagem);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public Mensagem GetById(int Id)
        {
            using (ISession session = MensagemDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                Mensagem menssagem = session.Get<Mensagem>(Id);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return menssagem;
            }
        }

        public IList<Mensagem> ListAll()
        {
            try
            {
                List<Mensagem> Lista = new List<Mensagem>();
                using (ISession session = MensagemDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select m from Mensagem m where m.Estatus = false");
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

        public List<Mensagem> ListParaMural()
        {
            try
            {
                List<Mensagem> Lista = new List<Mensagem>();
                using (ISession session = MensagemDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select m from Mensagem m where m.Respondida = true");
                    query.List(Lista);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Mensagem> ListarTodasPermitidas()
        {
            try
            {
                List<Mensagem> Lista = new List<Mensagem>();
                using (ISession session = MensagemDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select p from Mensagem p");
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