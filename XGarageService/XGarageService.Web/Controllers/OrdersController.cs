using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XGarageService.Web.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Test()
        {
            return "Test";
        }
        

        [HttpGet("TestOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Models.ServiceOrder> TestOrder()
        {
            return new ActionResult<Models.ServiceOrder>(new Models.ServiceOrder()
            {
                RegNumber="1111",
                Id="1111",
                IsRepair=true,
                SelectedDate=DateTime.Now,
                Remarks="test"
            });
        }

        //[HttpPost]
        //[Route("product/add")]

        //[HttpPost("Submit")]
        [HttpPost]
        [Route("api/orderservice/add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Models.ServiceOrder> Submit([FromBody] Models.ServiceOrder order)
        {
            order.Id = DateTime.Now.ToString();
            return new ActionResult<Models.ServiceOrder>(order);
        }


    }
}
