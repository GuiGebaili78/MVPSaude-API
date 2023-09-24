using Fiap.Api.MVPSaude.Model;
using Fiap.Api.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.MVPSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : Controller
    {
        
        private MedicoRepository medicoRepository;

        public MedicoController(DataBaseContext dataBaseContext)
        {

            medicoRepository = new MedicoRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<MedicoModel>> Get()
        {
            try
            {
                var lista = medicoRepository.Listar();

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
        public ActionResult<MedicoModel> Get([FromRoute] int id)
        {
            try
            {
                var medicoModel = medicoRepository.Consultar(id);

                if ( medicoModel != null  )
                {
                    return Ok(medicoModel);
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
        public ActionResult<MedicoModel> Post([FromBody] MedicoModel medicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try {
                medicoRepository.Inserir(medicoModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + medicoModel.MedicoId);
                return Created(location, medicoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Médico. Detalhes: {error.Message}" });
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<MedicoModel> Put([FromRoute] int id, [FromBody] MedicoModel medicoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (medicoModel.MedicoId != id)
            {
                return NotFound();
            }

            try
            {
                medicoRepository.Alterar(medicoModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Medico. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<MedicoModel> Delete([FromRoute] int id)
        {
            try { 
                var medicoModel = medicoRepository.Consultar(id);

                if (medicoModel != null)
                {
                    medicoRepository.Excluir(medicoModel);
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