using Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Add<TValidator>(T obj) where TValidator : AbstractValidator<T>;

        void Delete(int id);

        IList<T> Get();

        T GetById(int id);

        T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
    }
}
