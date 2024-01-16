using System;
using QArte.Services.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using QArte.Persistance.Enums;
using QArte.Persistance;
using QArte.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using QArte.Services.DTOMappers;

namespace QArte.Services.Services
{
    public class BanTableService : IBanTableService
    {
        private readonly QArteDBContext _qArteDBContext;

        public BanTableService(QArteDBContext qArteDBContext)
        {
            this._qArteDBContext = qArteDBContext;
        }

        public async Task<bool> BanTableExists(int id, int BanId)
        {
            return await _qArteDBContext.BanTables.AnyAsync(x => x.ID == id && x.BanID == BanId);
        }

        public async Task<BanTableDTO> GetBanTableByID(int id)
        {

            var banTable = await _qArteDBContext.BanTables
              .FirstOrDefaultAsync(x => x.ID == id)
              ?? throw new ApplicationException("Not found");
            return banTable.GetDTO();
        }


        public async Task<BanTableDTO> DeleteAsync(int id)
        {

            var banTable = await this._qArteDBContext.BanTables
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            this._qArteDBContext.BanTables.Remove(banTable);
            await _qArteDBContext.SaveChangesAsync();

            return banTable.GetDTO();
        }

        public async Task<IEnumerable<BanTableDTO>> GetAsync()
        {

            return await this._qArteDBContext.BanTables
                .Select(x => new BanTableDTO
                {
                    ID = x.ID,
                    BanID = x.BanID,
                }).ToListAsync();
        }

        public async Task<BanTableDTO> UpdateAsync(int id, BanTableDTO obj)
        {

            _ = await BanTableExists(obj.ID, obj.BanID)
                == true ? throw new ApplicationException("Not found") : 0;

            var banTable = await this._qArteDBContext.BanTables
                .FirstOrDefaultAsync(x => x.ID == id)
                ?? throw new ApplicationException("Not found");

            if (obj.ID == null)
            {
                throw new ApplicationException("Bad input");
            }

            banTable.ID = obj.ID;
            banTable.BanID = obj.BanID;
            await _qArteDBContext.SaveChangesAsync();

            return banTable.GetDTO();
        }

        public async Task<BanTableDTO> PostAsync(BanTableDTO obj)
        {
            _ = await BanTableExists(obj.ID, obj.BanID)
                == true ? throw new ApplicationException("Not found") : 0;

            BanTableDTO result = null;

            var deletedBanTable = await _qArteDBContext.BanTables
                                            .IgnoreQueryFilters()
                                            .FirstOrDefaultAsync(x => x.BanID == obj.BanID);
            var newBanTable = obj.GetEntity();
            if (deletedBanTable == null)
            {
                await this._qArteDBContext.BanTables.AddAsync(newBanTable);
                await _qArteDBContext.SaveChangesAsync();
                result = newBanTable.GetDTO();
            }
            else
            {
                result = deletedBanTable.GetDTO();

            }

            return result;
        }
    }
}