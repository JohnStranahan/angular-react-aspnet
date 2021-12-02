using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.MatLab;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices; //Needed to Run DLL
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

using MyMatrixFunctions;
using TemperatureFunctions; //Restart visual studio when importing a new one

namespace WebApi.Services
{
    public interface IMatLabService
    {
        MatLabResponse RunMatLabScriptBasic();
        MatLabResponse RunMatLabScriptInputURL(double value);
        MatLabResponse RunMatLabScriptInputBody(MatLabRequest value);
    }

    public class MatLabService : IMatLabService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        Temperature temperature;
        MyFun testFun;

        public MatLabService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings
            )
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            temperature = new Temperature();
            testFun = new MyFun();
        }

        public MatLabResponse RunMatLabScriptBasic()
        {
            MatLabResponse matLabResponse = new MatLabResponse();
            try{
                MWArray result = testFun.myfun();
                matLabResponse.result = result.ToString();
                matLabResponse.resultArray = result.ToArray();
                matLabResponse.mWArray = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                matLabResponse.result = "error";
            }
            return matLabResponse;
        }

       public MatLabResponse RunMatLabScriptInputURL(double value)
        {
            MatLabResponse matLabResponse = new MatLabResponse();
            try{
                MWArray result = temperature.myinputfun(value);
                matLabResponse.result = result.ToString();
                matLabResponse.resultArray = result.ToArray();
                matLabResponse.mWArray = result;
                Console.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                matLabResponse.result = ex.ToString();
            }
           
            return matLabResponse;
        }

        public MatLabResponse RunMatLabScriptInputBody(MatLabRequest value)
        {
            MatLabResponse matLabResponse = new MatLabResponse();
            try{
                MWArray result = temperature.myinputfun(value.value);
                matLabResponse.result = result.ToString();
                matLabResponse.resultArray = result.ToArray();
                matLabResponse.mWArray = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                matLabResponse.result = "error";
            }
            return matLabResponse;
        }
    }
}
