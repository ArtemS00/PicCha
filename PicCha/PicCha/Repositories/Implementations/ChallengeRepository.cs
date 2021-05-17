using Dapper;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using PicCha.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        private static Dictionary<int, ChallengeRM> _fakeChallenges = new Dictionary<int, ChallengeRM>()
        {
            { 1, new ChallengeRM(1, 1, "Геометрия", "Графически доказать теорему Пифагора", 999, 999) },
            { 2, new ChallengeRM(2, 1, "Алгебра", "Изобразить график функции (x - 1)^2 + (y + 1)^2 = 9", 1411, 2193) }
        };

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

        public async Task<IEnumerable<ChallengeRM>> GetChallenges(int userID = 0)
        {
            try
            {
                await using var db = new SqlConnection(_connectionStrings.Default);
                var parameters = new DynamicParameters();
                parameters.Add("@userID", userID, DbType.Int32, ParameterDirection.Input);
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
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(LikeChallenge)}", ex);
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
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(LikeChallenge)}", ex);
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
                throw new Exception($"{nameof(ChallengeRepository)}.{nameof(UnlikeChallenge)}", ex);
            }
        }
    }
}
