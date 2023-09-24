using Fiap.Api.MVPSaude.Model;
using Fiap.Api.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.MVPSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        
        private PacienteRepository pacienteRepository;

        public PacienteController(DataBaseContext dataBaseContext)
        {

            pacienteRepository = new PacienteRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<PacienteModel>> Get()
        {
            try
            {
                var lista = pacienteRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<PacienteModel> Get([FromRoute] int id)
        {
            try
            {
                var pacienteModel = pacienteRepository.Consultar(id);

                if ( pacienteModel != null  )
                {
                    return Ok(pacienteModel);
                } else
                {
                    return NotFound();
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<PacienteModel> Post([FromBody] PacienteModel pacienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try {
                pacienteRepository.Inserir(pacienteModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + pacienteModel.PacienteId);
                return Created(location, pacienteModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Médico. Detalhes: {error.Message}" });
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<PacienteModel> Put([FromRoute] int id, [FromBody] PacienteModel pacienteModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pacienteModel.PacienteId != id)
            {
                return NotFound();
            }

            try
            {
                pacienteRepository.Alterar(pacienteModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Paciente. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<PacienteModel> Delete([FromRoute] int id)
        {
            try { 
                var pacienteModel = pacienteRepository.Consultar(id);

                if (pacienteModel != null)
                {
                    pacienteRepository.Excluir(pacienteModel);
                    return NoContent(); 
                } else
                {
                    return NotFound();
                }
            } catch (Exception e)
            {
                return BadRequest();
            }
        }


    }
}