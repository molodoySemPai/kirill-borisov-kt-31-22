namespace kirillborisovkt_31_22.Models
{
    //Дисциплина
    public class Subject
    {
        //Уникальный идентификатор дисциплины
        public int SubjectId { get; set; }
        //Название дисциплины
        public string Name { get; set; }
        //Список нагрузок по этой дисциплине
        public List<Workload> Workloads { get; set; }
    }
}
