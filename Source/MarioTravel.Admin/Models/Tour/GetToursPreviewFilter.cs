namespace MarioTravel.Admin.Models.Tour
{
    public class GetToursPreviewFilter
    {
        public GetToursPreviewFilter(int typeId, int pageNumber = 1, int? pageSize = null, int[] excludeIds = null)
        {
            TypeId = typeId;
            PageSize = pageSize;
            PageNumber = pageNumber;
            ExcludeIds = excludeIds;
        }

        public int PageNumber { get; }
        public int? PageSize { get; }
        public int TypeId { get; }
        public int[] ExcludeIds { get; }
    }
}