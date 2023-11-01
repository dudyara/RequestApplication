using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RequestApplicatioin.DB;
using RequestApplication.Entities;
using RequestApplication.Services.Dto;
using RequestApplication.Services.Mapper;

namespace RequestApplication.Services.Services
{
    public abstract class BaseService<TEntity, TDto>
       where TEntity : BaseEntity
       where TDto : BaseDto
    {
        protected IDbRepository<TEntity> Repository { get; }
        protected IApplicationMapper Mapper { get; }

        protected BaseService(IDbRepository<TEntity> repository, IApplicationMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            _ = dto ?? throw new ArgumentException(nameof(dto));
            var entity = await Repository.Get(x => x.Id == dto.Id).FirstOrDefaultAsync();
            Mapper.Map(dto, entity);
            await Repository.UpdateAsync(entity);
            return await GetById(entity.Id);
        }

        /// <summary>
        /// Добавляет новый объект.
        /// </summary>
        /// <param name="dto">Dto.</param>
        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            _ = dto ?? throw new ArgumentException("Должен быть задан добавляемый объект");
            var entity = Mapper.Map<TEntity>(dto);
            await Repository.AddAsync(entity);
            return await GetById(entity.Id);
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="id">ID объекта.</param>
        public virtual async Task<long> DeleteAsync(long id)
        {
            var entity = await Repository.Get(x => x.Id == id).FirstOrDefaultAsync();
            await Repository.DeleteAsync(entity);
            return id;
        }

        /// <summary>
        /// Возвращает список объектов
        /// </summary>
        public virtual async Task<List<TDto>> GetAsync()
        {
            return await Repository
                .Get()
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Возвращает объект по ID.
        /// </summary>
        /// <param name="id">ID объекта.</param>
        public virtual async Task<TDto> GetById(long id)
        {
            return await Repository
                .Get(x => x.Id == id)
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
    }
}
