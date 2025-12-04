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

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTOResponse>> GetPerson(int id)
        {
            var person = await context.GetById(id);

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonDTOResponse>> CreatePerson(PersonDTORequest person)
        {
            PersonDTOResponse result = await context.Create(person);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

            //return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonDTORequest person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            PersonDTOResponse result = await context.Update(person);
            if (result == null) return NotFound();
            return Ok(result);
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

        
    }
}
