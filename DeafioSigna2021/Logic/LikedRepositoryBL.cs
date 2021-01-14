using AutoMapper;
using DeafioSigna2021.Data.Entities;
using DeafioSigna2021.Domain.Models.Request;
using DesafioSigna2021.Data.Repositories;

namespace DeafioSigna2021.Logic
{
    public class LikedRepositoryBL
    {
        private readonly IMapper _mapper;
        private readonly LikedRepositoryRepository _likedRepositoryRepository;

        public LikedRepositoryBL(LikedRepositoryRepository likedRepositoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _likedRepositoryRepository = likedRepositoryRepository;
        }

        public int Insert(LikedRepositoryRequest likedRepositoryRequest)
        {
            VerificaSeLikedRepositoryJaExiste(likedRepositoryRequest.IdRepository);
           
            var likedRepositoryEntity = _mapper.Map<LikedRepositoryEntity>(likedRepositoryRequest);
            var idLikedRepository = _likedRepositoryRepository.Insert(likedRepositoryEntity);

            return idLikedRepository;
        }

        public int Update(LikedRepositoryUpdateRequest likedRepositoryUpdateRequest)
        {
            var nome = _likedRepositoryRepository.GetLikedRepositoryById(likedRepositoryUpdateRequest.IdLikedRepository);

            if (string.IsNullOrWhiteSpace(nome))
            {
                 throw new System.Exception("Nenhum registro foi encontrado");
            }
        }
        //public IEnumerable<LikedRepositoryResponse> GetAllLikedRepository()
        //{
        //    var likedRepositoryEntities = _likedRepositoryRepository.GetAllLikedRepository();
        //    var likedRepositoryResponse = likedRepositoryEntities.Select(x => _mapper.Map<LikedRepositoryResponse>(x));

        //    return likedRepositoryResponse;
        //}

        //public LikedRepositoryResponse GetLikedRepositoryById(int id)
        //{
        //    var likedRepositoryEntity = _likedRepositoryRepository.GetLikedRepository(id);
        //    var likedRepositoryResponse = _mapper.Map<LikedRepositoryResponse>(likedRepositoryEntity);

        //    return likedRepositoryResponse;
        //}
        public int Delete(int id)
        {
            var likedRepositoryEntity = _likedRepositoryRepository.GetLikedRepositoryById();

            if (likedRepositoryEntity != null)
            {
                var likeRepository = _likedRepositoryRepository.Delete(id);

                return likeRepositoryResponse;
            }
            else
            {
                throw new System.Exception ("Erro ao excluir o registro, contate o administrador");
            }
        }
        private void VerificaSeLikedRepositoryJaExiste(string nome)
        {
            var id = _likedRepositoryRepository.GetIdByNome(nome);

            if (id != 0)
            {
                throw new System.Exception("Esse registro já existe");
            }
        }

        //private IEnumerable<LikedRepositoryResponse> GetLikedRepository(int id)
        //{
        //    var idlikedRepository = _likedRepositoryRepository.GetLikedRepositoryById(id);
        //    var likedRepositoryList = idLikedRepository.Select(x => _mapper.Map<LikedRepositoryResponse>(x));
        //    return likedRepositoryList;
        //}
    }
}
