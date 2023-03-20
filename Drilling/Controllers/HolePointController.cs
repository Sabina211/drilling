using Drilling.Models;
using Drilling.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drilling.Controllers
{
    [ApiController]
    [Route("holePoints")]
    public class HolePointController : ControllerBase
    {
        private readonly IHolePointService _holePointService;

        public HolePointController(IHolePointService holePointService)
        {
            _holePointService = holePointService;
        }


        /// <summary>
        /// добавление точки скважины
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync(HolePointForm model)
        {
            var result = await _holePointService.AddAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// редактирование точки скважины
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditAsync([FromQuery] Guid id, HolePointForm model)
        {
            var result = await _holePointService.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// получение точки скважины по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _holePointService.GetByIdAcync(id);
            return Ok(result);
        }

        /// <summary>
        /// получение всех точек скважин
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _holePointService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// удаление точки скважины
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _holePointService.DeleteAsync(id);
            return Ok();
        }
    }
}
