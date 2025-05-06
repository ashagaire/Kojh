using System.ComponentModel.DataAnnotations;
using Kojh.DAL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Features.Company.Request
{
    public class GetAllCompanyRequest
    {
        [Required, FromBody] public CompanyListFilter Body { get; set; } = new();
    }
}
