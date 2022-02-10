using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.Dtos;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Api.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly IMapper mapper;
        private readonly CourseService service = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns>Course List</returns>
        /// <response code="200">Ok. Return object list</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await service.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        /// <summary>
        /// Get one course by id
        /// </summary>
        /// <remarks>
        /// This method get one course object by its id value.
        /// </remarks>
        /// <param name="id">Object Id</param>
        /// <returns>Course item</returns>
        /// <response code="200">Ok. Return one object</response>
        /// <response code="404">NotFound. Object was not found in database.</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await service.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDTO = mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await service.Insert(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(courseDTO.CourseID != id)
            {
                return BadRequest();
            }

            try
            {
                var course = await service.GetById(id);

                if (course == null)
                {
                    return NotFound();
                }

                course = mapper.Map<Course>(courseDTO);
                course = await service.Update(course);
                
                return Ok(course);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var course = await service.GetById(id);
                if(course == null)
                {
                    return NotFound();
                }
                await service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
