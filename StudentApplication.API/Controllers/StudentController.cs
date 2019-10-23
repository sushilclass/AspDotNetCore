﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.API.Models;
using StudentApplication.API.Models.DataManager;
using StudentApplication.API.Models.Repository;

namespace StudentApplication.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private IDataRepository<Student, long> _iRepo;
        public StudentController(IDataRepository<Student, long> repo)
        {
            _iRepo = repo;
        }

        //GET:api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _iRepo.GetAll();
        }

        //GET:api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _iRepo.Get(id);
        }

        //POST:api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _iRepo.Add(student);
        }

        //PUT:api/values
        [HttpPut]
        public void Put([FromBody]Student student)
        {
            _iRepo.Update(student.StudentId, student);
        }

        //DELETE:api/values
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
        
    }
}