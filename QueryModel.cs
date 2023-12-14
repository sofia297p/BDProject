namespace Sanatorium
{
    public class QueryModel
    {
        public int InspectorId { get; set; }
        public int AlcoholicId { get; set; }
        public int PairId { get; set; }
        public int Times { get; set; }
        public int BedId { get; set; }
        public int DrinkId { get; set; }
        public string AlcoholicIds { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
