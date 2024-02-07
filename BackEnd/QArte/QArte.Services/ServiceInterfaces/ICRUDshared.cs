using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QArte.Services.DTOs;

namespace QArte.Services.ServiceInterfaces
{
	public interface ICRUDshared<T> where T:class
	{
		Task<IEnumerable<T>> GetAsync();
		Task<T> PostAsync(T obj);
		Task<T> UpdateAsync(int id, T obj);
		Task<T> DeleteAsync(int id);
    }
}

