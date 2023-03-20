using Drilling.Models;
using Drilling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drilling.Controllers
{
    [ApiController]
    [Route("holes")]
    public class HoleController : ControllerBase
    {
        private readonly IHoleService _holeService;

        public HoleController(IHoleService holeService)
        {
            _holeService = holeService;
        }


        /// <summary>
        /// добавление скважины
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(HoleForm model)
        {
            var result = await _holeService.AddAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// редактирование скважины
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditAsync([FromQuery] Guid id, HoleForm model)
        {
            var result = await _holeService.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// получение скважины по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _holeService.GetByIdAcync(id);
            return Ok(result);
        }

        /// <summary>
        /// получение всех скважин
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _holeService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// удаление скважины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _holeService.DeleteAsync(id);
            return Ok();
        }
    }
}
