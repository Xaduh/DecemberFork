namespace December.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //private readonly DatabaseContext _context;
        IPersonService context;
        public PeopleController(IPersonService c)
        {
            context = c;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTOResponse>>> GetPersons()
        {
            return Ok(await context.GetAll());
        }

        // Controller --> Service --> Repository --> Service --> Controller









        //// GET: api/People/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Person>> GetPerson(int id)
        //{
        //    var person = await _context.Persons.FindAsync(id);

        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return person;
        //}

        //// PUT: api/People/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPerson(int id, Person person)
        //{
        //    if (id != person.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(person).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PersonExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/People
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Person>> PostPerson(Person person)
        //{
        //    _context.Persons.Add(person);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        //}

        //// DELETE: api/People/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePerson(int id)
        //{
        //    var person = await _context.Persons.FindAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Persons.Remove(person);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PersonExists(int id)
        //{
        //    return _context.Persons.Any(e => e.Id == id);
        //}
    }
}
