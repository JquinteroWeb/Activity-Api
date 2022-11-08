using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiculosAPI.Data;
using VehiculosAPI.DTOs;
using VehiculosAPI.Entidades;

namespace VehiculosAPI.Controllers
{
    [ApiController]
    [Route("api/Times")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class TimesController : Controller
    {
        private readonly ILogger<TimesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public TimesController(ILogger<TimesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<List<TimesDTO>>> Get()
        {
            var entidades = await context.Times.ToListAsync();
            return mapper.Map<List<TimesDTO>>(entidades);

        }
        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimesDTO>> Get(int id)
        {

            var times = await context.Times.FirstOrDefaultAsync(x => x.TimesId == id);


            if (times == null)
            {


                return NotFound("No existe el time.");
            }


            return mapper.Map<TimesDTO>(times);

        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] TimesCreacionDTO TimesCreacionDTO)
        {


            var time = mapper.Map<Times>(TimesCreacionDTO);
            context.Add(time);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Times Times, int id)
        {



            var existe = await context.Times.AnyAsync(x => x.TimesId == id);

            if (!existe)
            {
                return NotFound("El times no existe");
            }

            context.Update(Times);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var Time = await context.Times.FirstOrDefaultAsync(x => x.TimesId == id);

            if (Time == null)
            {

                return NotFound("El time no existe");
            }

            context.Remove(Time);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
