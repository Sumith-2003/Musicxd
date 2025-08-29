namespace Musicxd.API.DTO
{
    public class ProfileResponseDto
    {
        public string Username { get; set; }
        public int DateJoinedId { get; set; }  //FK
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Bio { get; set; }
    }
}
