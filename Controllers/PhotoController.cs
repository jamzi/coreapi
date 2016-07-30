
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreapi.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private PhotoContext _context;

        public PhotoController(PhotoContext context)
        {
            _context = context;
        }

        // GET api/photo
        [HttpGet]
        public IEnumerable<Photo> Get()
        {
            return _context.Photos;
        }

        // GET api/photo/5
        [HttpGet("{id}")]
        public Photo Get(int id)
        {
            return _context.Photos.Single(p => p.PhotoId == id);
        }

        // POST api/photo
        [HttpPost]
        public void Post([FromBody]Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        // PUT api/photo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Photo newPhoto)
        {
            var photo = Get(id);
            photo.Src = newPhoto.Src;
            photo.Likes = newPhoto.Likes;
            _context.SaveChanges();
        }

        // DELETE api/photo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var photo = Get(id);
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }
    }
}