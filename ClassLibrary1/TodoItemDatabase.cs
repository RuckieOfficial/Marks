using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
    public class TodoItemDatabase {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath) {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Marks>().Wait();
        }

        public Task<List<Marks>> GetItemsAsync() {
            return database.Table<Marks>().ToListAsync();
        }

        public Task<List<Marks>> GetItemsNotDoneAsync() {
            return database.QueryAsync<Marks>("SELECT * FROM [Marks] WHERE [Done] = 0");
        }

        public Task<Marks> GetItemAsync(int id) {
            return database.Table<Marks>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Marks item) {
            if (item.Id != 0) {
                return database.UpdateAsync(item);
            } else {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Marks item) {
            return database.DeleteAsync(item);
        }
    }
}
