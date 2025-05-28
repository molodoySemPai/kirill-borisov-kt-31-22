namespace kirillborisovkt_31_22.Models
{
    //Кафедра
    public class Department
    {
        //Уникальный идентификатор кафедры
        public int DepartmentId { get; set; }
        //Название кафедры
        public string Name { get; set; }

        //Заведующий кафедрой(один из преподавателей)
        public int HeadTeacherId { get; set; }
        //(связь "один-к-одному" с Teacher)
        public Teacher HeadTeacher { get; set; }

        //Список преподавателей кафедры
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
