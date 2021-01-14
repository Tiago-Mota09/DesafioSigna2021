using DeafioSigna2021.Domain.Models.Request;
using DeafioSigna2021.Domain.Models.Response;
using DeafioSigna2021.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Response = DeafioSigna2021.Domain.Models.Response.Response;

namespace DeafioSigna2021.Controllers
{
    public class LikedRepositoryController : ControllerBase
    {
        private readonly LikedRepositoryBL _likedRepositoryBL;
        public LikedRepositoryController(LikedRepositoryBL likedRepositoryBL)
        {
            _likedRepositoryBL = likedRepositoryBL;
        }

        /// <summary>
        /// Cadastrar Repositórios
        /// </summary>
        /// <param name="LikedRepositoryReq">JSON</param>
        /// <returns>JSON</returns>
        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] LikedRepositoryRequest likedRepositoryReq)
        {
            var idLikedRepository = _likedRepositoryBL.Insert(likedRepositoryReq);

            return CreatedAtAction(nameof(GetById), new { id = idLikedRepository }, likedRepositoryReq);
        }

        /// <summary>
        /// Atualizar LikedRepository
        /// </summary>
        /// <param name="LikedRepositoryRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] LikedRepositoryUpdateRequest likedRepositoryUpdateRequest)
        {
            var linhasAfetadas = _likedRepositoryBL.Update(likedRepositoryUpdateRequest);

            if (linhasAfetadas == 1)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new { message = "Erro ao atualizar o cadastro, contate o administrador" });
            }
        }

        /// <summary>
        /// Buscar Repository por like
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(LikedRepositoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var likedRepositoryResponse = _likedRepositoryBL.GetLikedRepositoryById(id);

            if (likedRepositoryResponse != null)
            {
                return Ok(likedRepositoryResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum registro foi encontrado." });
            }
        }

        /// <summary>
        /// Busca todos os registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(typeof(IEnumerable<LikedRepositoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var likedRepositoryResponse = _likedRepositoryBL.GetAllLikedRepository();

            if (likedRepositoryResponse.Any())
            {
                return Ok(likedRepositoryResponse);
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum registro foi encontrado." });
            }
        }

        /// <summary>
        /// Deleta os Registros por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var linhasAfetadas = _likedRepositoryBL.Delete(id);

            if (linhasAfetadas == 1)
            {
                return Ok(new Response { Message = "Registro excluido com sucesso" });
            }
            else
            {
                return NotFound(new Response { Message = "Nenhum Registro foi encontrado." });
            }
        }
    }
}
