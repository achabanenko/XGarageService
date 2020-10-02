using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XGarageService.Models;
//using XGarageService.Web.Services.Notification;

namespace XGarageService.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository ItemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Item>> List()
        {
            /*new NetCorePushNotification.FBC.FBCNotification("AAAAV98ECnU:APA91bFLjPmACxqix1tQk9ufHqet7N8ljIxH1rueDpi7yaoYbztXKr6WnbykzXoqo8-Rlft6UDtLkpZcsI4v_iY_rMLKO7VxHA0OCaS-6iC4DTILj2m0x-_73TG4T20m3YJ816veZHzK")
                .Send("cqBaM-woa4s:APA91bG8HMo5-hQ0ok6fwuQFw3fQuXw49gEG7WjiSy7lJNmG31upD5pAHBeSrwtW1ugz_6BKYc7hyueuyZO1O1vXuCLBYzT39NGQqypeoyFD47wEdeT-d5Rc9qoIl4R2hegBpg5y71uQ",
                "Title", "HeaderBody", DateTime.Now.ToString());
            */
            /*
            NetCorePushNotification.FBC.Model.TestObject obj = new NetCorePushNotification.FBC.Model.TestObject()
            {
                Id = "11",
                Name = "222"
            };
            var s = JsonConvert.SerializeObject(obj);

            new NetCorePushNotification.FBC.FBCNotification("AAAAV98ECnU:APA91bFLjPmACxqix1tQk9ufHqet7N8ljIxH1rueDpi7yaoYbztXKr6WnbykzXoqo8-Rlft6UDtLkpZcsI4v_iY_rMLKO7VxHA0OCaS-6iC4DTILj2m0x-_73TG4T20m3YJ816veZHzK")
                .Send("cqBaM-woa4s:APA91bG8HMo5-hQ0ok6fwuQFw3fQuXw49gEG7WjiSy7lJNmG31upD5pAHBeSrwtW1ugz_6BKYc7hyueuyZO1O1vXuCLBYzT39NGQqypeoyFD47wEdeT-d5Rc9qoIl4R2hegBpg5y71uQ",
                "Title", "HeaderBody", s);
            */


            /*
            NetCorePushNotification.APNS.APNSNotification apsn = new NetCorePushNotification.APNS.APNSNotification();
            apsn.Send("6EF17CA0959B4CBB8A372B5837CB58E810D10208937295ADDB9AB225A4781D69", "Certificates.p12", "Password1", "Title","Subtitle", "Message","data");
            */
            return ItemRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Item> GetItem(string id)
        {
            Item item = ItemRepository.Get(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Item> Create([FromBody] Item item)
        {
            ItemRepository.Add(item);
            return CreatedAtAction(nameof(GetItem), new { item.Id }, item);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Item item)
        {
            try
            {
                ItemRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while editing item");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            Item item = ItemRepository.Remove(id);

            if (item == null)
                return NotFound();

            return Ok();
        }
    }
}
