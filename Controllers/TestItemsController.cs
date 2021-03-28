﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Context;
using TestApi.Data.Abstractions;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ITestItemRepository _testItemRepository;
        public TestItemsController(DatabaseContext context, ITestItemRepository testItemRepository)
        {
            _context = context;
            _testItemRepository = testItemRepository;
        }

        // GET: api/TestItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestItem>>> GetTestItems()
        {
            return await _testItemRepository.GetAll();
        }

        // GET: api/TestItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestItem>> GetTestItem(long id)
        {
            try
            {
                var testItem = await _context.TestItems.FirstOrDefaultAsync();

                if (testItem == null)
                {
                    return NotFound();
                }

                return testItem;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return NotFound();
            }
        }

        // PUT: api/TestItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestItem(long id, TestItem testItem)
        {
            if (id != testItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(testItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestItem>> PostTestItem(TestItem testItem)
        {
            _context.TestItems.Add(testItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestItem", new { id = testItem.Id }, testItem);
        }

        // DELETE: api/TestItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestItem(long id)
        {
            var testItem = await _context.TestItems.FindAsync(id);
            if (testItem == null)
            {
                return NotFound();
            }

            _context.TestItems.Remove(testItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestItemExists(long id)
        {
            return _context.TestItems.Any(e => e.Id == id);
        }
    }
}
