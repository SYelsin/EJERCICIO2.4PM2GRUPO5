using Ejercicio2_4Grupo5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_4Grupo5.Controllers
{
    public class FirmaDB
    {

        readonly SQLiteAsyncConnection db;

        public FirmaDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<FirmaModel>().Wait();
        }

        public Task<List<FirmaModel>> GetFirmasList()
        {
            return db.Table<FirmaModel>().ToListAsync();
        }

        public Task<FirmaModel> GetFirmaID(int pcodigo)
        {
            return db.Table<FirmaModel>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GuadarFirma(FirmaModel firma)
        {
            if (firma.Id != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        public Task<int> EliminarFirma(FirmaModel firma)
        {
            return db.DeleteAsync(firma);
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
