using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Context;
using TodoWebApi.Migrations;
using TodoWebApi.Models;

namespace TodoWebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TodosController : ControllerBase
{
    TodoApiContextDb context = new();
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = context.Todos.ToList();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult ChangeCompleted(int id)
    {
        context.Todos.Where(p=> p.Id == id).FirstOrDefault().IsCompleted = 
            !context.Todos.Where(p=> p.Id == id).FirstOrDefault().IsCompleted;
        context.SaveChanges();

        var result = context.Todos.ToList();
        return Ok(result);
    }
}

