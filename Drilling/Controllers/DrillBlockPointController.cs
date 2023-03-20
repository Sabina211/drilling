using Drilling.Models;
using Drilling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drilling.Controllers
{
    [ApiController]
    [Route("drillBlockPoints")]
    public class DrillBlockPointController : ControllerBase
    {
        private readonly IDrillBlockPointService _drillBlockPointService;

        public DrillBlockPointController(IDrillBlockPointService drillBlockPointService)
        {
            _drillBlockPointService = drillBlockPointService;
        }


        /// <summary>
        /// добавление точки блока
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(DrillBlockPointForm model)
        {
            var result = await _drillBlockPointService.AddAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// редактирование точки блока
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditAsync([FromQuery] Guid id, DrillBlockPointForm model)
        {
            var result = await _drillBlockPointService.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// получение точки блока по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _drillBlockPointService.GetByIdAcync(id);
            return Ok(result);
        }

        /// <summary>
        /// получение всех точек блока
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _drillBlockPointService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// удаление точки блока
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _drillBlockPointService.DeleteAsync(id);
            return Ok();
        }
    }
}
