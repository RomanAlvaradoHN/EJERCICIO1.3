using EJERCICIO1._3.Models;
using SQLite;

namespace EJERCICIO1._3.Controllers {
    public class DBController {

        //DATABASE CONFIGURATION VARIABLES
        //=======================================================================================
        private readonly static string dbFileName = "Personas.db3";

        private readonly SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite |
                                                 SQLiteOpenFlags.Create |
                                                 SQLiteOpenFlags.SharedCache;

        private readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);
        //---------------------------------------------------------------------------------------
        private SQLiteAsyncConnection connection;
        //======================================================================================



        //CONSTRUCTOR =======================================================
        public DBController() {
        }


        //INICIALIZADOR DE CONECCION =========================================
        private async Task Init() {
            if (connection is not null) {
                return;
            }
            connection = new SQLiteAsyncConnection(dbPath, flags);
            await connection.CreateTableAsync<Personas>();            
        }






        //CREATE ==================================================================
        public async Task<int> Insert(Personas persona) {
            await Init();
            return await connection.InsertAsync(persona);
        }




        //READ ======================================================================
        public async Task<List<Personas>> SelectAll() {
            await Init();
            return await connection.Table<Personas>().ToListAsync();
        }

        public async Task<Personas> SelectById(int id) {
            await Init();
            return await connection.Table<Personas>().Where(col => col.Id == id).FirstOrDefaultAsync();
        }


        

        //UPDATE ====================================================================
        public async Task<int> Update(Personas persona) {
            await Init();
            return await connection.UpdateAsync(persona);
        }




        //DELETE ====================================================================
        public async Task<int> Delete(Personas persona) {
            await Init();
            return await connection.DeleteAsync(persona);
        }


    }
}
