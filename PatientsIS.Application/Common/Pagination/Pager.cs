using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsIS.Application.Common.Pagination
{
    public class Pager
    {
        public Pager()
        {
        }

        public Pager(int totalItems, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
           
            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;

            }
            int currentPage = page;
            int startPage = currentPage - 4;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage-1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage >= 9)
                {
                    startPage = endPage - 8;
                }
                else
                {
                    startPage = 1;
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

    }
}
