﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public interface IProductPriceRepository
    {
        public Task<ProductPriceDTO> Create(ProductPriceDTO objDto);
        public Task<ProductPriceDTO> Update(ProductPriceDTO objDto);
        public Task<int> Delete(int id);
        public Task<ProductPriceDTO> Get(int id);
        public Task<IEnumerable<ProductPriceDTO>> GetAll(int? id=null);
    }
}
