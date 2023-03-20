using Drilling.Models;
using Drilling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drilling.Controllers
{
    [ApiController]
    [Route("drillBlocks")]
    public class DrillBlocksController : ControllerBase
    {
        private readonly IDrillBlockService _drillBlockService;

        public DrillBlocksController(IDrillBlockService drillBlockService)
        {
            _drillBlockService = drillBlockService;
        }

        /// <summary>
        /// добавление блока обуривания
        /// </summary>
        /// <param name="blockName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(DrillBlockForm model)
        {
            var result = await _drillBlockService.AddAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// редактирование блока
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditAsync([FromQuery]Guid id, DrillBlockForm model)
        {
            var result = await _drillBlockService.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// получение блока по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _drillBlockService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// получение всех блоков обуривания
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _drillBlockService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// удаление блока
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _drillBlockService.DeleteAsync(id);
            return Ok();
        }
    }
}
