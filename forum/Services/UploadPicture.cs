using System;
using Microsoft.AspNetCore.Http;

namespace forum.Models
{
    public class UploadPicture
    {
		public string UploadPicture(IFormFile Picture)
		{
			if (Picture == null)
			{
				return "http://placehold.it/500x500";
			}

			var uploadFolder = "uploads";
			var uploads = Path.Combine(_environment.WebRootPath, uploadFolder);

			using (var fileStream = new FileStream(Path.Combine(uploads, Picture.FileName), FileMode.Create))
			{
				Picture.CopyTo(fileStream);
			}

			return string.Concat(uploadFolder, "/", Picture.FileName);
		}
    }
}
