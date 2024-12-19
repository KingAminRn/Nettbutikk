namespace Nettbutikk.Models
{
    public class UploadProductModel
    {
        public IFormFile picture { get; set; }

        public int pris { get; set; }
    }
}