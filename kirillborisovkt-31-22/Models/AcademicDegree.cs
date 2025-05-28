namespace kirillborisovkt_31_22.Models
{
    //Ученая степень
    public class AcademicDegree
    {
        //Уникальный идентификатор ученой степени
        public int AcademicDegreeId { get; set; }
        //Название степени
        public string Name { get; set; }
        //Список преподавателей с этой степенью
        public List<Teacher> Teachers { get; set; }
    }
}
