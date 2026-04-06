using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class PaginationService
    {
        public PaginationModel GetPaginationModel(int currentPage, int totalCount, int pageSize, string action, string searchTerm = null)
        {
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > totalPages && totalPages > 0) currentPage = totalPages;

            return new PaginationModel
            {
                CurrentPage = currentPage,
                TotalPages = totalPages,
                TotalCount = totalCount,
                PageSize = pageSize,
                Action = action,
                SearchTerm = searchTerm ?? ""
            };
        }

        public List<T> GetPagedData<T>(List<T> data, int page, int pageSize)
        {
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
