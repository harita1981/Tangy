using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDTO> Create(CategoryDTO objDto)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDto);
            obj.CreatedDate = DateTime.Now;

            //Category category = new Category()
            //{
            //    Name = objDto.Name,
            //    Id = objDto.Id,
            //    CreatedDate = DateTime.Now,
            //};

            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);


            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //};
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u=>u.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if(obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDto)
        {
            var objfromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objDto.Id);
            if(objfromDb != null)
            {
                objfromDb.Name = objDto.Name;
                _db.Categories.Update(objfromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category,CategoryDTO>(objfromDb);
            }
            return objDto;
        }
    }
}
