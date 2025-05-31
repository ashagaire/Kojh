using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace backend.Features.Company.Request
{
    public class GetCompanyByIdRequest
    {
        [Required, FromRoute(Name = "id")] public Guid Id { get; set; }
    }
}
