﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repository;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class NowController : Controller
    {
        private readonly ITestRepository _repository;

        public NowController(ITestRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public BaseResponse<string> Now()
        {
            var value = "Värde från apiet";
            return new BaseResponse<string>(value);
        }

        [HttpGet("add/{a}/{b}")]
        public BaseResponse<int> Add(int a, int b)
        {
            var value = a + b;
            return new BaseResponse<int>(value);
        }

        [HttpGet("dptest")]
        public BaseResponse<List<Test>> DbTest()
        {
            var list = _repository.GetAll();
            return new BaseResponse<List<Test>>(list);
        }
    }
}
