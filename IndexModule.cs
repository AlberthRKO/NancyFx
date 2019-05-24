using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FinalUsuario.Modelo;
using Nancy;
using Nancy.ModelBinding;

namespace FinalUsuario
{
    public class IndexModule : NancyModule
    {
        
        public IndexModule() :base("/usuario")
        {
            var _contexto = new Contexto();
            _contexto.Database.CreateIfNotExists();
            Post["/"] = _ =>
            {
               var user = this.Bind<Usuario>();
               _contexto.Usuarios.Add(user);
               _contexto.SaveChanges();
               return HttpStatusCode.OK;
            };
            Get["/"] = x =>
            {
                var user = _contexto.Usuarios.ToList();
               return Response.AsJson(user);
            };

            Get["/{id:int}"] = parameters =>
            {
                int id = parameters.id;
                var user = _contexto.Usuarios.FirstOrDefault(x => x.Id == id);
                return Response.AsJson(user);
            };
            Put["/{id:int}"] = parameters =>
            {
                
                Usuario user = this.Bind<Usuario>();
                user.Id = parameters.id;
                
                _contexto.Entry(user).State = EntityState.Modified;
                _contexto.SaveChanges();
                
                return HttpStatusCode.OK;
            };
            Delete["/{id:int}"] = parameters =>
            {
                Usuario user = this.Bind<Usuario>();
                user.Id = parameters.id;
                _contexto.Entry(user).State = EntityState.Deleted;
                _contexto.SaveChanges();
                
                return HttpStatusCode.OK;
            };
        }
    }
}