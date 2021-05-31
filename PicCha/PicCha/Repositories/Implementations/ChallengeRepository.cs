using Dapper;
using DapperParameters;
using PicCha.Base;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using PicCha.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PicCha.Repositories.Implementations
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly ConnectionStringsConfig _connectionStrings;
        public ChallengeRepository(ConnectionStringsConfig connectionStringsConfig)
        {
            _connectionStrings = connectionStringsConfig;
        }

        public async Task CreateChallenge(CreateChallangeRM model)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@creatorID", model.CreatorID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@name", model.ChallengeName, DbType.String, ParameterDirection.Input);
                parameters.Add("@description", model.ChallengeDescription, DbType.String, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[CreateChallenge]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(CreateChallenge)}", ex);
            }
        }

        public async Task<ChallengeRM> GetChallenge(int userID, int challengeID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@challengeID", challengeID, DbType.Int32, ParameterDirection.Input);
                return await db.QueryFirstOrDefaultAsync<ChallengeRM>("[dbo].[GetChallenge]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetChallenge)}", ex);
            }
        }

        public async Task<IEnumerable<ChallengeRM>> GetChallenges(int userID = 0, IEnumerable<int> ids = null)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                if (ids != null)
                    parameters.AddTable("@challengeIDs", "[dbo].[IntTableType]", ids.Select(i => new IntTableType(i)).ToArray());
                return await db.QueryAsync<ChallengeRM>("[dbo].[GetChallenges]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetChallenges)}", ex);
            }
        }

        public async Task RemoveChallenge(int id)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeID", id, DbType.Int32, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[DeleteChallenge]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(RemoveChallenge)}", ex);
            }
        }

        public async Task LikeChallenge(int challengeID, int userID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeID", challengeID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[LikeChallenge]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(LikeChallenge)}", ex);
            }
        }

        public async Task UnlikeChallenge(int challengeID, int userID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeID", challengeID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[UnlikeChallenge]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(UnlikeChallenge)}", ex);
            }
        }

        public async Task CreateChallengeWork(int challengeID, int authorID, byte[] work, string comment)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeID", challengeID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@authorID", authorID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@comment", (object)comment ?? DBNull.Value, DbType.String, ParameterDirection.Input);
                parameters.Add("@work", work, DbType.Binary, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[CreateChallengeWork]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(CreateChallengeWork)}", ex);
            }
        }

        public async Task LikeChallengeWork(int challengeWorkID, int userID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeWorkID", challengeWorkID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[LikeChallengeWork]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(LikeChallengeWork)}", ex);
            }
        }

        public async Task UnlikeChallengeWork(int challengeWorkID, int userID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeWorkID", challengeWorkID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                await db.QueryAsync("[dbo].[UnlikeChallengeWork]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(UnlikeChallengeWork)}", ex);
            }
        }

        public async Task<IEnumerable<ChallengeWorkRM>> GetChallengeWorks(int userID, int challengeID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@challengeID", challengeID, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                return await db.QueryAsync<ChallengeWorkRM>("[dbo].[GetChallengeWorks]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetChallengeWorks)}", ex);
            }
        }

        public async Task<IEnumerable<int>> GetUserChallenges(int userID)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
                return await db.QueryAsync<int>("[dbo].[GetUserChallenges]", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(GetUserChallenges)}", ex);
            }
        }
    }
}
