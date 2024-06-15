namespace Models.Domain {


    public class Walk {

        public Guid ID {get; set;}

        public string Description {get; set;}

        public double LengthInKm {get; set;}

        public string? WalkImageUrl {get; set;}

        public Guid DifficultyId {get; set;}

        //difficulty properties
        public Difficulty Difficulty {get; set;}

        //region properties
        public Guid RegionId {get; set;}

        public Region Region {get; set;}

    }



}