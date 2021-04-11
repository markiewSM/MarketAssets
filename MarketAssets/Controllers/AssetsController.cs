using MarketAssets.Data.Interfaces;
using MarketAssets.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAssets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private IAssetRepository assets;
       
        public AssetsController(IAssetRepository _asset)
        {
            this.assets = _asset;
           
        }
        [HttpGet]
        public ActionResult<IEnumerable<AssetsList>> GetAllAssets()
        {

            return assets.GetAllAssetLists().ToList(); //assets.GetAllAssets().ToList();
        }
        [HttpGet]
        [Route("value/{value}/property/{property}")]
        public ActionResult<IEnumerable<AssetsList>> GetAsset(bool value, string property)
        {
            var asset = assets.GetAssetsByProperyAndValue(property,value);

            if (asset == null)
            {
                return NotFound();
            }
            return asset;
        }
       
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Upload(IFormFile files)
        {
            if (files.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), files.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }

                var lst = assets.ImportValuesFromFile(path);

                if (lst == null)
                {
                    return Ok();
                }

            }
            return NotFound();
        }
            [HttpPut("{id}/{property}/{value}/{timeStamp}")]
        public ActionResult UpdateAsset(long id,string property,string value,string timeStamp)
        {
            assets.UpdateAsset(id, property, value, timeStamp);
            return Ok();
        }
    }
}
