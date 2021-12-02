using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Models.MatLab;
using WebApi.Services;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("matlab")]
    public class MatLabController : BaseController
    {
        private readonly IMatLabService _matLabService;
        private readonly IMapper _mapper;

        public MatLabController(
            IMatLabService matLabService,
            IMapper mapper)
        {
            _matLabService = matLabService;
            _mapper = mapper;
        }

        
        //This is a basic script with no input required
        [Authorize]
        [HttpPost("run-script")]
        public IActionResult RunMatLabScriptBasic()
        {
            MatLabResponse matLabResponse = _matLabService.RunMatLabScriptBasic();
            if (!(matLabResponse.result.Equals("error"))){
                return Ok(matLabResponse);
            }
            else
            {
                return BadRequest(matLabResponse);
            }
        }
        

        [Authorize]
        [HttpPost("run-script-url-input/{value:double}")]
        public IActionResult RunMatLabScriptInputURL(double value)
        {
            Console.WriteLine("RUN SCRIPT");
            MatLabResponse matLabResponse = _matLabService.RunMatLabScriptInputURL(value);
            if (!(matLabResponse.result.Equals("error"))){
                return Ok(matLabResponse);
            }
            else
            {
                return BadRequest(matLabResponse);
            }
        }

        [Authorize]
        [HttpPost("run-script-body-input")]
        public IActionResult RunMatLabScriptInputBody(MatLabRequest value)
        {
            MatLabResponse matLabResponse = _matLabService.RunMatLabScriptInputBody(value);
            if (!(matLabResponse.result.Equals("error"))){
                return Ok(matLabResponse);
            }
            else
            {
                return BadRequest(matLabResponse);
            }
        }

    }
}
