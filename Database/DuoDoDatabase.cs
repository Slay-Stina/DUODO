using SQLite;
using DUODO.Models;

namespace DUODO.Database;

public class DuoDoDatabase
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await database.CreateTableAsync<DuoDoItem>();
    }
    public async Task<List<DuoDoItem>> GetItemsAsync()
    {
        await Init();
        return await database.Table<DuoDoItem>().ToListAsync();
    }

    public async Task<List<DuoDoItem>> GetItemsNotDoneAsync()
    {
        await Init();
        return await database.Table<DuoDoItem>().Where(t => !t.IsCompleted).ToListAsync();

        // SQL queries are also possible
        //return await Database.QueryAsync<DuoDoItem>("SELECT * FROM [DuoDoItem] WHERE [Done] = 0");
    }

    public async Task<DuoDoItem> GetItemAsync(int id)
    {
        await Init();
        return await database.Table<DuoDoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(DuoDoItem item)
    {
        await Init();
        if (item.ID != 0)
            return await database.UpdateAsync(item);
        else
            return await database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(DuoDoItem item)
    {
        await Init();
        return await database.DeleteAsync(item);
    }
}