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
    [Route("api/Activities")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class ActivitiesController : Controller
    {
        private readonly ILogger<ActivitiesController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public ActivitiesController(ILogger<ActivitiesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<List<ActivitiesDTO>>> Get()
        {
            var entidades = await context.Activities.ToListAsync();
            return mapper.Map<List<ActivitiesDTO>>(entidades);

        }
        // Búsqueda por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActivitiesDTO>> Get(int id)
        {

            var activity = await context.Activities.FirstOrDefaultAsync(x => x.ActivitiesId == id);


            if (activity == null)
            {


                return NotFound("No existe el time.");
            }


            return mapper.Map<ActivitiesDTO>(activity);

        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] ActivitiesCreacionDTO ActivitiesCreacionDTO)
        {


            var activity = mapper.Map<Activities>(ActivitiesCreacionDTO);
            context.Add(activity);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(Activities Activities, int id)
        {



            var existe = await context.Activities.AnyAsync(x => x.ActivitiesId == id);

            if (!existe)
            {
                return NotFound("Activity no existe");
            }

            context.Update(Activities);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {


            var activity = await context.Activities.FirstOrDefaultAsync(x => x.ActivitiesId == id);

            if (activity == null)
            {

                return NotFound("Activity no existe");
            }

            context.Remove(activity);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }
    }
}
