using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private Data.Providers.Image _imageProvider;
        
        public ImageController(Data.Contexts.DatabaseContext db)
        {
            _imageProvider = new Data.Providers.Image(db);
        }

        [HttpGet]
        public Data.Models.Image[] Get()
        {
            return _imageProvider.Get().ToArray();
        }

        [HttpGet]
        public Data.Models.Image? GetFirst(int id)
        {
            return _imageProvider.GetFirstById(id);
        }

        [HttpGet]
        public Data.Models.Image Insert(string sourceImage, int advertisement)
        {
            Data.Models.Image newImage = new Data.Models.Image()
            {
                SourceImage = sourceImage,
                AdvertisementId = advertisement,
            };

            return _imageProvider.Insert(newImage);
        }

        [HttpGet]
        public Data.Models.Image? Update(int id, string sourceImage)        //nao necessita
        {
            Data.Models.Image newImage = new Data.Models.Image()
            {
                Id= id,
                SourceImage = sourceImage,

            };

            return _imageProvider.Update(newImage); 
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _imageProvider.Delete(id);
        }
    }
}
