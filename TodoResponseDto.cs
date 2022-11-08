using NewApi.Models;

namespace NewApi
{
    public class TodoResponseDto
    {
        public List<ToDo> toDos { get; set; } = new List<ToDo>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
