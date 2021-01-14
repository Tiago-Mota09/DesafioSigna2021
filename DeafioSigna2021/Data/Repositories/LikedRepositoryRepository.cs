using AutoMapper.Configuration;
using DeafioSigna2021.Data.Entities;
using DeafioSigna2021.Data.Repositories;

namespace DesafioSigna2021.Data.Repositories
{
    public class LikedRepositoryRepository : RepositoryBase
    {
        public LikedRepositoryRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }

        public int Insert(LikedRepositoryEntity likedRepository)
        {
            using var db = Connection;

            var query = @"INSERT INTO usuario
                            (nome)
                            values( 
                            @Nome)
                            RETURNING id_usuario";

            return db.ExecuteScalar<int>(query, new
            {
                likedRepository.NomeRepositorio,
            });
        }

        public int Update(LikedRepositoryEntity likedRepository)
        {
            using var db = Connection;

            var query = @"UPDATE likedRepository
                            SET nome = @Nome
                            WHERE liked_Repository = @LikedRepository AND status = 1;";

            return db.ExecuteScalar(query, new
            {
                likedRepository.IdRepositorio,
            });
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE usuario
							SET tab_status_id = 2
						  WHERE usuario_id = @id";

            return db.Execute(query, new { id });
        }
    }
}
