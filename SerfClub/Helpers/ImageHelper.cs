using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Helpers
{
    public class ImageHelper
    {
        public async Task<Guid?> UploadImage(IFormFile imageData)
        {
            Guid? result = null;
            if (imageData != null)
            {
                result = Guid.NewGuid();
                var fileName = $"{result}.jpg";

                var filePath = Path.Combine("wwwroot/img/uploads", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await imageData.CopyToAsync(fileSteam);
                }
            }
            return result;
        }

        public static string GetUrl(Guid? guid)
        {
            if (!guid.HasValue)
            {
                return null;
            }
            return GetUrl(guid.Value);
        }

        public static string GetUrl(string photo)
        {
            if (string.IsNullOrEmpty(photo))
            {
                return null;
            }
            var result = Guid.TryParse(photo, out var guid);
            if (!result)
            {
                return null;
            }
            return GetUrl(guid);
        }

        private static string GetUrl(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                return null;
            }
            return string.Format("~/img/uploads/{0}.jpg", guid);
        }
    }
}
