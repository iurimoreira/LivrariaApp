﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Livraria.App.Api.Models;
using LivrariaApp.Domain;
using System.Collections;
using System.Collections.ObjectModel;

namespace Livraria.App.Api.Controllers
{
    public class LivrosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public LivrosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Livros
        public IQueryable<Livro> GetLivros()
        {
            return db.Livros.AsQueryable();
        }

        // GET: api/Livros/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult GetLivro(int id)
        {
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/Livros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Livros
        [ResponseType(typeof(Livro))]
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Livro livroTemp = new Livro(livro.Isbn, livro.Titulo, livro.Ano);

                livroTemp.Autores = new Collection<Autor>();

                for (int i = 0; i < livro.Autores.Count; i++)
                {
                    livroTemp.Autores.Add(db.Autores.Find(livro.Autores.ElementAt<Autor>(i).AutorId));
                }

                db.Livros.Add(livroTemp);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = livro.LivroId }, livro);
            }
        }

        // DELETE: api/Livros/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult DeleteLivro(int id)
        {
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            db.SaveChanges();

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(int id)
        {
            return db.Livros.Count(e => e.LivroId == id) > 0;
        }
    }
}