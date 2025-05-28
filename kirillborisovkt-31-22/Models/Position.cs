namespace kirillborisovkt_31_22.Models
{
    //Должность
    public class Position
    {
        //Уникальный идентификатор должности
        public int PositionId { get; set; }
        //Название должности
        public string Title { get; set; }
        //Список преподавателей с этой должностью
        public List<Teacher> Teachers { get; set; }
    }
}
