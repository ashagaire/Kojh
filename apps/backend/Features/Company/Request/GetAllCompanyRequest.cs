using Kojh.DAL.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace backend.Features.Company.Request
{
    public class GetAllCompanyRequest
    {
        [Required, FromBody] public CompanyListFilter Body { get; set; } = new();
    }
}
