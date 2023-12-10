﻿using MoqaydaGP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoqaydaGP.Repository.Abstract
{
    public interface IProdToSwapRepository
    {
        Task<List<ProdToSwap>> GetProdToSwapsAsync();
        Task<ProdToSwap> CreateProdToSwapAsync(ProdToSwap prodToSwap);
        Task<bool> IsProdToSwapExistAsync(int prodToSwapId);
        Task<bool> DeleteProdToSwapAsync(int id);
        Task<bool> IsProdToSwapExistAsync(string ownerId, int productId, int pOwnerId);
        Task<ProdToSwap> GetProdToSwapAsync(string adObjName, int productId, int pObjectName);
        Task<ProdToSwap> GetProdToSwapAsync(int id);
        Task<ProdToSwap> GetUserAndProdOffersAsync(string userId);
    }
}
