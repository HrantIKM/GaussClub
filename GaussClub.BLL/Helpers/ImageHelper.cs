using GaussClub.Models;
using GaussClub.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GaussClub.BLL.Helpers
{
    public static class ImageHelper
    {
        public static string? SaveImage(string wwwRootPath, string directory, IFormFile? file, string? imageUrl = null)
        {
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string articletPath = Path.Combine(wwwRootPath, directory);

                DeleteImage(wwwRootPath, imageUrl);

                using (var filestram = new FileStream(Path.Combine(articletPath, fileName), FileMode.Create))
                {
                    file.CopyTo(filestram);
                }

                return directory + fileName;
            }

            return null;
        }

        public static void DeleteImage(string wwwRootPath, string? url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var oldImagePath =
                    Path.Combine(wwwRootPath, url.TrimStart('\\'));

                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
        }
    }
}
