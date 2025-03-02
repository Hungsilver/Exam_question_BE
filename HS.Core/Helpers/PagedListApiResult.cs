namespace Exam_question_BE.HS.Core.Helpers
{
    public class PagedListApiResult<T>
    {
        public List<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public PagedListApiResult(List<T> items, PagingInfo pagingInfo)
        {
            Items = items;
            PagingInfo = pagingInfo;
        }
    }
    public record PagingInfo(int pageIndex, int pageSize, int totalItems, int? totalPages);
}
