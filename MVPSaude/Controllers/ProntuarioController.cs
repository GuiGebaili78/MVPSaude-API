using Fiap.Api.MVPSaude.Model;
using Fiap.Api.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.MVPSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : Controller
    {
        
        private ProntuarioRepository prontuarioRepository;

        public ProntuarioController(DataBaseContext dataBaseContext)
        {

            prontuarioRepository = new ProntuarioRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<ProntuarioModel>> Get()
        {
            try
            {
                var lista = prontuarioRepository.Listar();

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
        public ActionResult<ProntuarioModel> Get([FromRoute] int id)
        {
            try
            {
                var prontuarioModel = prontuarioRepository.Consultar(id);

                if ( prontuarioModel != null  )
                {
                    return Ok(prontuarioModel);
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
        public ActionResult<ProntuarioModel> Post([FromBody] ProntuarioModel prontuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try {
                prontuarioRepository.Inserir(prontuarioModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + prontuarioModel.ProntuarioId);
                return Created(location, prontuarioModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Médico. Detalhes: {error.Message}" });
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<ProntuarioModel> Put([FromRoute] int id, [FromBody] ProntuarioModel prontuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (prontuarioModel.ProntuarioId != id)
            {
                return NotFound();
            }

            try
            {
                prontuarioRepository.Alterar(prontuarioModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Prontuario. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<ProntuarioModel> Delete([FromRoute] int id)
        {
            try { 
                var prontuarioModel = prontuarioRepository.Consultar(id);

                if (prontuarioModel != null)
                {
                    prontuarioRepository.Excluir(prontuarioModel);
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