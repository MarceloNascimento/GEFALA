 
//  @ Project :GEFALA Untitled
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
    public class AdministradorDoSistemaRepository : IRepository<AdministradorDoSistema>
    {
        private static AdministradorDoSistemaRepository instance;
        private static ISessionFactory AdministradorDoSistemaDaoSession { get; set; }

        protected AdministradorDoSistemaRepository()
        {
            var configuration = new Configuration();
            configuration.Configure()
            .AddAssembly(typeof(AdministradorDoSistema).Assembly);
            AdministradorDoSistemaDaoSession = configuration.BuildSessionFactory();
        }

        public static AdministradorDoSistemaRepository getInstance()
        {
            if (instance == null)
            {
                instance = new AdministradorDoSistemaRepository();
                return instance;
            }
            else
            {
                AdministradorDoSistemaRepository aux = instance;
                return aux;
            }
        }

        public void Add(AdministradorDoSistema administradorDoSistemaDao)
        {
            using (ISession session = AdministradorDoSistemaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(administradorDoSistemaDao);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Update(AdministradorDoSistema administradorDoSistemaDao)
        {
            using (ISession session = AdministradorDoSistemaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(administradorDoSistemaDao);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public void Remove(AdministradorDoSistema administradorDoSistemaDao)
        {
            using (ISession session = AdministradorDoSistemaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(administradorDoSistemaDao);
                transaction.Commit();
                session.Close();
                session.Dispose();
            }
        }

        public AdministradorDoSistema GetById(Double administradorDoSistemaId)
        {
            using (ISession session = AdministradorDoSistemaDaoSession.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                AdministradorDoSistema administradorDoSistema = session.Get<AdministradorDoSistema>(administradorDoSistemaId);
                transaction.Commit();
                session.Close();
                session.Dispose();
                return administradorDoSistema;
            }
        }



        public IList<AdministradorDoSistema> ListAll()
        {
            try
            {
                List<AdministradorDoSistema> Lista = new List<AdministradorDoSistema>();
                using (ISession session = AdministradorDoSistemaDaoSession.OpenSession())
                {
                    IQuery query = session.CreateQuery("select p from AdministradorDoSistema p");
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