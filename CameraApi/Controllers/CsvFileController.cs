using CameraApi.Models;
using CameraApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CameraApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CsvFileController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Camera>> GetAll() =>
        CsvFileService.GetAll();
}