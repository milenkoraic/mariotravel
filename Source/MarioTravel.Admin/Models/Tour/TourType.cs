namespace MarioTravel.Admin.Models.Tour
{
    public class TourType
    {
        public TourType(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException(nameof(name));
            }

            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}