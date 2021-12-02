using System;
using System.ComponentModel.DataAnnotations;
using MathWorks.MATLAB.NET.Arrays;

namespace WebApi.Models.MatLab
{
    public class MatLabResponse
    {
        [Required]
        public string result { get; set; }
        [Required]
        public Array resultArray { get; set; }
        [Required]
        public MWArray mWArray { get; set; }
    }
}

