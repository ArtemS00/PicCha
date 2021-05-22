using Dapper;
using DapperParameters;
using PicCha.Base;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.User;
using PicCha.Services.Models.User;
using PicCha.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PicCha.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionStringsConfig _connectionStrings;
        public UserRepository(ConnectionStringsConfig connectionStringsConfig)
        {
            _connectionStrings = connectionStringsConfig;
        }

        public async Task<UserRM> GetUser(int id)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@userID", id, DbType.Int32, ParameterDirection.Input);
                return await db.QueryFirstOrDefaultAsync<UserRM>("[dbo].[GetUser]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUser)}", ex);
            }
        }

        public async Task<UserRM> GetUserByEmail(string email)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@email", email, DbType.String, ParameterDirection.Input);
                return await db.QueryFirstOrDefaultAsync<UserRM>("[dbo].[FindUserByEmail]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUserByEmail)}", ex);
            }
        }

        public async Task<UserRM> GetUserByLogin(string login)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@login", login, DbType.String, ParameterDirection.Input);
                return await db.QueryFirstOrDefaultAsync<UserRM>("[dbo].[FindUserByLogin]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUserByLogin)}", ex);
            }
        }

        public async Task CreateUser(CreateUserModelRM model)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@login", model.Login, DbType.String, ParameterDirection.Input);
                parameters.Add("@email", model.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@password", model.Password, DbType.String, ParameterDirection.Input);
                await db.QueryFirstOrDefaultAsync<UserRM>("[dbo].[CreateUser]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUserByLogin)}", ex);
            }
        }

        public async Task<IEnumerable<UserRM>> GetUsers(IEnumerable<int> userIDs)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.AddTable("@ids", "[dbo].[IntTableType]", userIDs.Select(id => new IntTableType(id)).ToArray());
                return await db.QueryAsync<UserRM>("[dbo].[GetUsers]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUserByLogin)}", ex);
            }
        }
    }
}
