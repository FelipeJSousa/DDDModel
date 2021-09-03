using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public T Add<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<T> Get() => _baseRepository.Select();

        public T GetById(int id) => _baseRepository.Select(id);

        public T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não informados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
