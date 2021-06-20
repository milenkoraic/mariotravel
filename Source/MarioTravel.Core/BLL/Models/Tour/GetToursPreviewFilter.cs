namespace MarioTravel.Core.BLL.Models.Tour
{
    public class GetToursPreviewFilter
    {
        public GetToursPreviewFilter(int typeId)
        {
            TypeId = typeId;
        }

        public int TypeId { get; }
    }
}