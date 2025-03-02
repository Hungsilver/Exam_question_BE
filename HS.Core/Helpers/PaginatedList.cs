using Microsoft.EntityFrameworkCore;

namespace Exam_question_BE.HS.Core.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public PagedListApiResult<T> ConvertPagedListApiResult()
        {
            var paggingInfo = new PagingInfo(
                pageIndex: PageIndex,
                pageSize: PageSize,
                totalPages: TotalPages,
                totalItems: TotalCount
                );
            return new PagedListApiResult<T>(items: this.ToList(), paggingInfo);
        }
    }
}
