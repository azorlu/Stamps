using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Stamps.Core.Models;
using Stamps.Core;
using AutoMapper;
using Stamps.Controllers.Resources;
using System.Linq;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Stamps.Controllers
{
    [Route("/api/stamps/{stampId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly PhotoSettings photoSettings;
        private readonly IStampRepository repository;
        private readonly IPhotoRepository photoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhotosController(IHostingEnvironment host,
          IStampRepository repository,
          IPhotoRepository photoRepository,
          IUnitOfWork unitOfWork,
          IMapper mapper,
          IOptionsSnapshot<PhotoSettings> options)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.photoRepository = photoRepository;
            this.host = host;
            this.photoSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(int stampId, IFormFile file)
        {
            var stamp = await repository.GetStampAsync(stampId, includeRelated: false);
            if (stamp == null)
              return NotFound();

            if (file == null)
              return BadRequest("File is null.");
            
            if (file.Length == 0)
              return BadRequest("File is empty.");
            
            if (file.Length > this.photoSettings.MaxFileSize)
              return BadRequest("File size is too large.");
            
            if (!this.photoSettings.IsFileTypeAccepted(file.FileName))
              return BadRequest("Invalid file type.");
            
            var uploadsDirectory = Path.Combine(this.host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            
            var filePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // ToDo:: create thumbnail using System.Drawing
            var photo = new Photo { FileName = fileName };
            stamp.Photos.Add(photo);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoResource>(photo));

        }

        [HttpGet()]
        public async Task<IEnumerable<PhotoResource>> GetPhotosAsync(int stampId) {
            var photos = await photoRepository.GetPhotosAsync(stampId);

            return mapper.Map<IEnumerable<Photo>, List<PhotoResource>>(photos);
        }

    }
}