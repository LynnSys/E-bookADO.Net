﻿using EBook.Interface;
using EBook.Model;
using EBook.Service;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _authorRepository;

        public AuthorController(IAuthor authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [Route("/GetAllAuthors")]
        public ActionResult GetAllAuthors()
        {
            return Ok(_authorRepository.GetAllAuthors());
        }

        [HttpGet]
        [Route("/GetAuthorByID")]
        public ActionResult GetAuthorByID(int id)
        {
            return Ok(_authorRepository.GetById(id));
        }

        [HttpPost]
        [Route("/EnterNewAuthor")]
        public ActionResult AddAuthor(AuthorDto author)
        {
            if (author == null)
            {
                return BadRequest("Enter author details");
            }
            else
            {
                return Ok(_authorRepository.AddAuthor(author));
            }
        }

        //[HttpPatch]
        //[Route("/UpdateBook")]
        //public ActionResult UpdateBook(int id, UpdateAuthorDto book)
        //{
        //    return Ok(_authorRepository.UpdateAuthor(id, book));
        //}

        [HttpDelete]
        [Route("/DeleteAuthor")]
        public ActionResult DeleteAuthor(int id)
        {
            return Ok(_authorRepository.DeleteAuthor(id));
        }
    }
}
