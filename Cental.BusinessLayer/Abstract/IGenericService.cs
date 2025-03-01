﻿namespace Cental.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {

        List<T> TGetAll();
        T TGetById(int id);
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
    }
}
