namespace kirillborisovkt_31_22.Models
{
    //Нагрузка 
    public class Workload
    {
        //Первичный ключ нагрузки
        public int WorkloadId { get; set; }
        //Количество часов нагрузки
        public int Hours { get; set; } 
        //Внешние ключи
        public int TeacherId { get; set; } //связь с преподавателем
        public int SubjectId { get; set; } //связь с дисциплиной

        //Навигационные свойства
        public Teacher Teacher { get; set; } //для преподавателя
        public Subject Subject { get; set; }//для дисциплины
    }
}
