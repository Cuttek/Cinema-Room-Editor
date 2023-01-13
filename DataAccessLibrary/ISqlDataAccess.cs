namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<int> SaveData<T>(string sql, T parameters);
        Task<int> SaveDataAndReturnRow<T>(string sql, T parameters);
        //Task DeleteData<T>(string sql);
        //Task<int> UpdateData<T>(string sql, T parameters);
    }
}