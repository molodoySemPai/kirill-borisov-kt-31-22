namespace kirillborisovkt_31_22.Models
{
    //Преподаватель
    public class Teacher
    {
        //Уникальный идентификатор преподавателя
        public int TeacherId { get; set; }
        //Имя преподавателя
        public string FirstName { get; set; }
        //Фамилия преподавателя
        public string LastName { get; set; }
        //Вычисляемое свойство для полного имени
        public string FullName => $"{FirstName} {LastName}";

        
        public int DepartmentId { get; set; } //Связь с кафедрой
        public Department Department { get; set; }
        public int? AcademicDegreeId { get; set; }//Связь с ученой степенью(может быть null)
        public AcademicDegree AcademicDegree { get; set; }
        public int PositionId { get; set; } //Связь с должностью
        //Связь с ученой степенью
        public Position Position { get; set; }

        //Нагрузка преподавателя
        public List<Workload> Workloads { get; set; } = new List<Workload>();

    }
}
