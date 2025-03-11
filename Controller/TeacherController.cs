﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controller;


[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly M3ManagmentContext _context;

    public TeacherController(M3ManagmentContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
    {
        return await _context.Teacher.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int Id)
    {
        var teacher = await _context.Teacher.FindAsync();

        if (teacher == null)
        {
            return NotFound("Unable to find teacher with the given ID");
        }

        return teacher;
    }
}
