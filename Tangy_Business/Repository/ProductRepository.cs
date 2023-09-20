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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO objDto)
        {
            var obj = _mapper.Map<ProductDTO, Product>(objDto);
            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(addedObj.Entity);


        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(u=>u.Id == id);
            if (obj != null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _db.Products.Include(u=>u.Category).Include(u=>u.Prices).FirstOrDefaultAsync(u=>u.Id==id);
            if(obj != null)
            {
                return _mapper.Map<Product , ProductDTO>(obj);
            }
            return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u=>u.Category).Include(u=>u.Prices));
        }

        public async Task<ProductDTO> Update(ProductDTO objDto)
        {
            var objfromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDto.Id);
            if (objfromDb != null)
            {
                objfromDb.Name = objDto.Name;
                objfromDb.Description = objDto.Description;
                objfromDb.ImageUrl = objDto.ImageUrl;
                objfromDb.CategoryId = objDto.CategoryId;
                objfromDb.Color = objDto.Color;
                objfromDb.ShopFavourite = objDto.ShopFavourite;
                objfromDb.CustomerFavourite = objDto.CustomerFavourite;
                _db.Products.Update(objfromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(objfromDb);
            }
            return objDto;
        }
    }
}
