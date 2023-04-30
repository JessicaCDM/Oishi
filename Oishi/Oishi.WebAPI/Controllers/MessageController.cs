using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private Data.Providers.Message _messageProvider;
        
        public MessageController(Data.Contexts.DatabaseContext db)
        {
            _messageProvider = new Data.Providers.Message(db);
        }

        [HttpGet]
        public Data.Models.Message[] Get()
        {
            return _messageProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Message? GetFirst(int id)
        {
            return _messageProvider.GetFirst(id);
        }

        [HttpGet]
        public Data.Models.Message Insert(int senderUserAccountId, int receiverUserAccountId, int advertisementId, string text)
        {
            Data.Models.Message newMessage = new Data.Models.Message()
            {
                SenderUserAccountId = senderUserAccountId,
                ReceiverUserAccountId = receiverUserAccountId,
                AdvertisementId= advertisementId,
                Text = text
            };

            return _messageProvider.Insert(newMessage);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _messageProvider.Delete(id);
        }
    }
}
